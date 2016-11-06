using PublicHolidays.Au.Internal.Support;

namespace PublicHolidays.Au.Internal.Days
{
    internal interface IDay
    {
        State States { get; }
        Trait Traits { get; }
        string GetNameOfPublicHolidayIn(State state);
        IIn GetPublicHolidayDatesFor(State state);
    }
}