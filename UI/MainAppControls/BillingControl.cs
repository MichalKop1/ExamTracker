using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText;
using ExamTracker.Helpers;
using DataAcessLayer.Contracts;
using ExamTracker.CustomControls;
using DomainModel.Models;
using System.Globalization;

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
            panel.ItemIsValid += Panel_ItemIsValid;
            allitems.Add(panel);
            ItemsFlowLayoutPanel.Controls.Add(panel);
        }

        private void Panel_ItemIsValid(bool isValid)
        {
            if (!isValid)
            {
                MessageBox.Show("Provide valid numbers", "Error while providing a number");
            }
        }

        private async void AddInvoiceButton_Click(object sender, EventArgs e)
        {
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


            string now = (DateTime.Now).Date.ToShortDateString();
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
            SellDateCalendar.Visible = true;
        }

        private void SellDateCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateOfSaleTextBox.Text = e.Start.ToShortDateString();
            SellDateCalendar.Visible = false;
        }

        private void PaymentCalendarButton_Click(object sender, EventArgs e)
        {
            PaymentCalendar.Visible = true;
        }

        private void PaymentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateOfPaymentTextBox.Text = e.Start.ToShortDateString();
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
