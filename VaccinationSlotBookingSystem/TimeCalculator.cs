using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationSlotBookingSystem
{
    public class TimeCalculator
    {
        Stopwatch stopwatch = new Stopwatch();
        public static List<int> numberOfHospitals = new List<int> {100, 1000, 10000, 100000, 1000000, 10000000};
        public static int numberOfDays = 100;
        public void CalculateDataGenerationTime()
        {
            foreach (int number in numberOfHospitals)
            {
                stopwatch.Start();
                List<Hospital> hospitalList = TestDataGenerator.GenerateHospitalList(number, numberOfDays);
                stopwatch.Stop();

                Console.WriteLine(number.ToString() + " => " + stopwatch.Elapsed.TotalMilliseconds.ToString());
            }
            Console.WriteLine("Data saved in file");
        }

        public void CalculateSearchTime(List<Hospital> hospitalList)
        {
            Console.WriteLine("Enter the Pin that you want to calculate the search time for: ");
            string searchPin = Console.ReadLine();
            // Starting the time
            stopwatch.Start();

            List<Hospital> hospitalsAtPin = BookingSystem.SearchHospitalsByPin(int.Parse(searchPin), hospitalList);

            //Stopping the time
            stopwatch.Stop();

            Console.WriteLine($"{hospitalsAtPin.Count} hospital(s) found at your provided pincode.");
            Console.WriteLine($"Took {stopwatch.Elapsed.TotalMilliseconds.ToString()} milliseconds to search in database of {numberOfHospitals} records. Found {hospitalsAtPin.Count} matching hospital(s).");
        }
    }
}
