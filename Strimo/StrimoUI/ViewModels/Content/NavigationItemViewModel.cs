using Caliburn.Micro;
using StrimoUI.Messages;
using StrimoUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StrimoUI.ViewModels.Content
{
    public class NavigationItemViewModel : Screen
    {
        private string _header;
        public string Header
        {
            get { return _header; }
            set
            {
                if (_header == value)
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
            get { return $"/StrimoUI;component/Resources/{_imageName}.png"; }
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
        public List<SubItemModel> SubItems {
            get {
                return _subItems;
            }
            set {
                if (_subItems == value) {
                    return;
                }

                _subItems = value;
                NotifyOfPropertyChange(() => SubItems);
            }
        }

        private UserControl _screen;
        public UserControl Screen
        {
            get {
                return _screen;
            }
            set {
                if (_screen == value) {
                    return;
                }
                _screen = value;
                NotifyOfPropertyChange(() => Screen);
            }
        }

        private bool _listViewItemVisible;
        public bool ListViewItemVisible
        {
            get
            {
                return _listViewItemVisible;
            }
            set
            {
                _listViewItemVisible = value;
                NotifyOfPropertyChange(() => ListViewItemVisible);
            }
        }


        private bool _expanderVisibile;
        public bool ExpanderVisible
        {
            get
            {
                return _expanderVisibile;
            }
            set
            {
                _expanderVisibile = value;
                NotifyOfPropertyChange(() => ExpanderVisible);
            }
        }

        private SolidColorBrush _titleForegroundColor;
        public SolidColorBrush TitleForegroundColor
        {
            get{
                return _titleForegroundColor;
            }
            set{
                _titleForegroundColor = value;
                NotifyOfPropertyChange(() => TitleForegroundColor);
            }
        }
        public NavigationItemViewModel(string header, string imageName, List<SubItemModel> subItems, UserControl screen){
            Header = header;
            ImageName = imageName;
            SubItems = subItems;
            Screen = screen;

            ListViewItemVisible = SubItems == null ? true : false;
            ExpanderVisible = SubItems == null ? false : true;

            TitleForegroundColor = ((SolidColorBrush)new BrushConverter().ConvertFrom("#808182"));
        }

        public string extractIconStr(string temp)
        {
            string pattern = @"^\/.*\/([^\/]+)\.png$";
            Regex regex = new Regex(pattern);

            MatchCollection matchCollection = regex.Matches(temp);
            return matchCollection[0].Groups[1].Value;

        }

        public void NavigationMenuItemMouseEnter()
        {
            string iconName = extractIconStr(ImageName);
            ImageName = $"{iconName}_active";
            TitleForegroundColor = ((SolidColorBrush)new BrushConverter().ConvertFrom("#F5F5F5"));
        }

        public void NavigationMenuItemMouseLeave()
        {
            string iconName = extractIconStr(ImageName);
            
            ImageName = $"{iconName.Split('_')[0]}";
            TitleForegroundColor = ((SolidColorBrush)new BrushConverter().ConvertFrom("#808182"));
        }

        
    }
}
