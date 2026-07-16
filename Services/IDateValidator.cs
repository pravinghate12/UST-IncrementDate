using IncrementDate.Models;

namespace IncrementDate.Services
{
    public interface IDateValidator
    {
        void ValidateInput(string inputDate, int daysToAdd);
        DateParts ParseDate(string inputDate);
        void ValidateDateParts(DateParts dateParts);
    }
}
