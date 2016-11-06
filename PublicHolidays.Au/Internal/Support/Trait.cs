using System;

namespace PublicHolidays.Au.Internal.Support
{
    [Flags]
    internal enum Trait
    {
        AllPostcodes = 1,
        MostPostcodes = 2,
        NotAllPostcodes = 4,
        IndustrySpecific = 8
    }
}