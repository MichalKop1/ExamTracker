using DomainModel.Models;

namespace DataAcessLayer.Contracts;

public interface IClientRepository
{
	public Task AddClient(Client client);
	public Task UpdateClient(Client client);
	public Task DeleteClient(Client client);
	public Task<Client> GetClient(int id);
	public Task<List<Client>> GetAllClients(string sellerId);
}
