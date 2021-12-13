using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public bool IsBooking { get; set; }
        public int PhoneNumber { get; set; }
        public Session Session { get; set; }
        public Employee Employee { get; set; }
        public Place Place { get; set; }
    }
}
