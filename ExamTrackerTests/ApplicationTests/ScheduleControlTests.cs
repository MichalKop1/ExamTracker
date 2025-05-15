using DomainModel.Contracts;
using ExamTracker.Utilities;
using ExamTrackerTests.TestData;
using Moq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTrackerTests.ApplicationTests
{
	[TestFixture]
	public class ScheduleControlTests
	{
		private Mock<IMessageService> _messageServiceMock;
		private ScheduleControlUtilities _controlUtilities;

		[SetUp]
		public void SetUp()
		{
			_messageServiceMock = new Mock<IMessageService>();
			_controlUtilities = new ScheduleControlUtilities(_messageServiceMock.Object);
		}


		[TestCaseSource(typeof(ScheduleControlData), nameof(ScheduleControlData.ValidEventData))]
		public void ValidateForm_AllDataCorrect_ReturnsTrue(string eventName, bool isMeeting, bool isExam, MonthCalendar calendar)
		{
			// Arrange

			
			// Act
			bool actual = _controlUtilities.ValidateForm(eventName, isExam, isMeeting, calendar);


			// Assert
			Assert.That(actual, Is.True);
		}

		[TestCaseSource(typeof(ScheduleControlData), nameof(ScheduleControlData.InvalidEventData))]
		public void ValidateForm_DataContainsError_ReturnsFalse(string eventName, bool isMeeting, bool isExam, MonthCalendar calendar)
		{
			// Arrange


			// Act
			bool actual = _controlUtilities.ValidateForm(eventName, isExam, isMeeting, calendar);


			// Assert
			Assert.That(actual, Is.False);
		}

		[TestCaseSource(typeof(ScheduleControlData), nameof(ScheduleControlData.EventDataWithNull))]
		public void ValidateForm_DataContainsNull_ThrowsException(string eventName, bool isMeeting, bool isExam, MonthCalendar calendar)
		{
			Assert.Throws<ArgumentNullException>(() =>
				_controlUtilities.ValidateForm(eventName, isExam, isMeeting, calendar));
		}
	}
}
