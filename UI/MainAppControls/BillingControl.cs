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

namespace ExamTracker.UI.MainAppControls
{
    public partial class BillingControl : UserControl
    {
        IInvoiceRepository _invoiceRepository;
        IProductServiceRepository _productServiceRepository;
        ISessionService _sessionService;
        private List<SoldProductsServicesItems> allitems;
        public BillingControl(IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository, ISessionService sessionService)
        {
            InitializeComponent();
            _invoiceRepository = invoiceRepository;
            _productServiceRepository = productServiceRepository;
            _sessionService = sessionService;
            ItemsFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            allitems = new List<SoldProductsServicesItems>();
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
            InvoicesTable.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            InvoicesTable.AutoGenerateColumns = false;

            DataGridViewColumn[] columns = new DataGridViewColumn[4];

            //picture doesnt show
            columns[0] = new DataGridViewTextBoxColumn() { DataPropertyName = "InvoiceNumber", HeaderText = "Invoice Number" };
            columns[1] = new DataGridViewImageColumn() { DataPropertyName = "picture", HeaderText = "" };
            columns[2] = new DataGridViewTextBoxColumn() { DataPropertyName = "Is Paid?", HeaderText = "Is Paid?" };
            columns[3] = new DataGridViewTextBoxColumn() { DataPropertyName = "Buyer", HeaderText = "Client" };


            InvoicesTable.RowHeadersVisible = false;
            InvoicesTable.Columns.Clear();
            InvoicesTable.Columns.AddRange(columns);
        }

        private async Task PopulateInvoicesTable()
        {
            List<Invoice> invList = await _invoiceRepository.GetAllInvoicesOfAnAccount(_sessionService.CurrentAccount.Id);
            InvoicesTable.DataSource = invList;

            


            //for (int row = 0; row <= InvoicesTable.Rows.Count - 1; row++)
            //{
            //    ((DataGridViewImageCell)InvoicesTable.Rows[row].Cells[1]).Value = Properties.Resources.pdf;
            //}

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
                PdfHelper.CreatePdfInvoice(saveFileDialog.FileName, _invoiceRepository.GetInvoice(1), _productServiceRepository.GetAllOrders());
            }
        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            SoldProductsServicesItems panel = new SoldProductsServicesItems();
            allitems.Add(panel);
            ItemsFlowLayoutPanel.Controls.Add(panel);
        }
        
        private void AddInvoiceButton_Click(object sender, EventArgs e)
        {
            int uniqueId = GenerateUniqueIdentifier();
            string now = (DateTime.Now).Date.ToShortDateString();
            string buyerAddress = "Warszawa, Bolka i Lolka 23/2A";
            string selersAddress = "Kraków, Koziolka Matolka 11/3D Pokoj 3";
            string accNum = "63 1112 9074 2222 0011 0999 8931";
            string remarks = RemarksTextBox.Text;
            Invoice invoice = new Invoice(GenerateInvoiceNumber(), now, DateOfSaleTextBox.Text, DateOfPaymentTextBox.Text,
                                    "Transfer", "Me, myself and I Inc.", buyerAddress, "You solobolo limited", selersAddress, accNum,
                                    "zl", remarks, 20, 20, _sessionService.CurrentAccount.Id, uniqueId);

            _invoiceRepository.InsertInvoice(invoice);


            Invoice inv = _invoiceRepository.GetInvoice(uniqueId);
            int invoiceId = inv.Id;
            foreach (var item in allitems)
            {
                int numbOfItems = item.GetQuantity();
                double unitPrice = item.GetPrice();
                double totalPrice = numbOfItems * (unitPrice*100);


                ProductService ps = new ProductService(item.GetItemType(), numbOfItems, unitPrice, totalPrice, invoiceId);
                _productServiceRepository.InsertProductService(ps);
            }
        }

        private void InvoicesTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && InvoicesTable.CurrentCell is DataGridViewImageCell)
            {
                if (InvoicesTable.CurrentCell.OwningColumn.DataPropertyName == "picture")
                {
                    Invoice clicekdInvoice = (Invoice)InvoicesTable.Rows[e.RowIndex].DataBoundItem;

                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "PDF files (*.pdf)|*.pdf",
                        Title = "Save PDF Invoice"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        PdfHelper.CreatePdfInvoice(saveFileDialog.FileName, _invoiceRepository.GetInvoice(clicekdInvoice.UniqueIdentifier),
                            _productServiceRepository.GetAllOrdersOfTheInvoice(clicekdInvoice.Id));
                    }


                }
            }
        }

        private async void BillingControl_Load(object sender, EventArgs e)
        {
            CustomizeGridAppearance();
            await PopulateInvoicesTable();
        }

        private void InvoicesTable_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Image sameImage = Image.FromFile("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\pictures\\pdf_ico.ico");

            // Set the same image for each row in the image column
            foreach (DataGridViewRow row in InvoicesTable.Rows)
            {
                if (row.Cells[1] is DataGridViewImageCell imageCell)
                {
                    imageCell.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCell.Value = sameImage;
                }
            }
        }
    }
}
