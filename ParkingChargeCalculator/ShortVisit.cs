using System;

namespace ParkingChargeCalculator
{
    public class ShortVisit : ParkingVisit
    {
        public ShortVisit(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            ChargeRate = 1.1;
            BusinessHours = new ChargeableHours(8, 0, 18, 0);
        }

        public override double CalculateCharge()
        {
            return Math.Round(CalculateDuration() / 60 * ChargeRate, 2);
        }

        public override double CalculateDuration()
        {
            var startTime = BusinessHours.GetStartOfChargePeriod(Start);
            var endTime = BusinessHours.GetEndOfChargePeriod(End);

            if (!BusinessHours.IsChargeableStay(Start, End))
            {
                return 0;
            }

            if (Start.Date == End.Date)
            {
                return (endTime - startTime).TotalMinutes;
            }

            var endOfStartDay = BusinessHours.GetEndOfChargeableDay(startTime);
            var startOfEndDay = BusinessHours.GetStartOfChargeableDay(endTime);
            var minsUsedInStartDay = (endOfStartDay - startTime).TotalMinutes;
            var minsUsedInEndDay = (endTime - startOfEndDay).TotalMinutes;
            var businessHoursInMinutes = ((BusinessHours.EndHour - BusinessHours.StartHour) * 60) + (BusinessHours.EndMinute - BusinessHours.StartMinute);
            var totalUsedMinutes = minsUsedInStartDay + minsUsedInEndDay;

            for (DateTime day = startTime.AddDays(1); day < endTime.AddDays(-1); day = day.AddDays(1))
            {
                totalUsedMinutes += businessHoursInMinutes;
            }

            return totalUsedMinutes;
        }
    }
}
