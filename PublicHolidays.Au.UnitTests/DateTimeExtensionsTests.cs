using System;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void AddBusinessDays_AddBusinessDaysToDateTimeToday_FutureDateReturned()
        {
            var addBusinessDays = DateTime.Today.AddBusinessDays(2);
            addBusinessDays.ShouldBeGreaterThan(DateTime.Today);
        }

        [Fact]
        public void AddBusinessDays_OneBusinessDaysFromFriday_ShouldReturnFollowingTuesday()
        {
            var addBusinessDays = new DateTime(2016, 09, 30).AddBusinessDays(1, State.SA);
            addBusinessDays.ShouldBe(new DateTime(2016, 10, 4));
        }

        [Fact]
        public void AddBusinessDays_ZeroBusinessDaysFromSaturday_ShouldReturnFollowingMonday()
        {
            var addBusinessDays = new DateTime(2017, 04, 22).AddBusinessDays(0);
            addBusinessDays.ShouldBe(new DateTime(2017, 04, 24));
        }

        [Fact]
        public void Test()
        {
            var year = DateTime.Today.Year;
            for (var i = year; i < year + 10; i++)
            {
                for (var date = new DateTime(i, 1, 1); date < new DateTime(i + 1, 1, 1); date = date.AddDays(1))
                {
                    for (var j = 0; j < 10; j++)
                    {
                        date.AddBusinessDays(j);
                    }
                }
            }

            Assert.True(true);
        }


        [Fact]
        public void IsPublicHoliday_AnzacDay2017_ReturnsTrue()
        {
            var isPublicHoliday = new DateTime(2017, 4, 25).IsPublicHoliday();
            isPublicHoliday.ShouldBe(true);
        }

        [Fact]
        public void IsPublicHoliday_DayAfterAnzacDay2017_ReturnsFalse()
        {
            var isPublicHoliday = new DateTime(2017, 4, 26).IsPublicHoliday();
            isPublicHoliday.ShouldBe(false);
        }
    }
}
