namespace IncrementDate.Models
{
    /// <summary>
    /// Represents the individual components of a date.
    /// </summary>
    public class DateParts
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public DateParts(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
}
