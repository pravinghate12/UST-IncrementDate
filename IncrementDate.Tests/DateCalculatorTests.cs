using NUnit.Framework;
using IncrementDate.Services;

namespace IncrementDate.Tests
{
    [TestFixture]
    public class DateCalculatorTests
    {
        private DateCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            var validator = new DateValidator();
            _calculator = new DateCalculator(validator);
        }

        [TestFixture]
        public class MonthTransitionTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_MonthTransition_JanuaryToFebruary()
            {
                var result = _calculator.AddDays("31/01/2016", 1);
                Assert.That(result, Is.EqualTo("01/02/2016"));
            }

            [Test]
            public void AddDays_MonthTransition_FebruaryToMarch()
            {
                var result = _calculator.AddDays("28/02/2023", 1);
                Assert.That(result, Is.EqualTo("01/03/2023"));
            }

            [Test]
            public void AddDays_MonthTransition_LeapYearFebruaryToMarch()
            {
                var result = _calculator.AddDays("29/02/2024", 1);
                Assert.That(result, Is.EqualTo("01/03/2024"));
            }
        }

        [TestFixture]
        public class YearTransitionTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_YearTransition_DecemberToJanuary()
            {
                var result = _calculator.AddDays("31/12/2023", 1);
                Assert.That(result, Is.EqualTo("01/01/2024"));
            }
        }

        [TestFixture]
        public class ZeroDaysTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_ZeroDays_ReturnsSameDate()
            {
                var result = _calculator.AddDays("15/07/2026", 0);
                Assert.That(result, Is.EqualTo("15/07/2026"));
            }
        }

        [TestFixture]
        public class MultipleDaysTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_100Days_ReturnsCorrectDate()
            {
                var result = _calculator.AddDays("15/07/2026", 100);
                Assert.That(result, Is.EqualTo("23/10/2026"));
            }

            [Test]
            public void AddDays_365Days_ReturnsCorrectDate()
            {
                var result = _calculator.AddDays("01/01/2023", 365);
                Assert.That(result, Is.EqualTo("01/01/2024"));
            }
        }

        [TestFixture]
        public class LeapYearTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_LeapYearFebruary28_AddOne()
            {
                var result = _calculator.AddDays("28/02/2024", 1);
                Assert.That(result, Is.EqualTo("29/02/2024"));
            }

            [Test]
            public void AddDays_NonLeapYearFebruary28_AddOne()
            {
                var result = _calculator.AddDays("28/02/2023", 1);
                Assert.That(result, Is.EqualTo("01/03/2023"));
            }
        }

        [TestFixture]
        public class ValidationTests
        {
            private DateCalculator _calculator;

            [SetUp]
            public void Setup()
            {
                var validator = new DateValidator();
                _calculator = new DateCalculator(validator);
            }

            [Test]
            public void AddDays_NullDate_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays(null, 1));
            }

            [Test]
            public void AddDays_EmptyDate_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays("", 1));
            }

            [Test]
            public void AddDays_InvalidFormat_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays("2024-01-31", 1));
            }

            [Test]
            public void AddDays_NegativeDays_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays("15/07/2026", -5));
            }

            [Test]
            public void AddDays_InvalidMonth_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays("10/13/2024", 1));
            }

            [Test]
            public void AddDays_InvalidDay_ThrowsArgumentException()
            {
                Assert.Throws<ArgumentException>(() => _calculator.AddDays("32/01/2024", 1));
            }
        }
    }
}
