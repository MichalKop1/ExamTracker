namespace DomainModel.Models;

public sealed class Base
{
	public required AddStudentsPage AddStudentsPage { get; set; }
	public required BillingControlPage BillingControlPage { get; set; }
	public required ClientsControlPage ClientsControlPage { get; set; }
	public required AddNewClientsWindow AddNewClientsWindow { get; set; }
	public required EditClientsWindow EditClientsWindow { get; set; }
	public required ProfileControlPage ProfileControlPage { get; set; }
	public required ScheduleControlPage ScheduleControlPage { get; set; }
	public required StudentsControlPage StudentsControlPage { get; set; }
	public required LoginControlPage LoginControlPage { get; set; }
	public required RegisterControlPage RegisterControlPage { get; set; }
	public required MainFormPage MainFormPage { get; set; }
	public required MainAppViewPage MainAppViewPage { get; set; }
	public required ErrorMessages ErrorMessages { get; set; }
}

public sealed class AddStudentsPage
{
	public required AddStudentsLabels Labels { get; set; }
	public required AddStudentsTextboxes Textboxes { get; set; }
	public required AddStudentsButtons Buttons { get; set; }
	public required AddStudentsRadioButtons RadioButtons { get; set; }
}

public sealed class AddStudentsLabels
{
	public required string AddStudentLabel { get; set; }
	public required string StudentNameLabel { get; set; }
	public required string StudentEmailLabel { get; set; }
	public required string StudentAgeLabel { get; set; }
}

public sealed class AddStudentsTextboxes
{
	public required string StudentEmailPlaceholder { get; set; }
	public required string StudentAgePlaceholder { get; set; }
}

public sealed class AddStudentsButtons
{
	public required string CancelButton { get; set; }
	public required string SubmitButton { get; set; }
}

public sealed class AddStudentsRadioButtons
{
	public required string Grade8RadioButton { get; set; }
	public required string MaturaRadioButton { get; set; }
}

public sealed class BillingControlPage
{
	public required BillingLabels Labels { get; set; }
	public required BillingTextboxes Textboxes { get; set; }
	public required BillingButtons Buttons { get; set; }
	public required BillingColumnHeader ColumnHeader { get; set; }
}

public sealed class BillingLabels
{
	public required string InvoiceListLabel { get; set; }
	public required string InvoiceLabel { get; set; }
	public required string CreateInvoiceLabel { get; set; }
	public required string DescriptionLabel { get; set; }
	public required string UnitPriceLabel { get; set; }
	public required string QuantityLabel { get; set; }
}

public sealed class BillingTextboxes
{
	public required string DateOfSalePlaceholder { get; set; }
	public required string DateOfPaymentPlaceholder { get; set; }
}

public sealed class BillingButtons
{
	public required string AddItemButton { get; set; }
	public required string AddInvoiceButton { get; set; }
}

public sealed class BillingColumnHeader
{
	public required string InvoiceNumberHeader { get; set; }
	public required string IsPaidHeader { get; set; }
	public required string ClientHeader { get; set; }
}

public sealed class ClientsControlPage
{
	public required ClientsControlLabels Labels { get; set; }
	public required ClientsControlButtons Buttons { get; set; }
	public required ClientsControlColumnHeader ColumnHeader { get; set; }
}

public sealed class ClientsControlLabels
{
	public required string ClientsLabel { get; set; }
}

public sealed class ClientsControlButtons
{
	public required string AddClientButton { get; set; }
	public required string EditStripButton { get; set; }
	public required string DeleteStripButton { get; set; }
	public required string CancelStripButton { get; set; }
}

public sealed class ClientsControlColumnHeader
{
	public required string InvoiceNumberHeader { get; set; }
	public required string IsPaidHeader { get; set; }
	public required string ClientHeader { get; set; }
}

public sealed class AddNewClientsWindow
{
	public required AddNewClientsLabels Labels { get; set; }
	public required AddNewClientsButtons Buttons { get; set; }
}

public sealed class AddNewClientsLabels
{
	public required string CompanyNameLabel { get; set; }
	public required string NipLabel { get; set; }
	public required string Address1Label { get; set; }
	public required string Address2Label { get; set; }
}

