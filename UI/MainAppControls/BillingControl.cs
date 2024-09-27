using System.Text;
using ExamTracker.Helpers;
using DataAcessLayer.Contracts;
using ExamTracker.CustomControls;
using DomainModel.Models;
using System.Text.RegularExpressions;

namespace ExamTracker.UI.MainAppControls
{
    public partial class BillingControl : UserControl
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IProductServiceRepository _productServiceRepository;
        private readonly ISessionService _sessionService;
        private List<SoldProductsServicesItems> allitems;
        private List<Invoice> invoicesList;
        public BillingControl(IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository, ISessionService sessionService)
        {
            InitializeComponent();
            _invoiceRepository = invoiceRepository;
            _productServiceRepository = productServiceRepository;
            _sessionService = sessionService;
            ItemsFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            allitems = new List<SoldProductsServicesItems>();
            invoicesList = new List<Invoice>();
        }

        private void ChangeLanguage()
        {
            if (LanguageHelper.Lang == "pl_pl")
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
                AddInvoiceButton.Text ="Dodaj fakturę";
                InvoicesTable.Columns[0].HeaderText = "Numer faktury";
                InvoicesTable.Columns[2].HeaderText = "Czy zapłacona?";
                InvoicesTable.Columns[3].HeaderText = "Klient";
            }
            else if (LanguageHelper.Lang == "eng_us")
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

