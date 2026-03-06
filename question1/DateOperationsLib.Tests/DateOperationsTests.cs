using System;
using Xunit;
using DateOperationsLib;

namespace DateOperationsLib.Tests
{
    public class DateOperationsTests
    {
        private readonly DateOperations _dateOps = new DateOperations();

        // =============================================
        // Tests for DaysBetween()
        // =============================================

        // NORMAL: Basic positive difference
        [Fact]
        public void DaysBetween_NormalCase_ReturnsCorrectDays()
        {
            DateTime start = new DateTime(2024, 1, 1);
            DateTime end   = new DateTime(2024, 1, 11);
            int result = _dateOps.DaysBetween(start, end);
            Assert.Equal(10, result);
        }

        // NORMAL: Dates spanning multiple months
        [Fact]
        public void DaysBetween_AcrossMonths_ReturnsCorrectDays()
        {
            DateTime start = new DateTime(2024, 3, 1);
            DateTime end   = new DateTime(2024, 4, 1);
            int result = _dateOps.DaysBetween(start, end);
            Assert.Equal(31, result);
        }

        // BOUNDARY: Same date should return 0
        [Fact]
        public void DaysBetween_SameDate_ReturnsZero()
        {
            DateTime date = new DateTime(2024, 6, 15);
            int result = _dateOps.DaysBetween(date, date);
            Assert.Equal(0, result);
        }

        // BOUNDARY: End date before start date returns negative
        [Fact]
        public void DaysBetween_EndBeforeStart_ReturnsNegative()
        {
            DateTime start = new DateTime(2024, 6, 15);
            DateTime end   = new DateTime(2024, 6, 10);
            int result = _dateOps.DaysBetween(start, end);
            Assert.Equal(-5, result);
        }

        // BOUNDARY: Exactly one year apart (non-leap)
        [Fact]
        public void DaysBetween_OneYear_Returns365()
        {
            DateTime start = new DateTime(2023, 1, 1);
            DateTime end   = new DateTime(2024, 1, 1);
            int result = _dateOps.DaysBetween(start, end);
            Assert.Equal(365, result);
        }

        // BOUNDARY: Across a leap year
        [Fact]
        public void DaysBetween_LeapYear_Returns366()
        {
            DateTime start = new DateTime(2024, 1, 1);
            DateTime end   = new DateTime(2025, 1, 1);
            int result = _dateOps.DaysBetween(start, end);
            Assert.Equal(366, result);
        }

        // =============================================
        // Tests for AddDays()
        // =============================================

        // NORMAL: Add positive days
        [Fact]
        public void AddDays_AddPositiveDays_ReturnsCorrectDate()
        {
            DateTime date   = new DateTime(2024, 1, 1);
            DateTime result = _dateOps.AddDays(date, 10);
            Assert.Equal(new DateTime(2024, 1, 11), result);
        }

        // NORMAL: Add days crossing month boundary
        [Fact]
        public void AddDays_CrossesMonthBoundary_ReturnsCorrectDate()
        {
            DateTime date   = new DateTime(2024, 1, 25);
            DateTime result = _dateOps.AddDays(date, 10);
            Assert.Equal(new DateTime(2024, 2, 4), result);
        }

        // BOUNDARY: Add zero days returns same date
        [Fact]
        public void AddDays_ZeroDays_ReturnsSameDate()
        {
            DateTime date   = new DateTime(2024, 5, 20);
            DateTime result = _dateOps.AddDays(date, 0);
            Assert.Equal(date, result);
        }

        // BOUNDARY: Add negative days (go backwards)
        [Fact]
        public void AddDays_NegativeDays_ReturnsEarlierDate()
        {
            DateTime date   = new DateTime(2024, 3, 10);
            DateTime result = _dateOps.AddDays(date, -10);
            Assert.Equal(new DateTime(2024, 2, 29), result); // 2024 is leap year
        }

        // BOUNDARY: Add large number of days
        [Fact]
        public void AddDays_LargeDays_ReturnsCorrectDate()
        {
            DateTime date   = new DateTime(2023, 1, 1);
            DateTime result = _dateOps.AddDays(date, 365);
            Assert.Equal(new DateTime(2024, 1, 1), result);
        }

        // EXCEPTIONAL: Overflow near DateTime.MaxValue
        [Fact]
        public void AddDays_OverflowMaxValue_ThrowsException()
        {
            DateTime maxDate = DateTime.MaxValue;
            Assert.Throws<ArgumentOutOfRangeException>(() => _dateOps.AddDays(maxDate, 1));
        }

        // =============================================
        // Tests for IsLeapYear()
        // =============================================

        // NORMAL: Standard leap year divisible by 4
        [Fact]
        public void IsLeapYear_StandardLeapYear_ReturnsTrue()
        {
            Assert.True(_dateOps.IsLeapYear(2024));
        }

        // NORMAL: Standard non-leap year
        [Fact]
        public void IsLeapYear_StandardNonLeapYear_ReturnsFalse()
        {
            Assert.False(_dateOps.IsLeapYear(2023));
        }

        // BOUNDARY: Century year NOT divisible by 400 is NOT a leap year
        [Fact]
        public void IsLeapYear_CenturyNotDivisibleBy400_ReturnsFalse()
        {
            Assert.False(_dateOps.IsLeapYear(1900));
        }

        // BOUNDARY: Century year divisible by 400 IS a leap year
        [Fact]
        public void IsLeapYear_CenturyDivisibleBy400_ReturnsTrue()
        {
            Assert.True(_dateOps.IsLeapYear(2000));
        }

        // BOUNDARY: Year 4 (earliest meaningful leap year)
        [Fact]
        public void IsLeapYear_Year4_ReturnsTrue()
        {
            Assert.True(_dateOps.IsLeapYear(4));
        }

        // BOUNDARY: Year 1 is not a leap year
        [Fact]
        public void IsLeapYear_Year1_ReturnsFalse()
        {
            Assert.False(_dateOps.IsLeapYear(1));
        }

        // EXCEPTIONAL: Zero or negative year throws exception
        [Fact]
        public void IsLeapYear_ZeroYear_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _dateOps.IsLeapYear(0));
        }

        [Fact]
        public void IsLeapYear_NegativeYear_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _dateOps.IsLeapYear(-4));
        }
    }
}
