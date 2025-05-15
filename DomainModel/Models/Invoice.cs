namespace DomainModel.Models;
public class Invoice
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; }
    public string DateOfIssue { get; set; }
    public string DateOfSale { get; set; }
    public string DateOfPayment { get; set; }
    public string PaymentMethod { get; set; }
    public string Buyer { get; set; }
    public string BuyersAddress { get; set; }
    public string Seller { get; set; }
    public string SellersAddress { get; set; }
    public string NumberOfAccount { get; set; }
    public string Currency { get; set; }
    public string Remarks { get; set; }
    public int TotalGross { get; set; }
    public int TotalNet { get; set; }
    public int AccountId { get; set; }
    public int UniqueIdentifier { get; set; }

    public Invoice(string invoiceNumber, string dateOfIssue, string dateOfSale, string dateOfPayment,
        string paymentMethod, string buyer, string buyersAddress, string seller, string sellersAddress,
        string numberOfAccount, string currency, string remarks, int totalGross, int totalNet, int accountId, int uniqueIdentifier)
    {
        InvoiceNumber = invoiceNumber;
        DateOfIssue = dateOfIssue;
        DateOfSale = dateOfSale;
        DateOfPayment = dateOfPayment;
        PaymentMethod = paymentMethod;
        Buyer = buyer;
        BuyersAddress = buyersAddress;
        Seller = seller;
        SellersAddress = sellersAddress;
        NumberOfAccount = numberOfAccount;
        Currency = currency;
        Remarks = remarks;
        TotalGross = totalGross;
        TotalNet = totalNet;
        AccountId = accountId;
        UniqueIdentifier = uniqueIdentifier;
    }
    public Invoice() { }
}
