using DomainModel.Models;

namespace DataAcessLayer.Contracts;
public interface ISessionService
{
    Account CurrentAccount { get; set; }
    public string Language { get; set; }
}
