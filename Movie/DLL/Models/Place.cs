using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Place
    {
        public int Id { get; set; }

        public int Row { get; set; }
        public int RowNumber { get; set; }

        public int Cost { get; set; }

        public CinemaHall Hall { get; set; }
        public List<Booking> Booking { get; set; }

    }
}
