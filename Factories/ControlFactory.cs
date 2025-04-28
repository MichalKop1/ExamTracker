using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using ExamTracker.UI.MainAppControls;
using ExamTracker.UI;
using Microsoft.Extensions.DependencyInjection;

namespace ExamTracker.Factories;

public class ControlFactory : IControlFactory
{
	private readonly IServiceProvider _serviceProvider;

	public ControlFactory(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider 
			?? throw new ArgumentNullException(nameof(serviceProvider));
	}

	public AddStudents CreateAddStudents()
	{
		return new AddStudents(
			_serviceProvider.GetRequiredService<IStudentRepository>(),
			_serviceProvider.GetRequiredService<ISessionService>());
	}

	public StudentsControl CreateStudentsControl()
	{
		return new StudentsControl(
			_serviceProvider.GetRequiredService<IStudentRepository>(),
			_serviceProvider.GetRequiredService<IMaturaExamRepository>(),
			_serviceProvider.GetRequiredService<IGrade8ExamRepository>(),
			_serviceProvider.GetRequiredService<ISessionService>());
	}

	public ProfileControl CreateProfileControl()
	{
		return new ProfileControl(
			_serviceProvider.GetRequiredService<IAccountRepository>(),
			_serviceProvider.GetRequiredService<ISessionService>());
	}

	public ScheduleControl CreateScheduleControl()
	{
		return new ScheduleControl(
			_serviceProvider.GetRequiredService<IEventRepository>(),
			_serviceProvider.GetRequiredService<ISessionService>());
	}

	public BillingControl CreateBillingControl()
	{
		return new BillingControl(
			_serviceProvider.GetRequiredService<IInvoiceRepository>(),
			_serviceProvider.GetRequiredService<IProductServiceRepository>(),
			_serviceProvider.GetRequiredService<ISessionService>(),
			_serviceProvider.GetRequiredService<IClientRepository>());
	}

	public ClientsControl CreateClientsControl()
	{
		return new ClientsControl(
			_serviceProvider.GetRequiredService<ISessionService>(),
			_serviceProvider.GetRequiredService<IClientRepository>());
	}
}
