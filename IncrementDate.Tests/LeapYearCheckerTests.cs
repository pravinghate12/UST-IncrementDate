using NUnit.Framework;
using IncrementDate.Utilities;

namespace IncrementDate.Tests
{
    [TestFixture]
    public class LeapYearCheckerTests
    {
        [Test]
        public void IsLeapYear_DivisibleBy400_ReturnsTrue()
        {
            Assert.That(LeapYearChecker.IsLeapYear(2000), Is.True);
            Assert.That(LeapYearChecker.IsLeapYear(2400), Is.True);
        }

        [Test]
        public void IsLeapYear_DivisibleBy100ButNotBy400_ReturnsFalse()
        {
            Assert.That(LeapYearChecker.IsLeapYear(1900), Is.False);
            Assert.That(LeapYearChecker.IsLeapYear(2100), Is.False);
        }

        [Test]
        public void IsLeapYear_DivisibleBy4ButNotBy100_ReturnsTrue()
        {
            Assert.That(LeapYearChecker.IsLeapYear(2024), Is.True);
            Assert.That(LeapYearChecker.IsLeapYear(2020), Is.True);
            Assert.That(LeapYearChecker.IsLeapYear(2016), Is.True);
        }

        [Test]
        public void IsLeapYear_NotDivisibleBy4_ReturnsFalse()
        {
            Assert.That(LeapYearChecker.IsLeapYear(2023), Is.False);
            Assert.That(LeapYearChecker.IsLeapYear(2025), Is.False);
            Assert.That(LeapYearChecker.IsLeapYear(2026), Is.False);
        }
    }
}
