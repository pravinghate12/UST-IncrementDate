using IncrementDate.Models;
using IncrementDate.Utilities;

namespace IncrementDate.Services
{
    /// <summary>
    /// Responsible for validating date inputs and formats.
    /// </summary>
    public class DateValidator
    {
        public void ValidateInput(string inputDate, int daysToAdd)
        {
            if (string.IsNullOrWhiteSpace(inputDate))
                throw new ArgumentException("Date cannot be null or empty.");

            if (daysToAdd < 0)
                throw new ArgumentException("Days to add cannot be negative.");
        }

        public DateParts ParseDate(string inputDate)
        {
            string[] parts = inputDate.Split('/');

            if (parts.Length != 3)
                throw new ArgumentException("Date must be in dd/MM/yyyy format.");

            if (!int.TryParse(parts[0], out int day) ||
                !int.TryParse(parts[1], out int month) ||
                !int.TryParse(parts[2], out int year))
            {
                throw new ArgumentException("Date contains non-numeric values.");
            }

            return new DateParts(day, month, year);
        }

        public void ValidateDateParts(DateParts dateParts)
        {
            if (dateParts.Month < 1 || dateParts.Month > 12)
                throw new ArgumentException("Invalid month.");

            if (dateParts.Day < 1 || dateParts.Day > GetDaysInMonth(dateParts.Month, dateParts.Year))
                throw new ArgumentException("Invalid day for the given month.");
        }

        private int GetDaysInMonth(int month, int year)
        {
            return month switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                4 or 6 or 9 or 11 => 30,
                2 => LeapYearChecker.IsLeapYear(year) ? 29 : 28,
                _ => throw new ArgumentException("Invalid month.")
            };
        }
    }
}
