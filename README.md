# PublicHolidays.Au

## Overview

The need for this library came from a business requirement to calculate a date, X number of business days into the future including public holidays.

Traditional approaches to this solving this problem might be a) storing public holidays in a database or configuration file and then reading this information at runtime, b) use of a third party service. Some of the negatives associated to this type of approaches include:
* Accessing a database, configuration file, or third party service is slow.
* Someone needs to remember to update the public holiday data every year.
* Implementing the public holiday business logic is additional code that needs to written and maintained.  
* There is always a chance for data errors.

Looking at the list of Australian public holiday dates, it's soon clear that the date of most of them can be consistently deduced. An application-library/utility to solve this problem is absolutely possible, albiet with a few minor considerations outlined in the next section.

## Exclusions

The calculations for most Australian public holidays is pretty straight forward. However, there are a few cases that need special mention:

* Partial public holidays are not taken into consideration e.g. Chrismas Eve.
* Public holidays that are not observed in *most*\* areas/postcodes within a state are excluded e.g. Royal Queensland Show in QLD & other regional public holidays.
* Public holidays where the date cannot be consistently deduced have not been implemented e.g. Grand final Eve in VIC & Family & Community Day in ACT.
* Public holidays that only apply to specific industries are excluded e.g. Bank Holiday in NSW.

\* A public holiday that is *inclusive* of particluar city/town/postcode should be excluded e.g. Royal Queensland Show in QLD. Alternativly a public holiday that is *exclusive* of particluar city/town/postcode should be included e.g. The Melbourne Cup in VIC where some regions observe the holiday on a differnet day corresponding with their own local racing carnival.

## List of Public Holidays
| Holiday | State | Calculation |
| :--- | :--- | :--- |
| New Years Day | National | 1 January - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Australia Day | National | 26 January - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Labour Day | WA | 1st Monday in March. |
| Canberra Day | ACT | 2nd Monday in March. |
| Labour Day* | TAS, VIC | 2nd Monday in March. |
| March public holiday | SA | 2nd Monday in March (currently proclaimed until 2019). |
| Good Friday | National | Varies according to the lunar cycle. |
| Easter Saturday | ACT, NSW, NT, QLD, SA, VIC | Varies according to the lunar cycle. |
| Easter Sunday | ACT, NSW, VIC | Varies according to the lunar cycle. |
| Easter Monday | National | Varies according to the lunar cycle. |
| Easter Tuesday | TAS | Varies according to the lunar cycle. |
| Anzac Day | National | 25 April - if the date falls on a Saturday, the public holiday is observed on that Saturday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Labour Day* | NT, QLD | 1st Monday in May. |
| Western Australia Day | WA | 1st Monday in June. |
| Queen's Birthday | ACT, NSW, NT, SA, TAS, VIC | 2nd Monday in June. |
| Picnic Day | NT | 1st Monday in August. |
| Family & Community Day | ACT | 1st Monday of 3rd term school holidays. |
| Queen's Birthday** | WA | Last Monday in September, or 1st Monday in October (when the last day in September falls on a weekend). |
| Grand Final Eve| VIC | Last Friday in September, or 1st Friday in October. |
| Queen's Birthday | QLD | 1st Monday in October. |
| Labour Day* | ACT, NSW, SA | 1st Monday in October. |
| Melbourne Cup Day | VIC | 1st Tuesday in November. |
| Christmas Day  | National | 25 December - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday that day and the following Monday will be public holidays. |
| Boxing Day*** | National | 26 December - if that date falls on a Saturday the public holiday transfers to the following Monday. If that date falls on a Sunday or a Monday that day and the following Tuesday will be public holidays. |

\* Known as May Day in NT and Eight Hours Day in TAS.<br />
\*\* Also known as Volunteer's Day in SA.<br />
\*\*\* Known as Proclamation Day in SA.

## Solution
Solution is comprised of 2 projects:
* PublicHolidays.Au is the main class-library/utility.
* PublicHolidays.Au.UnitTests contains the unit tests for PublicHolidays.Au

## Usage
Use Nuget:
```
PM> Install-Package PublicHolidays.Au
```

## Code
Most of the functionality is accessible via DateTime extension methods for example:
```c#
var dateTime = DateTime.Now.AddBusinessDays(10);
```

## Contributing
Would you be interested in contributing? All PRs are welcome.