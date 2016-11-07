using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.PublicHolidays
{
    internal interface IPublicHoliday
    {
        State States { get; }
        Trait Traits { get; }
        string GetNameOfPublicHolidayIn(State state);
        IIn GetPublicHolidayDatesFor(State state);
    }
}