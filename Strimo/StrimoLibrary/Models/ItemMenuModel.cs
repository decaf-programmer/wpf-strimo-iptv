using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StrimoLibrary.Models
{
    public class ItemMenuModel
    {
        public ItemMenuModel(string header, List<SubItemModel> subItems, string imageName)
        {
            Header = header;
            SubItems = subItems;
            ImageName = imageName;
        }

        public ItemMenuModel(string header, UserControl screen, string imageName)
        {
            Header = header;
            Screen = screen;
            ImageName = imageName;
        }

        public string Header { get; set; }
        public string ImageName { get; set; }
        public List<SubItemModel> SubItems { get; set; }
        public UserControl Screen { get; set; }
    }
}
