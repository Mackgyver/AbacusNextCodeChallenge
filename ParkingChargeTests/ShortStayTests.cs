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

        //[TestCase(7, 59, ExpectedResult = true)]
        //[TestCase(8, 0, ExpectedResult = false)]
        //public bool IsBeforeStartTime_SameDate(int hour, int minute)
        //{
        //    var visit = new ShortVisit(
        //        new DateTime(2021, 3, 14, hour, minute, 59),
        //        new DateTime(2021, 3, 15, 0, 0, 0));

        //    return visit.IsBeforeStartTime(visit.Start);
        //}

        //[TestCase(17, 59, ExpectedResult = false)]
        //[TestCase(18, 0, ExpectedResult = true)]
        //public bool IsAfterEndTime_SameDate(int hour, int minute)
        //{
        //    var visit = new ShortVisit(
        //        new DateTime(2021, 3, 14, 8, 0, 0),
        //        new DateTime(2021, 3, 15, hour, minute, 0));

        //    return visit.IsAfterEndTime(visit.End);
        //}

        //[Test]
        //public void GetStartOfDay_BeforeStart_is8()
        //{
        //    var visit = new ShortVisit(
        //        new DateTime(2021, 3, 14, 1, 0, 0),
        //        new DateTime(2021, 3, 15, 0, 0, 0));

        //    Assert.AreEqual(visit.GetStartOfChargeableDay(visit.Start), new DateTime(2021, 3, 14, 8, 0, 0));
        //}

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
