using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTrackerTests.TestData
{
	public static class ScheduleControlData
	{
		public static IEnumerable<object[]> ValidEventData()
		{
			yield return new object[] { "test event name", false, true, new MonthCalendar() };
			yield return new object[] { "testing", true, false, new MonthCalendar() };
		}

		public static IEnumerable<object[]> InvalidEventData()
		{
			yield return new object[] { "", false, true, new MonthCalendar() };
			yield return new object[] { "", true, false, new MonthCalendar() };
			yield return new object[] { "test event name", false, false, new MonthCalendar() };
			yield return new object[] { "", false, false, new MonthCalendar() };
		}

		public static IEnumerable<object> EventDataWithNull()
		{
			yield return new object[] { null, false, true, new MonthCalendar() };
		}
	}
}
