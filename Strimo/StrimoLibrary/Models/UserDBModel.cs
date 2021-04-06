using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class UserDBModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool loginStatus { get; set; }
        public string lastLoginDate { get; set; }
    }
}
