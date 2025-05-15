using DataAcessLayer.Contracts;
using DomainModel.Contracts;
using ExamTracker.Utilities;
using Moq;

namespace ExamTrackerTests.ApplicationTests;

public class RegisterControlTests
{
    private RegisterPageUtilities _registerPageUtilities;
    private Mock<IAccountRepository> _accountRepositoryMock;
    private Mock<IMessageService> _messageServiceMock;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
        _messageServiceMock = new Mock<IMessageService>();
		
	}

    [TestCase("samplename", "samplesurname", "samplelogin", "sampleemail@gmail.com", "password1", "password1", true)]
    public void ValidateRegisterForm_AllInformationIsCorrect_ReturnsTrue(string name, string surname, string login, string email, string pass1, string pass2, bool expected)
    {
        _accountRepositoryMock.Setup(x => x.CheckForLoginDuplicates(login)).Returns(1);
		_registerPageUtilities = new RegisterPageUtilities(_accountRepositoryMock.Object, _messageServiceMock.Object);

		var actual = _registerPageUtilities.ValidateRegistrationForm(
            name,
            surname,
            login,
            email,
            pass1,
            pass2);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("samplename", "", "samplelogin", "sampleemail@gmail.com", "password1", "password1", false)]
    public void ValidateRegisterForm_FormContainsAnError_ReturnsFalse(string name, string surname, string login, string email, string pass1, string pass2, bool expected)
    {
        var actual = _registerPageUtilities.ValidateRegistrationForm(
            name,
            surname,
            login,
            email,
            pass1,
            pass2);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
