using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    public interface IFindDateOfMonthCalculator
    {
        IFindInDateOfMonthCalculator In(Month month);
    }
}