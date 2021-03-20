using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsVideoDesktopApplicationLibrary
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public int auth { get; set; }
        public string message { get; set; }
        public string exp_date { get; set; }
        public string is_trial { get; set; }
        public string active_cons { get; set; }
        public string created_at { get; set; }
        public string[] allowed_output_formats { get; set; }
    }
}
