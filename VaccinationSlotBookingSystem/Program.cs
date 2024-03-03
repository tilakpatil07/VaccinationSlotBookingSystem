using System.Diagnostics;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VaccinationSlotBookingSystem
{
    public class VaccinationSlotBookingSystem
    {
        public static void Main(string[] args)
        {
            int numberOfHospitals = 100;
            int numberOfDays = 100;
            TestDataGenerator.pinRangeStart = 411001;
            TestDataGenerator.pinRangeEnd = 411005;
            string searchPin;
            Stopwatch stopwatch = new Stopwatch();
            TimeCalculator timeCalculator = new TimeCalculator();

            //Commented code to calculate data generation time for multiple number of hospitals.
            //timeCalculator.CalculateDataGenerationTime();

            //Populates hospital list with random data.
            List<Hospital> hospitalList = TestDataGenerator.GenerateHospitalList(numberOfHospitals, numberOfDays);

            //Commented code to calculate the search time for given pincode
            //timeCalculator.CalculateSearchTime(hospitalList);

            Console.WriteLine("Vaccination Center and Slot Availability");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter a pincode to search for hospital(s): ");

                searchPin = CheckPinValidity();

                // Search functionality implementation
                List<Hospital> hospitalsAtPin = BookingSystem.SearchHospitalsByPin(int.Parse(searchPin), hospitalList);

                if (hospitalsAtPin.Count == 0)
                {
                    Console.WriteLine("0 Hospitals found in your area.");
                    continue;
                }

                // Displays available hospital and slot details 
                PrintHospitalDetails(hospitalsAtPin);

            }
        }

        public static string CheckPinValidity()
        {
            string searchPin;
            while (true)
            {
                searchPin = (Console.ReadLine());

                //Validating if user input is correct
                if (DataValidator.IsValidPin(searchPin)) break;
                else
                {
                    if (searchPin.Length != 6)
                    {
                        Console.WriteLine("The pin you have entered is invalid.\nPlease enter a 6-digit valid pin.");
                    }
                    else
                    {
                        Console.WriteLine($"The pin you have entered is invalid.\nPlease enter pin within valid range({TestDataGenerator.pinRangeStart}-{TestDataGenerator.pinRangeEnd}).");
                    }
                }
            }
            return searchPin;
        }

        public static void PrintHospitalDetails(List<Hospital> hospitalsAtGivenPin)
        {
            // Displays Name, address, pin and available slots;
            Console.WriteLine();
            Console.WriteLine($"{hospitalsAtGivenPin.Count} hospital(s) found at your provided pincode.");
            Console.WriteLine();

            Console.WriteLine("Enter the number of days to display the slots for");
            int daysToDisplay = int.Parse(Console.ReadLine());

            foreach (var hospital in hospitalsAtGivenPin)
            {
                Console.WriteLine(hospital.hospitalName);
                Console.WriteLine(hospital.hospitalAddress);
                Console.WriteLine(hospital.hospitalPin);
                Console.WriteLine();
                PrintSlotDetails(hospital, daysToDisplay);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public static void PrintSlotDetails(Hospital Hospital, int daysToDisplay)
        {
            // Displays date and available number of slots respectively 
            List<Slot> slotList = Hospital.availableSlotsList;

            for (int day = 0; day < daysToDisplay; day++)
            {
                Console.WriteLine($"Date: {slotList[day].date}");
                Console.WriteLine($"Free slots: {slotList[day].numberOfAvailableSlots}");
                Console.WriteLine("----------------------");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
