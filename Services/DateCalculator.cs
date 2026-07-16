using IncrementDate.Models;
using IncrementDate.Utilities;

namespace IncrementDate.Services
{
    /// <summary>
    /// Responsible for calculating dates by adding days.
    /// </summary>
    public class DateCalculator
    {
        private readonly DateValidator _validator;

        public DateCalculator(DateValidator validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public string AddDays(string inputDate, int daysToAdd)
        {
            _validator.ValidateInput(inputDate, daysToAdd);
            DateParts dateParts = _validator.ParseDate(inputDate);
            _validator.ValidateDateParts(dateParts);

            while (daysToAdd > 0)
            {
                dateParts.Day++;

                if (dateParts.Day > GetDaysInMonth(dateParts.Month, dateParts.Year))
                {
                    dateParts.Day = 1;
                    dateParts.Month++;

                    if (dateParts.Month > 12)
                    {
                        dateParts.Month = 1;
                        dateParts.Year++;
                    }
                }

                daysToAdd--;
            }

            return dateParts.ToString();
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
