using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace VaccinationSlotBookingSystem;

public static class TestDataGenerator
{
    public static int pinRangeStart;
    public static int pinRangeEnd;

    // Generates a list of hospital details and populates the Hospital list with random dummy values.
    public static List<Hospital> GenerateHospitalList(int numberOfHospitals, int numberOfDays)
    {
        // Generating Bogus library object
        Faker faker = new();

        // Initialising new hospital list object
        List<Hospital> hospitalList = new List<Hospital>();

        for (int hospitalCount = 0; hospitalCount < numberOfHospitals; hospitalCount++)
        {
            // Generating dummy hospital details using faker object
            int hospitalPin = faker.Random.Int(pinRangeStart,pinRangeEnd);        
            string hospitalName = faker.Name.FullName()+" Hospital";  
            string hospitalAddress = faker.Address.FullAddress();
            List<Slot> availableSlotsList = GenerateSlotList(numberOfDays);       

            // Generating new hospital object and passing generated values to parameterised constructor
            Hospital hospital = new Hospital(hospitalName,hospitalAddress,hospitalPin,availableSlotsList); 
            hospitalList.Add(hospital);
        }

        return hospitalList;

    }




    // Generates a slot list populated with date and number of random available slots.
    public static List<Slot> GenerateSlotList(int numberOfDays)
    {

         List<Slot> slotList = new List<Slot>();
        
        Faker faker = new();

        for(int day = 0; day <= numberOfDays; day++)
        {
            // Generating dummy slot details
            Slot slot=new Slot();
            slot.numberOfAvailableSlots = faker.Random.Int(1, 100);
            slot.date = DateOnly.FromDateTime(DateTime.Now).AddDays(day);
            slotList.Add(slot);

        }
        return slotList;

    }





}
