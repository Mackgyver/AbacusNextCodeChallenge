using NUnit.Framework;
using ParkingChargeCalculator;
using System;

namespace ParkingChargeTests
{
    [TestFixture]
    public class ChargeableHoursTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(7, 59, ExpectedResult = true)]
        [TestCase(8, 0, ExpectedResult = false)]
        public bool IsBeforeStartTime_SameDate(int hour, int minute)
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);

            return businessHours.IsBeforeStartTime(new DateTime(2021, 3, 16, hour, minute, 0));
        }

        [TestCase(17, 59, ExpectedResult = false)]
        [TestCase(18, 0, ExpectedResult = true)]
        public bool IsAfterEndTime_SameDate(int hour, int minute)
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);

            return businessHours.IsAfterEndTime(new DateTime(2021, 3, 16, hour, minute, 0));
        }

        [TestCase(2021,3,16,0,0,0, 2021,3,16,7,59,59, ExpectedResult = false, Description = "Weekday Pre-Start")]
        [TestCase(2021,3,12,18,0,0, 2021,3,15,8,0,0, ExpectedResult = false, Description = "Friday 18.00 - Mon 8.00")]
        [TestCase(2021,3,12,18,0,0, 2021,3,15,8,1,0, ExpectedResult = true, Description = "Friday 18.00 - Mon 8.01")]
        [TestCase(2021,3,12,17,59,59, 2021,3,15,8,0,0, ExpectedResult = true, Description = "Friday 17.59 - Mon 8.00")]
        public bool IsChargeableStay_Tests(
            int inYear, int inMonth, int inDay, int inHour, int inMinute, int inSecond,
            int outYear, int outMonth, int outDay, int outHour, int outMinute, int outSecond)
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkIn = new DateTime(inYear, inMonth, inDay, inHour, inMinute, inSecond);
            var checkOut = new DateTime(outYear, outMonth, outDay, outHour, outMinute, outSecond);

            return businessHours.IsChargeableStay(checkIn, checkOut);
        }

        [TestCase(2021,3,12,18,0,0, Description = "Friday 18.00")]
        [TestCase(2021,3,13,13,0,0, Description = "Saturday 13.00")]
        [TestCase(2021,3,14,13,0,0, Description = "Sunday 13.00")]
        [TestCase(2021,3,15,8,0,0, Description = "Monday 8.00")]
        public void GetStartOfChargePeriod_Tests_Weekends(
            int inYear, int inMonth, int inDay, int inHour, int inMinute, int inSecond)
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkIn = new DateTime(inYear, inMonth, inDay, inHour, inMinute, inSecond);
            var expected = new DateTime(2021, 3, 15, 8, 0, 0);

            Assert.AreEqual(businessHours.GetStartOfChargePeriod(checkIn), expected);
        }

        [Test]
        public void GetStartOfChargePeriod_Tests_WeekdayAfterEndTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkIn = new DateTime(2021, 3, 16, 18, 0, 0);
            var expected = new DateTime(2021, 3, 17, 8, 0, 0);

            Assert.AreEqual(businessHours.GetStartOfChargePeriod(checkIn), expected);
        }

        [Test]
        public void GetStartOfChargePeriod_Tests_WeekdayBeforeStartTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkIn = new DateTime(2021, 3, 17, 3, 0, 0);
            var expected = new DateTime(2021, 3, 17, 8, 0, 0);

            Assert.AreEqual(businessHours.GetStartOfChargePeriod(checkIn), expected);
        }

        [Test]
        public void GetStartOfChargePeriod_Tests_SameAsStartTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkIn = new DateTime(2021, 3, 17, 13, 0, 0);

            Assert.AreEqual(businessHours.GetStartOfChargePeriod(checkIn), checkIn);
        }

        [TestCase(2021, 3, 15, 7, 59, 0, Description = "Monday 8.00")]
        [TestCase(2021, 3, 14, 13, 0, 0, Description = "Sunday 13.00")]
        [TestCase(2021, 3, 13, 13, 0, 0, Description = "Saturday 13.00")]
        [TestCase(2021, 3, 12, 18, 0, 0, Description = "Friday 18.00")]
        public void GetEndOfChargePeriod_Tests_Weekends(
            int outYear, int outMonth, int outDay, int outHour, int outMinute, int outSecond)
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkOut = new DateTime(outYear, outMonth, outDay, outHour, outMinute, outSecond);
            var expected = new DateTime(2021, 3, 12, 18, 0, 0);

            Assert.AreEqual(businessHours.GetEndOfChargePeriod(checkOut), expected);
        }

        [Test]
        public void GetEndOfChargePeriod_Tests_WeekdayBeforeStartTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkOut = new DateTime(2021, 3, 16, 7, 59, 0);
            var expected = new DateTime(2021, 3, 15, 18, 0, 0);

            Assert.AreEqual(businessHours.GetEndOfChargePeriod(checkOut), expected);
        }

        [Test]
        public void GetEndOfChargePeriod_Tests_WeekdayAfterEndTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkOut = new DateTime(2021, 3, 17, 20, 0, 0);
            var expected = new DateTime(2021, 3, 17, 18, 0, 0);

            Assert.AreEqual(businessHours.GetEndOfChargePeriod(checkOut), expected);
        }

        [Test]
        public void GetEndOfChargePeriod_Tests_SameAsEndTime()
        {
            var businessHours = new ChargeableHours(8, 0, 18, 0);
            var checkOut = new DateTime(2021, 3, 17, 13, 0, 0);

            Assert.AreEqual(businessHours.GetEndOfChargePeriod(checkOut), checkOut);
        }
    }
}