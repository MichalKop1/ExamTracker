using DomainModel.Contracts;
using ExamTracker.UI;
using ExamTracker.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamTracker.Factories;

public class FormFactory : IFormFactory
{
	private readonly IServiceProvider _serviceProvider;

	public FormFactory(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider
			?? throw new ArgumentNullException(nameof(serviceProvider));
	}

	public MainAppView CreateMainAppView()
	{
		return new MainAppView(
			_serviceProvider.GetRequiredService<MainForm>(),
			_serviceProvider.GetRequiredService<IControlFactory>(),
			_serviceProvider.GetRequiredService<IServiceFactory>(),
			_serviceProvider.GetRequiredService<IRepositoryFactory>());
	}
}
