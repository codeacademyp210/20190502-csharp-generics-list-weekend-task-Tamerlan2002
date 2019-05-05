using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Class
{
    class User
    {
        public static int Id { get; set; } = 1;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int GetId()
        {
            return Id++;
        }
    }
}
