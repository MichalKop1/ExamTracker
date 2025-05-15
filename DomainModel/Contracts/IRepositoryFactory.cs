using DataAcessLayer.Contracts;

namespace DomainModel.Contracts;

public interface IRepositoryFactory
{
	IMaturaExamRepository CreateMaturaExamRepository();
	IGrade8ExamRepository CreateGrade8ExamRepository();
	IStudentRepository CreateStudentRepository();
	IAccountRepository CreateAccountRepository();
	IClientRepository CreateClientRepository();
	IEventRepository CreateEventRepository();
	IInvoiceRepository CreateInvoiceRepository();
	IProductServiceRepository CreateProductServiceRepository();
}
