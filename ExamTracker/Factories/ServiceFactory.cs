using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ExamTracker.Factories;

public class ServiceFactory : IServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceFactory(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public ICacheService CreateCacheService()
    {
        return _serviceProvider.GetRequiredService<ICacheService>();
    }

    public ISessionService CreateSessionService()
    {
        return _serviceProvider.GetRequiredService<ISessionService>();
    }
}
