using ExamTracker.Helpers;
using ExamTracker.Utilities;


namespace ExamTrackerTests.ApplicationTests;

[TestFixture]
public class MainFormTests
{
	private MainFormUtilities _mainFormUtilities;


	[SetUp]
	public void Setup()
	{
		_mainFormUtilities = new();

	}

	[TestCase(Language.Polish_Pl)]
	public void UpdateConfigFileLanguage_ConfigIsUpdated(Language language)
	{
		// Arrange
		string pathToConfig = Path.Join(AppContext.BaseDirectory, "appsettings.json");
		string actual = File.ReadAllText(pathToConfig);

		// Act
		_mainFormUtilities.UpdateConfigFileLanguage(language);

		string expected = File.ReadAllText(pathToConfig);
		_mainFormUtilities.UpdateConfigFileLanguage(Language.English_Us); //reset changes

		// Assert
		Assert.That(actual, Is.Not.EqualTo(expected));
	}


	[TearDown]
	public void TearDown() 
	{ 
		_mainFormUtilities?.Dispose();
	}
}
