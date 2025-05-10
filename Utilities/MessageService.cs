using DomainModel.Contracts;

namespace ExamTracker.Utilities
{
	public class MessageService : IMessageService
	{
		public void ShowError(string message)
		{
			MessageBox.Show(message);
		}
	}
}
