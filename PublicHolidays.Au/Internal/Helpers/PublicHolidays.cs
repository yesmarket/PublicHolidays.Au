using System;
using System.Collections.Generic;
using System.Linq;
using PublicHolidays.Au.Internal.PublicHolidays;

namespace PublicHolidays.Au.Internal.Helpers
{
    internal sealed class PublicHolidays
    {
        private static readonly Lazy<PublicHolidays> Instance = new Lazy<PublicHolidays>(() => new PublicHolidays());

        private readonly List<IPublicHoliday> _publicHolidays;

        private PublicHolidays()
        {
            var type = typeof (IPublicHoliday);
            _publicHolidays = type.Assembly.GetTypes()
                .Where(_ => type.IsAssignableFrom(_) && !_.IsInterface)
                .Select(_ => (IPublicHoliday) Activator.CreateInstance(_))
                .ToList();
        }

        public static PublicHolidays Get => Instance.Value;
        public IEnumerable<IPublicHoliday> All => _publicHolidays;
    }
}