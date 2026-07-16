namespace IncrementDate.Services
{
    /// <summary>
    /// Responsible for executing and reporting test results.
    /// </summary>
    public class DateTestRunner
    {
        private readonly DateCalculator _calculator;

        public DateTestRunner(DateCalculator calculator)
        {
            _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
        }

        public void RunTest(string inputDate, int daysToAdd)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Input Date : {inputDate ?? "null"}");
            Console.WriteLine($"Days Added : {daysToAdd}");

            try
            {
                string result = _calculator.AddDays(inputDate, daysToAdd);
                Console.WriteLine($"Result     : {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error      : {ex.Message}");
            }

            Console.WriteLine();
        }

        public void RunPositiveTests()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("        POSITIVE TEST CASES");
            Console.WriteLine("=======================================\n");

            RunTest("31/01/2016", 1);
            RunTest("31/12/2023", 1);
            RunTest("28/02/2024", 1);
            RunTest("28/02/2023", 1);
            RunTest("29/02/2024", 1);
            RunTest("15/07/2026", 0);
            RunTest("15/07/2026", 100);
        }

        public void RunNegativeTests()
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("        NEGATIVE TEST CASES");
            Console.WriteLine("=======================================\n");

            RunTest("", 1);
            RunTest(null, 1);
            RunTest("2024-01-31", 1);
            RunTest("10/13/2024", 1);
            RunTest("10/00/2024", 1);
            RunTest("32/01/2024", 1);
            RunTest("30/02/2024", 1);
            RunTest("29/02/2023", 1);
            RunTest("15/07/2026", -5);
            RunTest("AA/BB/CCCC", 1);
        }
    }
}
