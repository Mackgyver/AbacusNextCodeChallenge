using NUnit.Framework;
using ParkingChargeCalculator;
using System;

namespace ParkingChargeTests
{
    [TestFixture]
    public class LongStayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2021, 3, 15, 0, 0, 0, 2021, 3, 15, 7, 59, 59, Description = "WeekDay Morning")]
        [TestCase(2021, 3, 16, 18, 0, 0, 2021, 3, 16, 0, 0, 0, Description = "WeekDay Evening")]
        [TestCase(2021, 3, 12, 18, 0, 1, 2021, 3, 15, 7, 59, 59, Description = "All Weekend")]
        public void CalculateDuration_NonChargeable_ReturnsZero(
            int startYear, int startMonth, int startDay, int startHour, int startMinute, int startSecond,
            int endYear, int endMonth, int endDay, int endHour, int endMinute, int endSecond)
        {
            var visit = new LongVisit(new DateTime(startYear, startMonth, startDay, startHour, startMinute, startSecond),
                        new DateTime(endYear, endMonth, endDay, endHour, endMinute, endSecond));

            Assert.AreEqual(visit.CalculateDuration(), 0);
        }

        [Test]
        public void CalculateDuration_SameDateAndTime_Equals0()
        {
            var visit = new LongVisit(
                new DateTime(2021, 3, 14, 0, 0, 0),
                new DateTime(2021, 3, 14, 0, 0, 0));

            Assert.AreEqual(visit.CalculateDuration(), 0);
        }

        [Test]
        public void CalculateDuration_OneAndAHalfDays_Equals2()
        {
            var visit = new LongVisit(
                new DateTime(2021, 3, 14, 0, 0, 0),
                new DateTime(2021, 3, 15, 12, 0, 0));

            Assert.AreEqual(visit.CalculateDuration(), 2);
        }

        [Test]
        public void CalculateCharge_PartialChargePeriod_EqualsThreeFullDays()
        {
            var visit = new LongVisit(
                new DateTime(2017, 9, 7, 7, 50, 0),
                new DateTime(2017, 9, 9, 5, 20, 0));

            Assert.AreEqual(visit.CalculateCharge(), 22.50);
        }
    }
}