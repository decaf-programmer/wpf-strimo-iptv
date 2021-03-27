
using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StrimoUI.ViewModels.Content
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        
        private ObservableCollection<NavigationItemViewModel> _navigationMenuItems;
        public ObservableCollection<NavigationItemViewModel> NavigationMenuItems 
        {
            get 
            {
                return _navigationMenuItems;
            }
            set
            {
                _navigationMenuItems = value;
                NotifyOfPropertyChange(() => NavigationMenuItems);
            }
        }

        public HomeViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;

            List<SubItemModel> liveSubItems = new List<SubItemModel>();
            liveSubItems.Add(new SubItemModel() { Name = "Romania", Screen = new UserControl() });
            liveSubItems.Add(new SubItemModel() { Name = "United Kingdom", Screen = new UserControl() });
            liveSubItems.Add(new SubItemModel() { Name = "United States", Screen = new UserControl() });
            liveSubItems.Add(new SubItemModel() { Name = "French", Screen = new UserControl() });
            liveSubItems.Add(new SubItemModel() { Name = "Canada", Screen = new UserControl() });
            liveSubItems.Add(new SubItemModel() { Name = "Italy", Screen = new UserControl() });

            NavigationMenuItems = new ObservableCollection<NavigationItemViewModel>() {
               new NavigationItemViewModel("H O M E", "home.png", null, new UserControl()),
               new NavigationItemViewModel("L I V E", "live.png", liveSubItems, new UserControl())
             };
        }
    }
}
