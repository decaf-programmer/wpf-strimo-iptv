using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoDBLibrary.Models
{
    public class SQLUserModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public int loginStatus { get; set; }
        public string lastLoginDate { get; set; }
    }
}
