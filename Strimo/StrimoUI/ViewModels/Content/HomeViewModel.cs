using Caliburn.Micro;
using StrimoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Content
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;

        
        public ObservableCollection<NavigationItemModel> NavigationItems { get; set; }
        
        
        public HomeViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;

            NavigationItems = new ObservableCollection<NavigationItemModel>();
            ObservableCollection<NavigationItemSubItemModel> HomeNavigationItemSubItems = new ObservableCollection<NavigationItemSubItemModel>();
            HomeNavigationItemSubItems.Add(new NavigationItemSubItemModel { NavigationItemSubItemTitle = "aaa" });
            HomeNavigationItemSubItems.Add(new NavigationItemSubItemModel { NavigationItemSubItemTitle = "bbb" });
            HomeNavigationItemSubItems.Add(new NavigationItemSubItemModel { NavigationItemSubItemTitle = "ccc" });
            HomeNavigationItemSubItems.Add(new NavigationItemSubItemModel { NavigationItemSubItemTitle = "ddd" });

            NavigationItems.Add(new NavigationItemModel() { NavigationItemIcon = "home.png", NavigationItemTitle = "H o m e", NavigationItemSubItems= HomeNavigationItemSubItems });
            NavigationItems.Add(new NavigationItemModel() { NavigationItemIcon = "favorite.png", NavigationItemTitle = "H o m e", NavigationItemSubItems = HomeNavigationItemSubItems });
            NavigationItems.Add(new NavigationItemModel() { NavigationItemIcon = "movie.png", NavigationItemTitle = "H o m e", NavigationItemSubItems = HomeNavigationItemSubItems });
            NavigationItems.Add(new NavigationItemModel() { NavigationItemIcon = "tv_series.png", NavigationItemTitle = "H o m e", NavigationItemSubItems = HomeNavigationItemSubItems });
            NavigationItems.Add(new NavigationItemModel() { NavigationItemIcon = "record.png", NavigationItemTitle = "H o m e", NavigationItemSubItems = null });


        }

    }
}
