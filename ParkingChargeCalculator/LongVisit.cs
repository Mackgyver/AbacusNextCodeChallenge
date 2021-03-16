using System;

namespace ParkingChargeCalculator
{
    public class LongVisit : ParkingVisit
    {
        public LongVisit(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            ChargeRate = 7.5;
            BusinessHours = new ChargeableHours(8, 0, 18, 0);
        }

        public override double CalculateCharge()
        {
            return CalculateDuration() * ChargeRate;
        }

        public override double CalculateDuration()
        {
            if (!BusinessHours.IsChargeableStay(Start, End))
            {
                return 0;
            }
            var totalDays = (BusinessHours.GetEndOfDay(End) - BusinessHours.GetStartOfDay(Start)).TotalDays;
            return Math.Ceiling(totalDays);
        }
    }
}
