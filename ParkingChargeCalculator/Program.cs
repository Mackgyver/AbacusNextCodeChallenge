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
            Console.WriteLine(visit1.CalculateCharge());
            Console.WriteLine(visit2.CalculateCharge());
            Console.WriteLine(visit3.CalculateCharge());
            Console.WriteLine("Hello World!");
        }
    }
}
