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
        public UserControl Screen { get; set; }


        public string CategoryId { get; set; }
        public int ParentId { get; set; }
        public Enum CategoryType { get; set; }
        
    }
}
