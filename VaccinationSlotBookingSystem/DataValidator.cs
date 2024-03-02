using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationSlotBookingSystem
{
    // consists of data validation methods
    public static class DataValidator
    {
        public static bool IsValidData(int hospitalPin, string hospitalAddress, string hospitalName)
        {
            // Checks if provided data is in valid format
            bool isValidName = !(string.IsNullOrEmpty(hospitalName));
            bool isValidAddress = !(string.IsNullOrEmpty(hospitalAddress));
            bool isValidPin = (hospitalPin >= 411001 && hospitalPin <= 411100) ? true : false;
            
            return (isValidName && isValidAddress && isValidPin);
        }

        public static bool IsValidPin(string userPin)
        {   
            return (userPin.Length == 6  && int.Parse(userPin) >= TestDataGenerator.pinRangeStart && int.Parse(userPin) <= TestDataGenerator.pinRangeEnd) ? true : false;
        }
    }
}
