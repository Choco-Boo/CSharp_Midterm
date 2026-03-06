using System;

namespace DateOperationsLib
{
    // Class that provides date-related utility methods
    public class DateOperations
    {
        // Method 1: Calculate the number of days between two dates
        // Returns a positive value if endDate > startDate, negative if reversed
        public int DaysBetween(DateTime startDate, DateTime endDate)
        {
            TimeSpan difference = endDate.Date - startDate.Date;
            return (int)difference.TotalDays;
        }

        // Method 2: Add a specified number of days to a given date
        // daysToAdd can be negative (to go backwards) or positive (to go forward)
        public DateTime AddDays(DateTime date, int daysToAdd)
        {
            return date.AddDays(daysToAdd);
        }

        // Method 3: Determine if a given year is a leap year
        // A year is a leap year if divisible by 4,
        // EXCEPT century years must be divisible by 400
        public bool IsLeapYear(int year)
        {
            if (year < 1)
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be a positive integer.");

            return DateTime.IsLeapYear(year);
        }
    }
}
