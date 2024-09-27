using DomainModel.Models;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;

namespace ExamTracker.Helpers
{
    internal class PdfHelper
    {
        private string InvoiceNumber;
        private string IssueDate;
        private string SellDate;
        private string PaymentDate;
        private string PaymentMethod;
        private string Seller;
        private string AccNumber;
        private string Buyer;
        private string Description;
        private string Quantity;
        private string UnitPrice;
        private string TotalGross;
        private string Remarks;
        private string EntitledPersonText;
        private string Owing;
        private string Net;
        private string Vat;
        private string Gross;
        private string IssuingPersonText;

        

        internal void CreatePdfInvoice(string filePath, Invoice invoice, List<ProductService> productServiceList)
        {
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    string fontPath = "C:/Windows/Fonts/times.ttf";
                    //PdfFont standard = PdfFontFactory.CreateFont(fontPath, PdfEncodings.IDENTITY_H);
                    PdfFont standard = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    PdfFont standard2 = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    PdfFont boldStandard = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                    

                    var document = new Document(pdf);

                    //ImageData logoImage = ImageDataFactory.Create("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\invoice_logo.png");

                    ImageData logoImage = ImageDataFactory.Create(ToByteArray(Properties.Resources.invoice_logo));

                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(logoImage);
                    
                    image.SetHorizontalAlignment(HorizontalAlignment.LEFT);
                    document.Add(image);
                    
                    Paragraph invNum = new Paragraph(new Text($"{InvoiceNumber} {invoice.InvoiceNumber}").SetBold().SetFontSize(12).SetFont(standard)).SetTextAlignment(TextAlignment.RIGHT);
                    Paragraph invIss = new Paragraph(new Text($"{IssueDate}\t{invoice.DateOfIssue}").SetFontSize(10).SetFont(standard)).SetTextAlignment(TextAlignment.RIGHT);

                    document.Add(invNum);
                    document.Add(invIss);

                    Table dates = new Table(UnitValue.CreatePercentArray(new float[] { 70,20,10 })).UseAllAvailableWidth();

                    dates.AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(SellDate)).SetTextAlignment(TextAlignment.LEFT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(invoice.DateOfSale.ToString())).SetTextAlignment(TextAlignment.RIGHT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));

