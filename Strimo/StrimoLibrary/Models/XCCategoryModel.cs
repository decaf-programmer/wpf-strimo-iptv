using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class XCCategoryModel
    {
        public string category_id { get; set; } = "";
        public string category_name { get; set; } = "";
        public int parent_id { get; set; } = 0;
        public XCCategoryType category_type { get; set; } = XCCategoryType.Undefined;
    }
}
