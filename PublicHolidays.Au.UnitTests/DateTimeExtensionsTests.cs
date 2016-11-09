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
    }
}