                    dates.AddCell(new Cell().Add(new Paragraph(" ")).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(PaymentDate)).SetTextAlignment(TextAlignment.LEFT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(invoice.DateOfPayment.ToString())).SetTextAlignment(TextAlignment.RIGHT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));

                    dates.AddCell(new Cell().Add(new Paragraph("  ")).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(PaymentMethod)).SetTextAlignment(TextAlignment.LEFT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));
                    dates.AddCell(new Cell().Add(new Paragraph(invoice.PaymentMethod)).SetTextAlignment(TextAlignment.RIGHT).SetFont(standard).SetFontSize(10).SetBorder(Border.NO_BORDER));
                    
                    Paragraph space = new Paragraph("");

                    document.Add(dates);
                    document.Add(space);

                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();

                    Paragraph sellerInfo = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add("\n")
                        .Add(new Text($"{Seller}\n").SetFont(boldStandard))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5))
                        .Add($"\n{invoice.Seller}\n")
                        .Add($"{invoice.SellersAddress}\n")
                        .Add($"{AccNumber} {invoice.NumberOfAccount}");

                    Paragraph buyerInfo = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add("\n")
                        .Add(new Text($"{Buyer}\n").SetFont(boldStandard))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5))
                        .Add($"\n{invoice.Buyer}\n")
                        .Add($"{invoice.BuyersAddress}\n\n\n");


                    table.AddCell(new Cell().Add(buyerInfo).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(sellerInfo).SetBorder(Border.NO_BORDER));

                    table.AddCell(new Cell().Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5)).SetBorder(Border.NO_BORDER));

                    document.Add(table);
                    document.Add(new Paragraph());

                    Table soldGoodsAndServices = new Table(UnitValue.CreatePercentArray(new float[] { 10, 30, 20,20,20 })).UseAllAvailableWidth();
                    int counter = 1;
                    soldGoodsAndServices.AddHeaderCell("N0");
                    soldGoodsAndServices.AddHeaderCell(Description);
                    soldGoodsAndServices.AddHeaderCell(Quantity);
                    soldGoodsAndServices.AddHeaderCell(UnitPrice);
                    soldGoodsAndServices.AddHeaderCell(TotalGross);
                    foreach (ProductService ps in productServiceList)
                    {
                        soldGoodsAndServices.SetFont(standard);
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph(counter.ToString())));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph(ps.Description)));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph((ps.NumberOfItems).ToString())));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph($"{ps.UnitPrice/100:0.00}")));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph($"{ps.TotalGrossPrice/100:0.00}")));
                        counter++;
                    }
                    document.Add(soldGoodsAndServices);
                    document.Add(new Paragraph("\n\n"));

                    Table lowerInfoTable = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();
                    Paragraph remarks = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add(new Text($"{Remarks}\n").SetFont(boldStandard).SetFontSize(12))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\n{invoice.Remarks}\n\n"));

                    Paragraph owing = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add(new Text($"{Owing}: \n").SetFont(boldStandard).SetFontSize(12))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\n{Net}\t\t\t\t\t{invoice.TotalNet / 100:0.00} {invoice.Currency}.\n").SetTextAlignment(TextAlignment.LEFT))
                        .Add(new Text($"{Vat}\t\t\t\t\t0,00 {invoice.Currency} .\n").SetTextAlignment(TextAlignment.LEFT))
                        .Add(new Text($"{Gross}\t\t\t\t\t{invoice.TotalGross / 100:0.00} {invoice.Currency}.\n\n\n").SetTextAlignment(TextAlignment.LEFT));

                    lowerInfoTable.AddCell(new Cell().Add(remarks).SetBorder(Border.NO_BORDER));
                    lowerInfoTable.AddCell(new Cell().Add(owing).SetBorder(Border.NO_BORDER));

                    lowerInfoTable.AddCell(new Cell().Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5)).SetBorder(Border.NO_BORDER));
                    lowerInfoTable.AddCell(new Cell().Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(230).SetMarginTop(5).SetMarginBottom(5)).SetBorder(Border.NO_BORDER));
                    lowerInfoTable.AddCell(new Cell().Add(new Paragraph($"\n{EntitledPersonText}").SetFontSize(8)).SetBorder(Border.NO_BORDER)).SetMarginTop(0);
                    lowerInfoTable.AddCell(new Cell().Add(new Paragraph(new Text($"\n{IssuingPersonText}").SetFontSize(8))).SetBorder(Border.NO_BORDER)).SetMarginTop(0);

                    document.Add(lowerInfoTable);
                    document.Close();
                }
            }
            
        }

        private byte[] ToByteArray(System.Drawing.Image image)
        {
            using(MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, image.RawFormat);
                return memoryStream.ToArray();
            }
        }
        public PdfHelper()
        {
            if (LanguageHelper.Lang == "pl_pl")
            {
               InvoiceNumber = "Numer faktury";
               IssueDate = "Data wystawienia";
               SellDate = "Data sprzedaży";
               PaymentDate = "Data płatności";
               PaymentMethod = "Metoda płatności";
               Seller = "Sprzedawca";
               AccNumber = "Numer konta";
               Buyer = "Nabywca";
               Description = "Opis";
               Quantity = "Ilość";
               UnitPrice = "Cena jednostkowa";
               TotalGross = "Cena brutto";
               Remarks = "Uwagi";
               EntitledPersonText = "Imię i nazwisko osoby upoważnionej do niniejszego dokumentu";
               Owing = "Do zapłaty";
               Net = "Netto";
               Vat = "VAT";
               Gross = "Brutto";
               IssuingPersonText= "Imię i nazwisko osoby wystawiającej niniejszy dokument";
            }
            else if (LanguageHelper.Lang == "eng_us")
            {
                InvoiceNumber = "Invoice number";
                IssueDate = "Issue date";
                SellDate = "Sell date";
                PaymentDate = "Payment date";
                PaymentMethod = "Payment method";
                Seller = "Seller";
                AccNumber = "Account number";
                Buyer = "Buyer";
                Description = "Description";
                Quantity = "Quantity";
                UnitPrice = "Unit price";
                TotalGross = "Total gross";
                Remarks = "Remarks";
                EntitledPersonText = "Name and surname of a person entitled to the document";
                Owing = "Owing";
                Net = "Net";
                Vat = "VAT";
                Gross = "Gross";
                IssuingPersonText = "Name and surname of a person issuing the document";
            }
            else
            {
                return;
            }
        }
    }
}
       


    

