using Performances;
using System;
using UnitsNet;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tester 1.0.0.0");
            AircraftPerformance a320 = new AircraftPerformance();
            a320.Open("./Resources/a320.json");
            Console.WriteLine(a320.GetHoldingFuel(Length.FromFeet(2000), 
                Mass.FromKilograms(61_000), new TimeSpan(0,45,00)).Value.Kilograms);
        }
    }
}
