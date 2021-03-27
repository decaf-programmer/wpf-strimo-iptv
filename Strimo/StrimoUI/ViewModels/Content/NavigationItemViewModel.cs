using Caliburn.Micro;
using StrimoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StrimoUI.ViewModels.Content
{
    public class NavigationItemViewModel:Screen
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                if(_header == value)
                {
                    return;
                }
                _header = value;
                NotifyOfPropertyChange(() => Header);
            }
        }

        private string _imageName;
        public string ImageName
        {
            get { return _imageName; }
            set
            {
                if (_imageName == value)
                {
                    return;
                }
                _imageName = value;
                NotifyOfPropertyChange(() => ImageName);
            }
        }

        private List<SubItemModel> _subItems;
        public List<SubItemModel> SubItems{
            get{
                return _subItems;
            }
            set{
                if(_subItems == value){
                    return;
                }

                _subItems = value;
                NotifyOfPropertyChange(() => SubItems);
            }
        }

        private UserControl _screen;
        public UserControl Screen 
        { 
            get{
                return _screen;
            }
            set{
                if(_screen == value){
                    return;
                }
                _screen = value;
                NotifyOfPropertyChange(() => Screen);
            }
        }


        public NavigationItemViewModel()
        {
        }

        public NavigationItemViewModel(string header, string imageName, List<SubItemModel> subItems, UserControl screen){
            Header = header;
            ImageName = imageName;
            SubItems = subItems;
            Screen = screen;
        }
    }
}
