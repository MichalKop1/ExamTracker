using System.Text;
using ExamTracker.Helpers;
using DataAcessLayer.Contracts;
using ExamTracker.CustomControls;
using DomainModel.Models;
using log4net;
using ExamTracker.Utilities;
using DataAcessLayer.Repositories;

namespace ExamTracker.UI.MainAppControls;

public partial class BillingControl : UserControl
{
	protected readonly ILog log = LogManager.GetLogger(typeof(BillingControl));

	private readonly IInvoiceRepository _invoiceRepository;
	private readonly IProductServiceRepository _productServiceRepository;
	private readonly ISessionService _sessionService;
	private readonly IClientRepository _clientRepository;
	private readonly ICacheService _cacheService;

	private BillingControlUtilities _billingControlUtilities;
	private Client chosenClient = new();
	private List<SoldProductsServicesItems> allitems;
	private string payment = string.Empty;

	public BillingControl(IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository,
		ISessionService sessionService, IClientRepository clientRepository, ICacheService cacheService)
	{
		InitializeComponent();
		_invoiceRepository = invoiceRepository;
		_productServiceRepository = productServiceRepository;
		_sessionService = sessionService;
		_clientRepository = clientRepository;
		_cacheService = cacheService;

		ItemsFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
		allitems = new List<SoldProductsServicesItems>();
		_billingControlUtilities = new(_invoiceRepository, _sessionService, _clientRepository, _cacheService);
	}

	private void ChangeLanguage()
	{
		if (LanguageHelper.GetLanguage == Language.Polish_Pl)
		{
			InvoiceListLabel.Text = "Lista faktur";
			InvoiceLabel.Text = "Zatwierdzone faktury";
			CreateInvoiceLabel.Text = "Stwórz fakturę";
			DateOfSaleTextBox.PlaceholderText = "Data sprzedaży (MM-DD-YYYY)";
			DateOfPaymentTextBox.PlaceholderText = "Data płatności (MM-DD-YYYY)";
			DescriptionLabel.Text = "Opis";
			UnitPriceLabel.Text = "Cena jednostkowa";
			QuantityLabel.Text = "Ilość";
			AddItemButton.Text = "Dodaj pozycję";
			AddInvoiceButton.Text = "Dodaj fakturę";
			InvoicesTable.Columns[0].HeaderText = "Numer faktury";
			InvoicesTable.Columns[2].HeaderText = "Czy zapłacona?";
			InvoicesTable.Columns[3].HeaderText = "Klient";
		}
		else if (LanguageHelper.GetLanguage == Language.English_Us)
		{
			InvoiceListLabel.Text = "Invoice list";
			InvoiceLabel.Text = "Approved invoices";
			CreateInvoiceLabel.Text = "Create invoice";
			DateOfSaleTextBox.PlaceholderText = "Sell date (MM-DD-YYYY)";
			DateOfPaymentTextBox.PlaceholderText = "Payment date (MM-DD-YYYY)";
			DescriptionLabel.Text = "Description";
			UnitPriceLabel.Text = "Unit price";
			QuantityLabel.Text = "Quantity";
			AddItemButton.Text = "Add item";
			AddInvoiceButton.Text = "Add invoice";
			InvoicesTable.Columns[0].HeaderText = "Invoice Number";
			InvoicesTable.Columns[2].HeaderText = "Is paid?";
			InvoicesTable.Columns[3].HeaderText = "Client";
		}
	}

	private void Click_LostFocus(object? sender, EventArgs e)
	{
		PaymentCalendar.Visible = false;
		SellDateCalendar.Visible = false;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Filter = "PDF files (*.pdf)|*.pdf",
			Title = "Save PDF Invoice"
		};

		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			PdfHelper pdfHelper = new PdfHelper();
			pdfHelper.CreatePdfInvoice(saveFileDialog.FileName, _invoiceRepository.GetInvoice(1), _productServiceRepository.GetAllOrders());

