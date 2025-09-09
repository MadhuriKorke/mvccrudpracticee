using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ClassesFolder
{
    public class USER
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int cityid { get; set; }
        public string city { get; set; }
        public int stateid { get; set; }
        public string State { get; set; }
        public int countryid { get; set; }
        public string country { get; set; }

        public string gender { get; set; }
        public List<USER> users { get; set; }
    }
}
