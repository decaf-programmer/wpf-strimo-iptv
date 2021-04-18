using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class XCServerInfoModel
    {
        public string url { get; set; }
        public string port { get; set; }
        public string https_port { get; set; }
        public string server_protocol { get; set; }
        public string rtmp_port { get; set; }
        public string timezone { get; set; }
        public long timestamp_now { get; set; }
        public string time_now { get; set; }
    }
}
