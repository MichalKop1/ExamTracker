using ExamTracker.UI.MainAppControls;
using ExamTracker.UI;

namespace DomainModel.Contracts;

public interface IControlFactory
{
	AddStudents CreateAddStudents();
	StudentsControl CreateStudentsControl();
	ProfileControl CreateProfileControl();
	ScheduleControl CreateScheduleControl();
	BillingControl CreateBillingControl();
	ClientsControl CreateClientsControl();
}
