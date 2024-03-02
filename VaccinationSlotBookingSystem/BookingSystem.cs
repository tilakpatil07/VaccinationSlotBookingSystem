using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationSlotBookingSystem
{
    // consists of method to search hospital by provided pincode
    public static class BookingSystem 
    {
        public static List<Hospital> SearchHospitalsByPin(int searchForPin, List<Hospital> hospitalList)
        {
            // return list of hospitals found at provided pincode;
            List<Hospital> hospitalsAtGivenPin = new List<Hospital>();

            foreach(var hospital in hospitalList)
            {
                if(hospital.hospitalPin == searchForPin)
                {
                    hospitalsAtGivenPin.Add(hospital);
                }
            }
            return hospitalsAtGivenPin;
        }
    }
}
