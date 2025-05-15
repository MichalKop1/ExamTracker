using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ExamTracker.Factories;

public class RepositoryFactory : IRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public RepositoryFactory(IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));


    public IAccountRepository CreateAccountRepository()
    {
        return _serviceProvider.GetRequiredService<IAccountRepository>();
    }

    public IClientRepository CreateClientRepository()
    {
        return _serviceProvider.GetRequiredService<IClientRepository>();
    }

    public IEventRepository CreateEventRepository()
    {
        return _serviceProvider.GetRequiredService<IEventRepository>();
    }

    public IGrade8ExamRepository CreateGrade8ExamRepository()
    {
        return _serviceProvider.GetRequiredService<IGrade8ExamRepository>();
    }

    public IInvoiceRepository CreateInvoiceRepository()
    {
        return _serviceProvider.GetRequiredService<IInvoiceRepository>();
    }

    public IMaturaExamRepository CreateMaturaExamRepository()
    {
        return _serviceProvider.GetRequiredService<IMaturaExamRepository>();
    }

    public IProductServiceRepository CreateProductServiceRepository()
    {
        return _serviceProvider.GetRequiredService<IProductServiceRepository>();
    }

    public IStudentRepository CreateStudentRepository()
    {
        return _serviceProvider.GetRequiredService<IStudentRepository>();
    }
}
