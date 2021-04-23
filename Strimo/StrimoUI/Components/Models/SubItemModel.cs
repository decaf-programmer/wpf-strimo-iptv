using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StrimoUI.Pages.Models
{
    public class SubItemModel
    {

        public string Name { get; set; }

        public string CategoryId { get; set; }
        public int ParentId { get; set; }

        public XCCategoryType CategoryType { get; set; }
        
    }
}
