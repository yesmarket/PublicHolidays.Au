using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.DateOfMonthCalculator
{
    internal interface IFindDateOfMonthCalculator
    {
        IFindInDateOfMonthCalculator In(Month month);
    }
}