using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    public class Member
    {
        public string Account { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public int? Telphone { get; set; }

        public string Email { get; set; }

        public string PassWord { get; set; }

        public bool? isAdmin { get; set; }
    }
}