public sealed class AddNewClientsButtons
{
	public required string AddButton { get; set; }
	public required string CancelButton { get; set; }
}

public sealed class EditClientsWindow
{
	public required EditClientsLabels Labels { get; set; }
	public required EditClientsButtons Buttons { get; set; }
}

public sealed class EditClientsLabels
{
	public required string CompanyNameLabel { get; set; }
	public required string NipLabel { get; set; }
	public required string Address1Label { get; set; }
	public required string Address2Label { get; set; }
}

public sealed class EditClientsButtons
{
	public required string UpdateButton { get; set; }
	public required string CancelButton { get; set; }
}

public sealed class ProfileControlPage
{
	public required ProfileControlLabels Labels { get; set; }
	public required ProfileControlTextboxes Textboxes { get; set; }
	public required ProfileControlButtons Buttons { get; set; }
}

public sealed class ProfileControlLabels
{
	public required string ProfileLabel { get; set; }
	public required string ManageInfoLabel { get; set; }
	public required string BusinessInfoLabel { get; set; }
	public required string BusinessNameLabel { get; set; }
	public required string StreetAddressLabel { get; set; }
	public required string CityLabel { get; set; }
	public required string StateLabel { get; set; }
	public required string ZipCodeLabel { get; set; }
	public required string ContactInfoLabel { get; set; }
	public required string ContactNameLabel { get; set; }
	public required string PhoneLabel { get; set; }
}

public sealed class ProfileControlTextboxes
{
	public required string BusinessNamePlaceholder { get; set; }
	public required string CityPlaceholder { get; set; }
	public required string StatePlaceholder { get; set; }
	public required string ZipCodePlaceholder { get; set; }
	public required string ContactNamePlaceholder { get; set; }
	public required string EmailPlaceholder { get; set; }
	public required string PhonePlaceholder { get; set; }
}

public sealed class ProfileControlButtons
{
	public required string SaveChangesButton { get; set; }
}

public sealed class ScheduleControlPage
{
	public required ScheduleControlLabels Labels { get; set; }
	public required ScheduleControlTextboxes Textboxes { get; set; }
	public required ScheduleControlButtons Buttons { get; set; }
	public required ScheduleControlRadioButtons RadioButtons { get; set; }
}

public sealed class ScheduleControlLabels
{
	public required string CurrentScheduleLabel { get; set; }
}

public sealed class ScheduleControlTextboxes
{
	public required string ShortDescriptionTextBox { get; set; }
}

public sealed class ScheduleControlButtons
{
	public required string AddEventButton { get; set; }
}

public sealed class ScheduleControlRadioButtons
{
	public required string ExamRadioButton { get; set; }
	public required string MeetingRadioButton { get; set; }
}

public sealed class StudentsControlPage
{
	public required StudentsControlLabels Labels { get; set; }
	public required StudentsControlTextboxes Textboxes { get; set; }
	public required StudentsControlButtons Buttons { get; set; }
}

public sealed class StudentsControlLabels
{
	public required string StudentNameLabel { get; set; }
	public required string StudentLabel { get; set; }
	public required string TableDescLabel { get; set; }
}

public sealed class StudentsControlTextboxes
{
	public required string EditStudentAgePlaceholder { get; set; }
	public required string EditStudentNamePlaceholder { get; set; }
	public required string EditStudentSurnamePlaceholder { get; set; }
	public required string Task1Placeholder { get; set; }
	public required string Task2Placeholder { get; set; }
	public required string Task3Placeholder { get; set; }
	public required string Task4Placeholder { get; set; }
	public required string Task5Placeholder { get; set; }
	public required string Task6Placeholder { get; set; }
	public required string Task7Placeholder { get; set; }
	public required string Task8Placeholder { get; set; }
	public required string Task9Placeholder { get; set; }
	public required string Task10Placeholder { get; set; }
	public required string Task11Placeholder { get; set; }
	public required string Task12Placeholder { get; set; }
	public required string Task13Placeholder { get; set; }
	public required string Task14Placeholder { get; set; }
}

