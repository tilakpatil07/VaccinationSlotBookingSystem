using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationSlotBookingSystem
{
    // Represents date and number of available slots.
    public class Slot
    {
        public DateOnly date;
        public int numberOfAvailableSlots;
    }
}
