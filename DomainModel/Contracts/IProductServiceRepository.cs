using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IProductServiceRepository
{
    public List<ProductService> GetAllOrders();

    public List<ProductService> GetAllOrdersOfTheInvoice(int invoiceId);

    public Task InsertProductService(ProductService ps);
}
