using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDay { get; set; }
        public float salary { get; set; }
        public int PhoneNumber { get; set; }
        public string Role { get; set; }

        public int LoginDataId { get; set; }

        public LoginData Login { get; set; }

    }
}
