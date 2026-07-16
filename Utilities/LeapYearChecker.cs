namespace IncrementDate.Utilities
{
    /// <summary>
    /// Responsible for determining if a year is a leap year.
    /// </summary>
    public static class LeapYearChecker
    {
        /// <summary>
        /// Determines whether the specified year is a leap year.
        /// Rules:
        /// - Divisible by 400 -> Leap year
        /// - Divisible by 100 -> Not a leap year
        /// - Divisible by 4   -> Leap year
        /// - Otherwise        -> Not a leap year
        /// </summary>
        public static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
                return true;

            if (year % 100 == 0)
                return false;

            return year % 4 == 0;
        }
    }
}
