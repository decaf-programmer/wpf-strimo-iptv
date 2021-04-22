using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Messages
{
    public class NavigationSubItemClickedMessage
    {
        public string SelectedCategoryId { get; set; }
        public XCCategoryType SelectedCategoryType { get; set; }
        //public CategoryType SelectedCategory{get;set;}
    }
}
