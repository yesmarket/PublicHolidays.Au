using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicHolidays.Au.Internal.Support;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.DefaultDateOfMonthCalculator
{
    public class DefaultDateOfMonthCalculatorTests
    {
        private readonly Au.Internal.DateOfMonthCalculator.DefaultDateOfMonthCalculator _defaultDateOfMonthCalculator;

        public DefaultDateOfMonthCalculatorTests()
        {
            _defaultDateOfMonthCalculator = new Au.Internal.DateOfMonthCalculator.DefaultDateOfMonthCalculator();
        }

        [Fact]
        public void For_WhenNthDayInMonthExists_ReturnsCorrectDate()
        {
            const int year = 2017;
            var result = _defaultDateOfMonthCalculator.Find(Ordinal.First, DayOfWeek.Monday).In(Month.November).For(year);
            result.ShouldBe(new DateTime(year, 11, 6));
        }

        [Fact]
        public void For_WhenNthDayInMonthDoesNotExist_ReturnsDayFromNextMonth()
        {
            const int year = 2017;
            var result = _defaultDateOfMonthCalculator.Find(Ordinal.Fifth, DayOfWeek.Monday).In(Month.November).For(year);
            result.ShouldBe(new DateTime(year, 12, 4));
        }
    }
}
