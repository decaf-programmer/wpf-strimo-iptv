using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoDBLibrary.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool loginStatus { get; set; }
        public string token { get; set; }
        public DateTime lastLoginStatus { get; set; }
    }
}
