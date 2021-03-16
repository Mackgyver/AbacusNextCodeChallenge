using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingChargeCalculator
{
    public abstract class ParkingVisit
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double ChargeRate { get; set; }
        public ChargeableHours BusinessHours { get; set; }


        public abstract double CalculateDuration();

        public abstract double CalculateCharge();
    }
}