public sealed class StudentsControlButtons
{
	public required string SubmitButton { get; set; }
	public required string EditButton { get; set; }
	public required string ConfirmButton { get; set; }
}

public sealed class LoginControlPage
{
	public required LoginControlTextboxes Textboxes { get; set; }
	public required LoginControlButtons Buttons { get; set; }
}

public sealed class LoginControlTextboxes
{
	public required string LoginPlaceholder { get; set; }
	public required string PasswordPlaceholder { get; set; }
}

public sealed class LoginControlButtons
{
	public required string LoginButton { get; set; }
}

public sealed class RegisterControlPage
{
	public required RegisterControlTextboxes Textboxes { get; set; }
	public required RegisterControlButtons Buttons { get; set; }
}

public sealed class RegisterControlTextboxes
{
	public required string NamePlaceholder { get; set; }
	public required string SurnamePlaceholder { get; set; }
	public required string LoginPlaceholder { get; set; }
	public required string Password1Placeholder { get; set; }
	public required string Password2Placeholder { get; set; }
}

public sealed class RegisterControlButtons
{
	public required string RegisterButton { get; set; }
}

public sealed class MainFormPage
{
	public required MainFormLabels Labels { get; set; }
	public required MainFormTextboxes Textboxes { get; set; }
	public required MainFormButtons Buttons { get; set; }
}

public sealed class MainFormLabels
{
	public required string NewsletterLabel { get; set; }
}

public sealed class MainFormTextboxes
{
	public required string NamePlaceholder { get; set; }
	public required string SurnamePlaceholder { get; set; }
	public required string LoginPlaceholder { get; set; }
	public required string Password1Placeholder { get; set; }
	public required string Password2Placeholder { get; set; }
}

public sealed class MainFormButtons
{
	public required string LoginButton { get; set; }
	public required string RegisterButton { get; set; }
	public required string GetStartedButton { get; set; }
}

public sealed class MainAppViewPage
{
	public required MainAppViewLabels Labels { get; set; }
	public required MainAppViewButtons Buttons { get; set; }
}

public sealed class MainAppViewLabels
{
	public required string FormTitle { get; set; }
}

public sealed class MainAppViewButtons
{
	public required string DashboardButton { get; set; }
	public required string StudentsButton { get; set; }
	public required string ScheduleButton { get; set; }
	public required string BillingButton { get; set; }
	public required string BusinessButton { get; set; }
	public required string ProfileButton { get; set; }
	public required string ClientsControlButton { get; set; }
	public required string LogoutButton { get; set; }
}

public sealed class ErrorMessages
{
	public required string FormErrorHeader { get; set; }
	public required string InvoiceErrorHeader { get; set; }
	public required string StudentNameIsEmptyError {  get; set; }
	public required string StudentNameContainsNumbersError { get; set; }
	public required string StudentNameIsNotFullError { get; set; }
	public required string EmailIsEmptyError { get; set; }
	public required string InvalidEmailError { get; set; }
	public required string AgeIsEmptyError { get; set; }
	public required string InvalidAgeNotNumber {  get; set; }
	public required string InvalidAge {  get; set; }
	public required string StudentExamTypeNotChecked { get; set; }
	public required string DateOfSaleMissingError { get; set; }
	public required string DateOfSaleInvalidError { get; set; }
	public required string DateOfPayementMissingError { get; set; }
	public required string DateOfPaymentInvalid { get; set; }
	public required string NoProductsAddedError { get; set; }
	public required string NoEventNameError { get; set; }
	public required string EventTypeNotSelected { get; set; }
	public required string ExamPointsBoxesEmpty { get; set; }
	public required string ExamBoxesInvalidInput { get; set; }
	public required string CompanyNameEmpty { get; set; }
	public required string TaxNumberEmpty { get; set; }
	public required string CompanyAddressEmpty { get; set; }
	public required string UserNameEmpty { get; set; }
	public required string ZipCodeEmpty { get; set; }
	public required string ZipCodeInvalid { get; set; }
	public required string PhoneNumberEmpty { get; set; }
	public required string PhoneNumberInvalid { get; set; }
}