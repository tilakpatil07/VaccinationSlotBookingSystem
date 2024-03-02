using System.Diagnostics;
using System.Net.NetworkInformation;

namespace VaccinationSlotBookingSystem
{   
    public class VaccinationSlotBookingSystem
    {
        public static void Main(string[] args)
        {
            int numberOfHospitals = 10000;
            int numberOfDays = 100;
            TestDataGenerator.pinRangeStart = 411001;
            TestDataGenerator.pinRangeEnd = 411005;
            string searchPin;


            // Populates hospital list with random data.
            List<Hospital> hospitalList = TestDataGenerator.GenerateHospitalList(numberOfHospitals, numberOfDays); 

            Console.WriteLine("Vaccination Center and Slot Availability");
            Console.WriteLine();
            while(true)
            {

                Console.WriteLine("Enter a pincode to search for hospital(s): ");

                searchPin = CheckPinValidity();

                // Starting the time
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Search functionality implementation
                List<Hospital> hospitalsAtPin = BookingSystem.SearchHospitalsByPin(int.Parse(searchPin), hospitalList);

                //Stopping the time
                stopwatch.Stop();


                if (hospitalsAtPin.Count == 0)
                {
                    Console.WriteLine("0 Hospitals found in your area.");
                    continue;
                }

                // Displays available hospital and slot details 
                //PrintHospitalDetails(hospitalsAtPin);
                Console.WriteLine($"{hospitalsAtPin.Count} hospital(s) found at your provided pincode.");
                Console.WriteLine($"Took {stopwatch.Elapsed.TotalMilliseconds.ToString()} milliseconds to search in database of {numberOfHospitals} records. Found {hospitalsAtPin.Count} matching hospital(s).");
            }
        }

        private static string CheckPinValidity()
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

        //public static void PrintHospitalDetails(List<Hospital> hospitalsAtGivenPin)
        //{
        //    // Displays Name, address, pin and available slots;
        //    Console.WriteLine();
        //    Console.WriteLine($"{hospitalsAtGivenPin.Count} hospital(s) found at your provided pincode.");
        //    Console.WriteLine();

        //    Console.WriteLine("Enter the number of days to display the slots for");
        //    int daysToDisplay = int.Parse(Console.ReadLine());

        //    foreach (var hospital in hospitalsAtGivenPin)
        //    {
        //        Console.WriteLine(hospital.hospitalName);
        //        Console.WriteLine(hospital.hospitalAddress);
        //        Console.WriteLine(hospital.hospitalPin);
        //        Console.WriteLine();
        //        PrintSlotDetails(hospital, daysToDisplay);
        //        Console.WriteLine();
        //        Console.WriteLine();
        //    }
        //}

        //public static void PrintSlotDetails(Hospital Hospital, int daysToDisplay)
        //{
        //    // Displays date and available number of slots respectively 
        //    List<Slot> slotList = Hospital.availableSlotsList;

        //    for (int day = 0; day < daysToDisplay; day++)
        //    {
        //        Console.WriteLine($"Date: {slotList[day].date}");
        //        Console.WriteLine($"Free slots: {slotList[day].numberOfAvailableSlots}");
        //        Console.WriteLine("----------------------");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine();
        //}
    }
}
