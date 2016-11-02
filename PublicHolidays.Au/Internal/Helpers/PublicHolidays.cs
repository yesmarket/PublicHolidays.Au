using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.Days;

namespace PublicHolidays.Au.Internal.Helpers
{
    internal sealed class PublicHolidays
    {
        private static readonly Lazy<PublicHolidays> Instance = new Lazy<PublicHolidays>(() => new PublicHolidays());

        private readonly List<IDay> _publicHolidays;

        private PublicHolidays()
        {
            var type = typeof (IDay);
            _publicHolidays = type.Assembly.GetTypes()
                .Where(_ => type.IsAssignableFrom(_) && !_.IsInterface)
                .Select(_ => (IDay) Activator.CreateInstance(_))
                .ToList();
        }

        public static PublicHolidays Get => Instance.Value;
        public IEnumerable<IDay> All => _publicHolidays;
    }
}