			log.Info($"Invoice downloaded successfuly.");
		}
	}

	private void AddRowButton_Click(object sender, EventArgs e)
	{
		SoldProductsServicesItems panel = new SoldProductsServicesItems();
		allitems.Add(panel);
		ItemsFlowLayoutPanel.Controls.Add(panel);

		log.Info($"{panel.ProductName} added.");
	}

	private async void AddInvoiceButton_Click(object sender, EventArgs e)
	{
		Language lang = LanguageHelper.GetLanguage;

		if (!_billingControlUtilities.ValidateFlowItems(ItemsFlowLayoutPanel))
		{
			if (lang == Language.Polish_Pl)
			{
				MessageBox.Show("Wprowadź poprawne wartości", "Błąd przy wprowadzania wartości");

			}
			else if (lang == Language.English_Us)
			{
				MessageBox.Show("Provide valid values", "Error while providing values");

			}
			return;
		}

		if (!_billingControlUtilities.ValidateInvoiceForm(DateOfSaleTextBox, DateOfPaymentTextBox, allitems))
		{
			return;
		}

		// for simplicity assume 12% tax
		double Tax = 0.88;
		int uniqueId = BillingControlUtilities.GenerateUniqueIdentifier();
		int GrossAmount = 0;

		foreach (var item in allitems)
		{
			int numbOfItems = item.GetQuantity();
			double unitPrice = item.GetPrice() * 100; //*100 to prevent loss of data
			int totalPriceOfItem = Convert.ToInt32(numbOfItems * unitPrice);
			GrossAmount += totalPriceOfItem;

			ProductService ps = new ProductService(item.GetItemType(), numbOfItems, unitPrice, totalPriceOfItem, uniqueId);
			await _productServiceRepository.InsertProductService(ps);
		}
		int NetAmount = Convert.ToInt32(Math.Round(GrossAmount * Tax));


		string now = (DateTime.Now).Date.ToString("dd/MM/yyyy");

		string buyerAddress = chosenClient.CompanyAddress;
		string buyer = chosenClient.CompanyName ?? "Null";

		string selersAddress = _sessionService.CurrentAccount.StreetAdress ?? "Null address";
		string sellersName = _sessionService.CurrentAccount.ContactName ?? "Null name";
		string accNum = "63 1112 9074 2222 0011 0999 8931"; // add acc number for the user
		string remarks = RemarksTextBox.Text;

		var invoiceNumber = BillingControlUtilities.GenerateInvoiceNumber();
		Invoice invoice = new Invoice(invoiceNumber, now, DateOfSaleTextBox.Text, DateOfPaymentTextBox.Text,
							payment, buyer, buyerAddress, sellersName, selersAddress, accNum,
							"zl", remarks, GrossAmount, NetAmount, _sessionService.CurrentAccount.Id, uniqueId);

		await _invoiceRepository.InsertInvoice(invoice);

		string key = $"invoice:{_sessionService.CurrentAccount.Id}";
		_cacheService.SetAddToList<Invoice>(invoice, key, TimeSpan.FromHours(1));

		_billingControlUtilities.ClearInformationBoxes(DateOfSaleTextBox, DateOfPaymentTextBox, RemarksTextBox, ItemsFlowLayoutPanel, allitems);
		await _billingControlUtilities.PopulateInvoicesTable(InvoicesTable);

		log.Info($"Invoice created: {invoice.Buyer}");
	}

	private void InvoicesTable_CellClick(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0 && InvoicesTable.CurrentCell is DataGridViewImageCell)
		{
			if (InvoicesTable.CurrentCell.OwningColumn.DataPropertyName == "picture")
			{
				Invoice clickedInvoice = (Invoice)InvoicesTable.Rows[e.RowIndex].DataBoundItem;

				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Filter = "PDF files (*.pdf)|*.pdf",
					Title = "Save PDF Invoice",
					FileName = $"{(clickedInvoice.InvoiceNumber).Replace("/", "_")}.pdf"
				};

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					PdfHelper pdfHelper = new PdfHelper();
					pdfHelper.CreatePdfInvoice(saveFileDialog.FileName, _invoiceRepository.GetInvoice(clickedInvoice.UniqueIdentifier),
						_productServiceRepository.GetAllOrdersOfTheInvoice(clickedInvoice.UniqueIdentifier));
				}
			}
		}
	}

	private async void BillingControl_Load(object sender, EventArgs e)
	{
		_billingControlUtilities.CustomizeGridAppearance(InvoicesTable);
		await _billingControlUtilities.PopulateInvoicesTable(InvoicesTable);
		ChangeLanguage();
		await _billingControlUtilities.PopulateClientsComboBox(ClientsComboBox);
	}

	private void InvoicesTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
	{
		Image pdfIco = Properties.Resources.pdf;

		foreach (DataGridViewRow row in InvoicesTable.Rows)
		{
			if (row.Cells[1] is DataGridViewImageCell imageCell)
			{
				imageCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
				imageCell.Value = pdfIco;
			}
		}
		InvoicesTable.ClearSelection();
		InvoicesTable.EnableHeadersVisualStyles = false;
		InvoicesTable.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		bool visibility = SellDateCalendar.Visible;

		if (visibility)
		{
			SellDateCalendar.Visible = false;
		}
		else
		{
			SellDateCalendar.Visible = true;
		}

	}

	private void SellDateCalendar_DateSelected(object sender, DateRangeEventArgs e)
	{
		DateOfSaleTextBox.Text = e.Start.ToString("dd/MM/yyyy");
		SellDateCalendar.Visible = false;
	}

	private void PaymentCalendarButton_Click(object sender, EventArgs e)
	{
		bool visibility = PaymentCalendar.Visible;
		if (visibility)
		{
			PaymentCalendar.Visible = false;
		}
		else
		{
			PaymentCalendar.Visible = true;
		}

	}

	private void PaymentCalendar_DateChanged(object sender, DateRangeEventArgs e)
	{
		DateOfPaymentTextBox.Text = e.Start.ToString("dd/MM/yyyy");
		PaymentCalendar.Visible = false;
	}

	private void InvoicesTable_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			InvoicesTable.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
			if (e.ColumnIndex == 1)
			{
				InvoicesTable.Cursor = Cursors.Hand;
			}
		}
	}

	private void InvoicesTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex >= 0)
		{
			InvoicesTable.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
			if (e.ColumnIndex == 1)
			{
				InvoicesTable.Cursor = Cursors.Arrow;
			}
		}
	}

	private void BillingControl_Click(object sender, EventArgs e)
	{
		PaymentCalendar.Visible = false;
		SellDateCalendar.Visible = false;
	}

	private void label1_Click(object sender, EventArgs e)
	{
		PaymentCalendar.Visible = false;
		SellDateCalendar.Visible = false;
	}

	private void ItemsFlowLayoutPanel_Click(object sender, EventArgs e)
	{
		PaymentCalendar.Visible = false;
		SellDateCalendar.Visible = false;
	}

	private void BillingControl_MouseClick(object sender, MouseEventArgs e)
	{
		PaymentCalendar.Visible = false;
		SellDateCalendar.Visible = false;
	}

	private void InvoicesTable_SelectionChanged(object sender, EventArgs e)
	{
		InvoicesTable.ClearSelection();
	}

	private void AddClientButton_Click(object sender, EventArgs e)
	{
	}

	private void ClientsComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		var comboBox = sender as ComboBox;

		chosenClient = comboBox.SelectedItem as Client ?? throw new ArgumentNullException();
	}

	private void TransferCheckBox_Click(object sender, EventArgs e)
	{
		payment = "Transfer";
	}

	private void CashCheckBox_Click(object sender, EventArgs e)
	{
		payment = "Cash";
	}
}
