using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StrimoUI.ViewModels.Content
{
    public class ItemMenu
    {
        public ItemMenu(string header, List<SubItem> subItems, string imageName)
        {
            Header = header;
            SubItems = subItems;
            ImageName = imageName;
        }

        public ItemMenu(string header, UserControl screen, string imageName)
        {
            Header = header;
            Screen = screen;
            ImageName = imageName;
        }

        public string Header { get; set; }
        public string ImageName { get; set; }
        public List<SubItem> SubItems { get; set; }
        public UserControl Screen { get; set; }
    }
}
