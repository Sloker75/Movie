using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string MovieTitle { get; set; }
        public int Genre { get; set; }
        public DateTime MovieDuration { get; set; }
    }
}
