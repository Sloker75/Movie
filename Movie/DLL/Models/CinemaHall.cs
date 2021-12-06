using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class CinemaHall
    {
        public int Id { get; set; }

        public int HallRoom { get; set; }
        public Place Place { get; set; }
        public List<Session> Sessions { get; set; }

    }
}
