# PublicHolidays.Au

## Overview

The need for this library came from a business requirement to calculate a date, X number of business days into the future including public holidays.

Traditional approaches to this solving this problem might be a) storing public holidays in a database or configuration file and then reading this information at runtime, b) use of a third party service. Some of the negatives associated to this type of approaches include:
* Accessing a database, configuration file, or third party service is slow.
* Someone needs to remember to update the public holiday data every year.
* Implementing the public holiday business logic is additional code that needs to written and maintained.  
* There is always a chance for data errors.

Looking at the list of Australian public holiday dates, it's soon clear that the date of most of them can be consistently deduced. An application-library/utility to solve this problem is absolutely possible, albiet with a few minor considerations outlined below.

## Considerations

The calculations for most Australian public holidays is pretty straight forward. However, there are a few cases that need special mention:
* Partial public holidays such as Christmas and New Years eve.
* A small subset of Australian public holidays are not state wide i.e. they apply to some, but not all, postcodes within a state. Some examples include:
    * Royal Queensland show, which is only in Brisbane.
    * The Melbourne Cup in VIC. Some regions observe the holiday on a differnet day corresponding with their own local racing carnival.
* There are 2 public holidays that cannot be consistently deduced. These are:
    * The day before the AFL grand final in Victoria. The date of the AFL grand final used to be the last weekend in September, however, due to a number of factors the date is now sometimes the first weekend in October.
    * Family & Community Day in the ACT. The holiday is taken on the first Monday of the September/October school holidays, but it doesn't seem possible to accurately calculate date of the September/October school holidays.
* One particular public holiday, the bank holiday in NSW, only applies to certain finance industries.

### Exclusions

* Partial public holidays are not taken into consideration.
* Only public holidays that cover all areas or most areas in a state are taken into consideration. This means the following public holidays are excluded:
    * Royal Queensland show in QLD.
* Only public holidays that can be consistently deduced are taken into consideration. This means the following public holidays are excluded:
    * Grand final eve in VIC.
    * Family & Community Day in the ACT.
* Only public holidays that apply to all industries are taken into consideration. This means the following public holidays are excluded:
    * Bank holiday in NSW.

## List of Public Holidays


## Solution
Solution is comprised of 2 projects:
* PublicHolidays.Au is the implementation
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