        private string GenerateInvoiceNumber()
        {
            int numberId = Math.Abs(Guid.NewGuid().GetHashCode() % 9000) + 1000;
            string currYear = DateTime.Now.Year.ToString();
            return $"{numberId}/EXTR/{currYear}";
        }
        private int GenerateUniqueIdentifier()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }
        private void CustomizeGridAppearance()
        {
            InvoicesTable.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[4];

            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "InvoiceNumber", HeaderText = "Invoice Number" };
            columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            columns[1] = new DataGridViewImageColumn() { DataPropertyName = "picture", HeaderText = "" };
            columns[1].Width = 30;
            columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Is Paid?", HeaderText = "Is Paid?" };
            columns[2].Width = 40;
            columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Buyer", HeaderText= "Client" };
            columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            InvoicesTable.RowHeadersVisible = false;
            InvoicesTable.Columns.Clear();
            InvoicesTable.Columns.AddRange(columns);

        }

        private void ClearInformationBoxes()
        {
            DateOfSaleTextBox.Clear();
            DateOfPaymentTextBox.Clear();
            RemarksTextBox.Clear();
            ItemsFlowLayoutPanel.Controls.Clear();
            allitems.Clear();
        }

        private async Task PopulateInvoicesTable()
        {
            InvoicesTable.DataSource = null;
            invoicesList = await _invoiceRepository.GetAllInvoicesOfAnAccount(_sessionService.CurrentAccount.Id);
            InvoicesTable.DataSource = invoicesList;
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
            }
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            SoldProductsServicesItems panel = new SoldProductsServicesItems();
            allitems.Add(panel);
            ItemsFlowLayoutPanel.Controls.Add(panel);
        }
        private bool ValidateFlowItems()
        {
            foreach(SoldProductsServicesItems item in ItemsFlowLayoutPanel.Controls)
            {
                if(!item.ValidateItem())
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateInvoiceForm()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int counter = 1;
            bool isValid = true;

            string patternEng = "^[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}$";
            string patternPl = "^[0-9]{2}\\.[0-9]{2}\\.[0-9]{4}$";
            string lang = LanguageHelper.Lang;

            if (lang == "pl_pl")
            {
                stringBuilder.Append("Wystąpił problem z twoim formularzem:\n");
            }
            else if (lang == "eng_us")
            {
                stringBuilder.Append("There was  aproblem with your form:\n");
            }
            
            if (string.IsNullOrEmpty(DateOfSaleTextBox.Text))
            {
                if (lang == "pl_pl")
                {
                    stringBuilder.Append($"{counter}. Wprowadź datę sprzedaży.\n");
                }
                else if (lang == "eng_us")
                {
                    stringBuilder.Append($"{counter}. Provide a date of sale.\n");
                }
                isValid = false;
                counter++;
            }
            else if (!Regex.Match(DateOfSaleTextBox.Text, patternEng).Success && 
                        !Regex.Match(DateOfSaleTextBox.Text, patternPl).Success)
            {
                if (lang == "pl_pl")
                {
                    stringBuilder.Append($"{counter}. Wprowadź poprawną datę sprzedaży.\n");
                }
                else if (lang == "eng_us")
                {
                    stringBuilder.Append($"{counter}. Provide a valid date of sale.\n");
                }
                counter++;
                isValid = false;
            }

            if (string.IsNullOrEmpty(DateOfPaymentTextBox.Text))
            {
                if (lang == "pl_pl")
                {
                    stringBuilder.Append($"{counter}. Wprowadź datę płatności.\n");
                }
                else if (lang == "eng_us")
                {
                    stringBuilder.Append($"{counter}. Provide a date of payment.\n");
                }
                counter++;
                isValid = false;
            }
            else if (!Regex.Match(DateOfPaymentTextBox.Text, patternEng).Success &&
                        !Regex.Match(DateOfPaymentTextBox.Text, patternPl).Success)
            {
                if (lang == "pl_pl")
                {
                    stringBuilder.Append($"{counter}. Wprowadź poprawną datę płatności.\n");
                }
                else if (lang == "eng_us")
                {
                    stringBuilder.Append($"{counter}. Provide a valid date of payment.\n");
                }
                counter++;
                isValid = false;
            }
            if (allitems.Count < 1)
            {
                if (lang == "pl_pl")
                {
                    stringBuilder.Append($"{counter}. Wprowadź przynajmniej jeden produkt lub usługę.\n");
                }
                else if (lang == "eng_us")
                {
                    stringBuilder.Append($"{counter}. Provide at least one service or product.\n");
                }
                counter++;
                isValid = false;
            }
                
            if (!isValid)
            {
                if (lang == "pl_pl")
                {
                    MessageBox.Show(stringBuilder.ToString(), "Faktura nieprawidłowa");
                }
                else if (lang == "eng_us")
                {
                    MessageBox.Show(stringBuilder.ToString(), "Invalid invoice");
                }
            }
            return isValid;
        }

        private async void AddInvoiceButton_Click(object sender, EventArgs e)
        {
            string lang = LanguageHelper.Lang;
            if(!ValidateFlowItems())
            {
                if (lang == "pl_pl")
                {
                    MessageBox.Show("Wprowadź poprawne wartości", "Błąd przy wprowadzania wartości");

                }
                else if (lang == "eng_us")
                {
                    MessageBox.Show("Provide valid values", "Error while providing values");

                }
                return;
            }
            if (!ValidateInvoiceForm())
            {
                return;
            }
            // for simplicity assume 12% tax
            double Tax = 0.88;
            int uniqueId = GenerateUniqueIdentifier();
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
            string buyerAddress = "Warszawa, Bolka i Lolka 23/2A";
            string selersAddress = "Kraków, Koziolka Matolka 11/3D Pokoj 3";
            string accNum = "63 1112 9074 2222 0011 0999 8931";
            string remarks = RemarksTextBox.Text;
            Invoice invoice = new Invoice(GenerateInvoiceNumber(), now, DateOfSaleTextBox.Text, DateOfPaymentTextBox.Text,
                                    "Transfer", "Me, myself and I Inc.", buyerAddress, "You solobolo limited", selersAddress, accNum,
                                    "zl", remarks, GrossAmount, NetAmount, _sessionService.CurrentAccount.Id, uniqueId);
            await _invoiceRepository.InsertInvoice(invoice);
            ClearInformationBoxes();
            await PopulateInvoicesTable();
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
            CustomizeGridAppearance();
            await PopulateInvoicesTable();
            ChangeLanguage();
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
    }
}
