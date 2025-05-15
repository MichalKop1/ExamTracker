using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IInvoiceRepository
{
    public Invoice GetInvoice(int id);

    public Task InsertInvoice(Invoice invoice);

    public Task<List<Invoice>> GetAllInvoicesOfAnAccount(int accId);
}
