using System;

namespace ParkingChargeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var visit1 = new LongVisit(new DateTime(2021, 3, 1, 18, 0, 0), new DateTime(2021, 3, 2, 7, 59, 0));
            var visit2 = new ShortVisit(new DateTime(2017, 9, 7, 16, 50, 0), new DateTime(2017, 9, 9, 19, 15, 0));
            var visit3 = new LongVisit(new DateTime(2017, 9, 7, 7, 50, 0), new DateTime(2017, 9, 9, 5, 20, 0));
            Console.WriteLine(visit1.Start.ToString() + " - " + visit1.End.ToString() + " Charge = " + visit1.CalculateCharge().ToString("C"));
            Console.WriteLine(visit2.Start.ToString() + " - " + visit2.End.ToString() + " Charge = " + visit2.CalculateCharge().ToString("C"));
            Console.WriteLine(visit3.Start.ToString() + " - " + visit3.End.ToString() + " Charge = " + visit3.CalculateCharge().ToString("C"));
        }
    }
}
