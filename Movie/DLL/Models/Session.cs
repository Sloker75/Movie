using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime startOfTheSession { get; set; }
        public DateTime endOfTheSession { get; set; }


        public CinemaHall Hall { get; set; }
        public Film Film { get; set; }
    }
}
