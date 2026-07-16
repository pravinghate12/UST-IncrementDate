using NUnit.Framework;
using IncrementDate.Models;
using IncrementDate.Services;

namespace IncrementDate.Tests
{
    [TestFixture]
    public class DateValidatorTests
    {
        private DateValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new DateValidator();
        }

        [TestFixture]
        public class ValidateInputTests
        {
            private DateValidator _validator;

            [SetUp]
            public void Setup()
            {
                _validator = new DateValidator();
            }

            [Test]
            public void ValidateInput_WithNullDate_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateInput(null, 1));
                Assert.That(ex.Message, Does.Contain("Date cannot be null or empty"));
            }

            [Test]
            public void ValidateInput_WithEmptyDate_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateInput("", 1));
                Assert.That(ex.Message, Does.Contain("Date cannot be null or empty"));
            }

            [Test]
            public void ValidateInput_WithWhitespaceDate_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateInput("   ", 1));
                Assert.That(ex.Message, Does.Contain("Date cannot be null or empty"));
            }

            [Test]
            public void ValidateInput_WithNegativeDays_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateInput("15/07/2026", -5));
                Assert.That(ex.Message, Does.Contain("Days to add cannot be negative"));
            }

            [Test]
            public void ValidateInput_WithValidInputs_DoesNotThrow()
            {
                Assert.DoesNotThrow(() => _validator.ValidateInput("15/07/2026", 1));
                Assert.DoesNotThrow(() => _validator.ValidateInput("15/07/2026", 0));
            }
        }

        [TestFixture]
        public class ParseDateTests
        {
            private DateValidator _validator;

            [SetUp]
            public void Setup()
            {
                _validator = new DateValidator();
            }

            [Test]
            public void ParseDate_ValidFormat_ReturnsParsedDate()
            {
                var result = _validator.ParseDate("31/12/2023");

                Assert.That(result.Day, Is.EqualTo(31));
                Assert.That(result.Month, Is.EqualTo(12));
                Assert.That(result.Year, Is.EqualTo(2023));
            }

            [Test]
            public void ParseDate_InvalidFormat_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ParseDate("2023-12-31"));
                Assert.That(ex.Message, Does.Contain("Date must be in dd/MM/yyyy format"));
            }

            [Test]
            public void ParseDate_TooFewParts_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ParseDate("31/12"));
                Assert.That(ex.Message, Does.Contain("Date must be in dd/MM/yyyy format"));
            }

            [Test]
            public void ParseDate_TooManyParts_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ParseDate("31/12/2023/extra"));
                Assert.That(ex.Message, Does.Contain("Date must be in dd/MM/yyyy format"));
            }

            [Test]
            public void ParseDate_NonNumericValues_ThrowsArgumentException()
            {
                var ex = Assert.Throws<ArgumentException>(() => _validator.ParseDate("AA/BB/CCCC"));
                Assert.That(ex.Message, Does.Contain("Date contains non-numeric values"));
            }
        }

        [TestFixture]
        public class ValidateDatePartsTests
        {
            private DateValidator _validator;

            [SetUp]
            public void Setup()
            {
                _validator = new DateValidator();
            }

            [Test]
            public void ValidateDateParts_MonthGreaterThan12_ThrowsArgumentException()
            {
                var dateParts = new DateParts(15, 13, 2024);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid month"));
            }

            [Test]
            public void ValidateDateParts_MonthLessThan1_ThrowsArgumentException()
            {
                var dateParts = new DateParts(15, 0, 2024);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid month"));
            }

            [Test]
            public void ValidateDateParts_InvalidDayForMonth_ThrowsArgumentException()
            {
                var dateParts = new DateParts(32, 1, 2024);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid day for the given month"));
            }

            [Test]
            public void ValidateDateParts_InvalidFebruaryDay_ThrowsArgumentException()
            {
                var dateParts = new DateParts(30, 2, 2024);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid day for the given month"));
            }

            [Test]
            public void ValidateDateParts_LeapYearFebruary29_DoesNotThrow()
            {
                var dateParts = new DateParts(29, 2, 2024);
                Assert.DoesNotThrow(() => _validator.ValidateDateParts(dateParts));
            }

            [Test]
            public void ValidateDateParts_NonLeapYearFebruary29_ThrowsArgumentException()
            {
                var dateParts = new DateParts(29, 2, 2023);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid day for the given month"));
            }

            [Test]
            public void ValidateDateParts_ZeroDayValue_ThrowsArgumentException()
            {
                var dateParts = new DateParts(0, 5, 2024);
                var ex = Assert.Throws<ArgumentException>(() => _validator.ValidateDateParts(dateParts));
                Assert.That(ex.Message, Does.Contain("Invalid day for the given month"));
            }

            [Test]
            public void ValidateDateParts_ValidDate_DoesNotThrow()
            {
                var dateParts = new DateParts(31, 1, 2024);
                Assert.DoesNotThrow(() => _validator.ValidateDateParts(dateParts));
            }
        }
    }
}
