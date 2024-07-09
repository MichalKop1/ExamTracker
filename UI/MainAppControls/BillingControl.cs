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

namespace ExamTracker.UI.MainAppControls
{
    public partial class BillingControl : UserControl
    {
        IInvoiceRepository _invoiceRepository;
        IProductServiceRepository _productServiceRepository;
        public BillingControl(IInvoiceRepository invoiceRepository, IProductServiceRepository productServiceRepository)
        {
            InitializeComponent();
            _invoiceRepository = invoiceRepository;
            _productServiceRepository = productServiceRepository;
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
                PdfHelper pd = new PdfHelper();
                pd.CreatePdfInvoice(saveFileDialog.FileName, _invoiceRepository.GetInvoice(1), _productServiceRepository.GetAllOrders());
            }
        }
    }
}
