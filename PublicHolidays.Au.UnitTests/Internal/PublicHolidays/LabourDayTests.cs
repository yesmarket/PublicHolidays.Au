using System;
using PublicHolidays.Au.Internal.PublicHolidays;
using Shouldly;
using Xunit;

namespace PublicHolidays.Au.UnitTests.Internal.PublicHolidays
{
    public class LabourDayTests
    {
        const int Year = 2017;
        private readonly LabourDay _labourDay;

        public LabourDayTests()
        {
            _labourDay = new LabourDay();
        }

        [Fact]
        public void InWA_2017_ReturnsDateOfFirstMondayInMarch()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.WA).In(Year);
            result.ShouldContain(new DateTime(Year, 3, 6));
        }

        [Fact]
        public void InTAS_2017_ReturnsDateOfSecondMondayInMarch()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.TAS).In(Year);
            result.ShouldContain(new DateTime(Year, 3, 13));
        }

        [Fact]
        public void InVIC_2017_ReturnsDateOfSecondMondayInMarch()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.VIC).In(Year);
            result.ShouldContain(new DateTime(Year, 3, 13));
        }

        [Fact]
        public void InQLD_2017_ReturnsDateOfFirstMondayInMay()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.QLD).In(Year);
            result.ShouldContain(new DateTime(Year, 5, 1));
        }

        [Fact]
        public void InNT_2017_ReturnsDateOfFirstMondayInMay()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.NT).In(Year);
            result.ShouldContain(new DateTime(Year, 5, 1));
        }

        [Fact]
        public void InNSW_2017_ReturnsDateOfFirstMondayInOctober()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.NSW).In(Year);
            result.ShouldContain(new DateTime(Year, 10, 2));
        }

        [Fact]
        public void InACT_2017_ReturnsDateOfFirstMondayInOctober()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.ACT).In(Year);
            result.ShouldContain(new DateTime(Year, 10, 2));
        }

        [Fact]
        public void InSA_2017_ReturnsDateOfFirstMondayInOctober()
        {
            var result = _labourDay.GetPublicHolidayDatesFor(State.SA).In(Year);
            result.ShouldContain(new DateTime(Year, 10, 2));
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NT_ReturnsCorrectName()
        {
            var name = _labourDay.GetNameOfPublicHolidayIn(State.NT);
            name.ShouldBe("May Day");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_TAS_ReturnsCorrectName()
        {
            var name = _labourDay.GetNameOfPublicHolidayIn(State.TAS);
            name.ShouldBe("Eight Hours Day");
        }

        [Fact]
        public void GetNameOfPublicHolidayIn_NeitherNTNorTAS_ReturnsCorrectName()
        {
            var name = _labourDay.GetNameOfPublicHolidayIn(State.National);
            name.ShouldBe("Labour Day");
        }
    }
}