using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Contracts;

public interface IMessageService
{
	public void ShowError(string message);
}
