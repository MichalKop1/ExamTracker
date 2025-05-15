using DomainModel.Models;

namespace DataAcessLayer.Contracts
{
    public interface IAccountRepository
    {
        public event Action<string> OnError;
        public Account logIn(string login);
        public int CheckForLoginDuplicates(string login);
        public Task registerAnAccount(Account account);
        public Task updateAnAccount(Account account); 
    }
}
