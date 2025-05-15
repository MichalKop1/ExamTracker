using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Contracts;
using ExamTracker.Utilities;
using ExamTrackerTests.TestData;
using Moq;

namespace ExamTrackerTests.ApplicationTests
{
    [TestFixture]
    class ProfileControlTests
    {
        private Mock<IMessageService> _messageServiceMock;
        private ProfileControlUtilities _controlUtilities;

        [SetUp]
        public void SetUp()
        {
            _messageServiceMock = new Mock<IMessageService>();
        }

		[TestCaseSource(typeof(ProfileControlData), nameof(ProfileControlData.ValidUserData))]
		public void ValidateForm_CorrectDataProvided_ReturnsTrue(string phoneNumber, string zipCode,
            string email, bool expected)
        {
            // Arrange
            _messageServiceMock.Setup(x => x.ShowError("error"));
			_controlUtilities = new ProfileControlUtilities(_messageServiceMock.Object);

            // Act
            var actual = _controlUtilities.ValidateForm(phoneNumber, zipCode, email);

            // Assert
            //_messageServiceMock.Verify(func => func.ShowError("error"), Times.Once);
            Assert.That(actual, Is.EqualTo(expected));
		}

		[TestCaseSource(typeof(ProfileControlData), nameof(ProfileControlData.InvalidUserData))]
		public void ValidateForm_IncorrectDataProvided_ReturnsFalse(string phoneNumber, string zipCode,
			string email, bool expected)
		{
			// Arrange
			_messageServiceMock.Setup(x => x.ShowError("error"));
			_controlUtilities = new ProfileControlUtilities(_messageServiceMock.Object);

			// Act
			var actual = _controlUtilities.ValidateForm(phoneNumber, zipCode, email);

			// Assert
			//_messageServiceMock.Verify(func => func.ShowError("error"), Times.Once);
			Assert.That(actual, Is.EqualTo(expected));
		}
	}
}
