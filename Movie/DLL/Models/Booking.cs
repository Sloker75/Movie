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
        public bool ISPaid { get; set; }
        public int PhoneNumber { get; set; }
        public Session Session { get; set; }
        public Employee Employee { get; set; }
    }
}
