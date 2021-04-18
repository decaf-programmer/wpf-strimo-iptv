using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class XCAuthInfoModel
    {
        public XCUserInfoModel user_info { get; set; }
        public XCServerInfoModel server_info { get; set; }
    }
}
