using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Class
{
    class Employee : User
    {
        public int ID { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

    }
}
