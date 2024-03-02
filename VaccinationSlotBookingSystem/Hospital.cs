using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationSlotBookingSystem
{
    // Represents hospital attributes as name, address, pin and available slots
    public class Hospital
    {
        public string hospitalName;
        public string hospitalAddress;
        public int hospitalPin;
        public List<Slot> availableSlotsList;

        public Hospital(string hospitalName,string hospitalAddress,int HospitalPin,List<Slot> slotList) 
        {
            // Checking wether entered data is in valid format or not.
            try
            {

                if(DataValidator.IsValidData(HospitalPin,hospitalAddress,hospitalName))
                {
                    // if data is valid, populating hospital object with provided details
                    this.hospitalPin = HospitalPin;
                    this.hospitalName = hospitalName;
                    this.hospitalAddress = hospitalAddress;
                    this.availableSlotsList = slotList;
                }
                else
                {

                    throw new Exception ("Invalid Data Encountered");
                    
                }

            }
            catch (Exception ex)
            {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);

                
            }
        }
    }
}
