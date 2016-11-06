using System;
using System.Globalization;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests
{
    public class BusinessDaysCalculatorTests
    {
        private BusinessDaysCalculator _sut;

        [Fact]
        public void Test()
        {
            var dayOfWeek1 = GetIso8601WeekOfYear(new DateTime(2016, 10, 1));
            var dayOfWeek2 = GetIso8601WeekOfYear(new DateTime(2015, 10, 3));
            var dayOfWeek3 = GetIso8601WeekOfYear(new DateTime(2015, 9, 27));

            _sut = new BusinessDaysCalculator();
            var addBusinessDays = _sut.In(State.SA).StartingFrom(DateTime.Today).AddBusinessDays(5);
            addBusinessDays.ShouldBe(new DateTime());
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
