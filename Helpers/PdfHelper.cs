using System;
using System.Windows.Forms;
using DomainModel.Models;
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
    internal static class PdfHelper
    {
        internal static void CreatePdfInvoice(string filePath, Invoice invoice, List<ProductService> productServiceList)
        {
            using (var writer = new PdfWriter(filePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    PdfFont standard = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                    PdfFont boldStandard = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                    

                    var document = new Document(pdf);

                    ImageData logoImage = ImageDataFactory.Create("C:\\Users\\Michal\\source\\repos\\ExamTracker_project\\ExamTracker\\Assets\\invoice_logo.png");
                    iText.Layout.Element.Image image = new iText.Layout.Element.Image(logoImage);
                    
                    image.SetHorizontalAlignment(HorizontalAlignment.LEFT);
                    document.Add(image);

                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();

                    // Create and add seller info paragraph
                    Paragraph sellerInfo = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add("\n")
                        .Add(new Text("Seller\n").SetFont(boldStandard))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(150).SetMarginTop(5).SetMarginBottom(5))
                        .Add($"\n{invoice.Seller}\n")
                        .Add($"{invoice.SellersAddress}\n")
                        .Add($"Number of account {invoice.NumberOfAccount}");

                    // Create and add buyer info paragraph
                    Paragraph buyerInfo = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add("\n")
                        .Add(new Text("Buyer\n").SetFont(boldStandard))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(150).SetMarginTop(5).SetMarginBottom(5))
                        .Add($"\n{invoice.Buyer}\n")
                        .Add($"{invoice.BuyersAddress}\n")
                        .Add($"");

                    

                    // Add paragraphs to the table cells
                    table.AddCell(new Cell().Add(buyerInfo).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(sellerInfo).SetBorder(Border.NO_BORDER));

                    // Add table to the document
                    document.Add(table);

                    Table soldGoodsAndServices = new Table(UnitValue.CreatePercentArray(new float[] { 10, 30, 20,20,20 })).UseAllAvailableWidth();
                    int counter = 1;
                    double totalPrice = 0;
                    soldGoodsAndServices.AddHeaderCell("N0");
                    soldGoodsAndServices.AddHeaderCell("Description");
                    soldGoodsAndServices.AddHeaderCell("Quantity");
                    soldGoodsAndServices.AddHeaderCell("Unit Price");
                    soldGoodsAndServices.AddHeaderCell("Total Gross");
                    foreach (ProductService ps in productServiceList)
                    {
                        soldGoodsAndServices.SetFont(standard);
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph(counter.ToString())));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph(ps.Description)));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph((ps.NumberOfItems).ToString())));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph($"{ps.UnitPrice:0.00}")));
                        soldGoodsAndServices.AddCell(new Cell().Add(new Paragraph($"{ps.TotalGrossPrice:0.00}")));
                        counter++;
                        totalPrice += ps.TotalGrossPrice;
                    }
                    document.Add(soldGoodsAndServices);
                    document.Add(new Paragraph("\n\n"));

                    Table lowerInfoTable = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();
                    Paragraph remarks = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add(new Text("Remarks\n").SetFont(boldStandard).SetFontSize(12))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(200).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\n{invoice.Remarks}\n"))
                        .Add(new Text($"{invoice.SellersAddress}\n"))
                        .Add(new Text($"{invoice.NumberOfAccount}\n\n\n"))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(150).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\nName and surname of a person entitled to the document").SetFontSize(8));

                    Paragraph owing = new Paragraph()
                        .SetFont(standard).SetFontSize(10)
                        .Add(new Text("Owing: \n").SetFont(boldStandard).SetFontSize(12))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(150).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\nNet  \t\t\t{totalPrice:0.00} {invoice.Currency} .\n").SetHorizontalAlignment(HorizontalAlignment.LEFT))
                        .Add(new Text($"VAT  \t\t\t0,00 {invoice.Currency} .\n").SetHorizontalAlignment(HorizontalAlignment.LEFT))
                        .Add(new Text($"Gross\t\t\t{totalPrice:0.00} {invoice.Currency} .\n\n\n").SetHorizontalAlignment(HorizontalAlignment.LEFT))
                        .Add(new LineSeparator(new SolidLine()).SetStrokeColor(ColorConstants.BLACK).SetWidth(150).SetMarginTop(5).SetMarginBottom(5))
                        .Add(new Text($"\nName and surname of a person issuing the document").SetFontSize(8));

                    lowerInfoTable.AddCell(new Cell().Add(remarks).SetBorder(Border.NO_BORDER));
                    lowerInfoTable.AddCell(new Cell().Add(owing).SetBorder(Border.NO_BORDER));
                    document.Add(lowerInfoTable);
                    // Close the document
                    document.Close();
                }
            }
            
            
        }
    }
}
       


    

