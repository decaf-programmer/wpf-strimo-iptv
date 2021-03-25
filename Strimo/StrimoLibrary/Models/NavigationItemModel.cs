using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoLibrary.Models
{
    public class NavigationItemModel:PropertyChangedBase
    {
        private string navigationItemIcon;

        public string NavigationItemIcon { 
            get { return $"/StrimoUI;component/Resources/{navigationItemIcon}"; }
            set { 
                if(navigationItemIcon == value)
                {
                    return;
                }
                navigationItemIcon = value;
                NotifyOfPropertyChange(() => NavigationItemIcon);
            } 
        }

        public string NavigationItemTitle { get; set; }
        public ObservableCollection<NavigationItemSubItemModel> NavigationItemSubItems { get; set; }
    }
}
