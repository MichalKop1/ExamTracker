using DataAcessLayer.Contracts;
using DomainModel.Models;

namespace DataAcessLayer.Repositories;

public  class SessionService : ISessionService
{
    public Account CurrentAccount { get; set; } = new Account();
    public string Language { get; set; } = "";
}
