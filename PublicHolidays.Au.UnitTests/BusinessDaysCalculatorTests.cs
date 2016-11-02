using System;
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
            _sut = new BusinessDaysCalculator();
            var addBusinessDays = _sut.In(State.SA).StartingFrom(DateTime.Today).AddBusinessDays(5);
            addBusinessDays.ShouldBe(new DateTime());
        }
    }
}
