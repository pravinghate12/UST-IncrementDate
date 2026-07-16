namespace IncrementDate.Services
{
    public interface IDateCalculator
    {
        string AddDays(string inputDate, int daysToAdd);
    }
}
