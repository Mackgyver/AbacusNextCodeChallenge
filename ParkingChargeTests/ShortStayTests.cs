using NUnit.Framework;
using System;
using ParkingChargeCalculator;

namespace ParkingChargeTests
{
    [TestFixture]
    public class ShortStayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateDuration_OutwithChargePeriod_EqualsZero()
        {
            var visit = new ShortVisit(
                new DateTime(2021, 3, 12, 18, 0, 1),
                new DateTime(2021, 3, 15, 7, 59, 59));

            Assert.AreEqual(visit.CalculateDuration(), 0);
        }

        [Test]
        public void CalculateDuration_SameDay_Equals120()
        {
            var visit = new ShortVisit(
                new DateTime(2021, 3, 15, 8, 0, 0),
                new DateTime(2021, 3, 15, 10, 0, 0));

            Assert.AreEqual(visit.CalculateDuration(), 120);
        }

        [Test]
        public void CalculateCharge_OutwithChargePeriod_EqualsZero()
        {
            var visit = new ShortVisit(
                new DateTime(2021, 3, 12, 18, 0, 1),
                new DateTime(2021, 3, 15, 7, 59, 59));

            Assert.AreEqual(visit.CalculateCharge(), 0);
        }


        [Test]
        public void CalculateCharge_Sameday_2hours()
        {
            var visit = new ShortVisit(
                new DateTime(2021, 3, 15, 8, 0, 0),
                new DateTime(2021, 3, 15, 10, 0, 0));

            Assert.AreEqual(visit.CalculateCharge(), 2.20);
        }


        [Test]
        public void CalculateCharge_ThursdaySaturday_Equals1228()
        {
            var visit = new ShortVisit(
                new DateTime(2017, 9, 7, 16, 50, 0),
                new DateTime(2017, 9, 9, 19, 15, 0));

            Assert.AreEqual(visit.CalculateCharge(), 12.28);
        }
    }
}
