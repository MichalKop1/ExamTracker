namespace DomainModel.Models;
public class ProductService
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int NumberOfItems { get; set; }
    public double UnitPrice { get; set; }
    public double TotalGrossPrice { get; set; }
    public int UniqueId { get; set; }

    public ProductService(string description, int numberOfItems, double unitPrice, double totalGrossPrice, int uniqueId)
    {
        Description = description;
        NumberOfItems = numberOfItems;
        UnitPrice = unitPrice;
        TotalGrossPrice = totalGrossPrice;
        UniqueId = uniqueId;
    }
    public ProductService() { }
}
