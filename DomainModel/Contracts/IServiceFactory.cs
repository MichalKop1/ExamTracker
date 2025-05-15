using DataAcessLayer.Contracts;

namespace DomainModel.Contracts;

public interface IServiceFactory
{
	ISessionService CreateSessionService();
	ICacheService CreateCacheService();
}
