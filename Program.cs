using IncrementDate.Services;

// Dependency Injection - Interfaces allow for future expansion
IDateValidator validator = new DateValidator();
IDateCalculator calculator = new DateCalculator(validator);

// Interactive date calculator
Console.WriteLine("========================================");
Console.WriteLine("    Date Calculator Application");
Console.WriteLine("========================================\n");

while (true)
{
    Console.WriteLine("Options:");
    Console.WriteLine("1. Add days to a date");
    Console.WriteLine("2. Exit");
    Console.Write("\nSelect option: ");

    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid option. Please try again.\n");
        continue;
    }

    if (option == 2)
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    if (option == 1)
    {
        Console.Write("Enter date (dd/MM/yyyy): ");
        string? inputDate = Console.ReadLine();

        Console.Write("Enter number of days to add: ");
        if (!int.TryParse(Console.ReadLine(), out int daysToAdd))
        {
            Console.WriteLine("Invalid number of days.\n");
            continue;
        }

        try
        {
            string result = calculator.AddDays(inputDate!, daysToAdd);
            Console.WriteLine($"Result: {result}\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }
    else
    {
        Console.WriteLine("Invalid option. Please try again.\n");
    }
}
