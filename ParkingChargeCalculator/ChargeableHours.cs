using System;

namespace ParkingChargeCalculator
{
    public class ChargeableHours
    {
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ChargeableHours(int startHour, int startMinute, int endHour, int endMinute)
        {
            StartHour = startHour;
            StartMinute = startMinute;
            EndHour = endHour;
            EndMinute = endMinute;
        }

        public bool IsChargeableStay(DateTime checkIn, DateTime checkOut)
        {
            return GetStartOfChargePeriod(checkIn) < checkOut;
        }

        public DateTime GetStartOfChargePeriod(DateTime checkIn)
        {
            if (checkIn.DayOfWeek == DayOfWeek.Friday && IsAfterEndTime(checkIn))
            {
                return GetStartOfChargeableDay(checkIn.AddDays(3));
            }
            if (checkIn.DayOfWeek == DayOfWeek.Saturday)
            {
                return GetStartOfChargeableDay(checkIn.AddDays(2));
            }
            if (checkIn.DayOfWeek == DayOfWeek.Sunday)
            {
                return GetStartOfChargeableDay(checkIn.AddDays(1));
            }
            if (IsAfterEndTime(checkIn))
            {
                return GetStartOfChargeableDay(checkIn.AddDays(1));
            }
            if (IsBeforeStartTime(checkIn))
            {
                return GetStartOfChargeableDay(checkIn);
            }
            return checkIn;
        }

        public DateTime GetEndOfChargePeriod(DateTime checkout)
        {
            if (checkout.DayOfWeek == DayOfWeek.Monday && IsBeforeStartTime(checkout))
            {
                return GetEndOfChargeableDay(checkout.AddDays(-3));
            }
            if (checkout.DayOfWeek == DayOfWeek.Sunday)
            {
                return GetEndOfChargeableDay(checkout.AddDays(-2));
            }
            if (checkout.DayOfWeek == DayOfWeek.Saturday)
            {
                return GetEndOfChargeableDay(checkout.AddDays(-1));
            }
            if (IsBeforeStartTime(checkout))
            {
                return GetEndOfChargeableDay(checkout.AddDays(-1));
            }
            if (IsAfterEndTime(checkout))
            {
                return GetEndOfChargeableDay(checkout);
            }
            return checkout;
        }

        public bool IsBeforeStartTime(DateTime date)
        {
            return date.Hour < StartHour || date.Hour == StartHour && date.Minute < StartMinute;
        }

        public bool IsAfterEndTime(DateTime date)
        {
            return date.Hour > EndHour || date.Hour == EndHour && date.Minute >= EndMinute;
        }

        public DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        public DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        public DateTime GetStartOfChargeableDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, StartHour, StartMinute, 0);
        }

        public DateTime GetEndOfChargeableDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, EndHour, EndMinute, 0);
        }
    }
}
