
using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoUI.Globals;
using StrimoUI.Messages;
using StrimoUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        }

        protected override void OnActivate()
        {
            base.OnActivate();

            List<CategoryModel> liveCategories = GlobalVars.currentUserLiveCategories;
            List<SubItemModel> liveSubItems = new List<SubItemModel>();

            foreach (CategoryModel liveCategory in liveCategories)
            {
                liveSubItems.Add(
                    new SubItemModel()
                    {
                        Name = liveCategory.category_name,
                        CategoryId = liveCategory.category_id,
                        ParentId = liveCategory.parent_id,
                        CategoryType = liveCategory.category_type,
                        Screen = new UserControl()
                    }
                );
            }

            List<CategoryModel> serieCategories = GlobalVars.currentUserSerieCategories;
            List<SubItemModel> serieSubItems = new List<SubItemModel>();

            foreach (CategoryModel serieCategory in serieCategories)
            {
                serieSubItems.Add(
                    new SubItemModel()
                    {
                        Name = serieCategory.category_name,
                        CategoryId = serieCategory.category_id,
                        ParentId = serieCategory.parent_id,
                        CategoryType = serieCategory.category_type,
                        Screen = new UserControl()
                    }
                );
            }

            List<CategoryModel> vodCategories = GlobalVars.currentUserVodCategories;
            List<SubItemModel> vodSubItems = new List<SubItemModel>();

            foreach (CategoryModel vodCategory in vodCategories)
            {
                vodSubItems.Add(
                    new SubItemModel()
                    {
                        Name = vodCategory.category_name,
                        CategoryId = vodCategory.category_id,
                        ParentId = vodCategory.parent_id,
                        CategoryType = vodCategory.category_type,
                        Screen = new UserControl()
                    }
                );
            }


            NavigationMenuItems = new ObservableCollection<NavigationItemViewModel>() {
               new NavigationItemViewModel("H O M E", "home", null, new UserControl()),
               new NavigationItemViewModel("L I V E  T V", "monitor", liveSubItems, new UserControl()),
               new NavigationItemViewModel("M O V I E S", "movie", vodSubItems, new UserControl()),
               new NavigationItemViewModel("T V  S E R I E S", "tvseries", serieSubItems, new UserControl()),
               new NavigationItemViewModel("R A D I O", "radio", null, new UserControl()),    // This should be changed because radio will change...
               new NavigationItemViewModel("R E C O R D I N G S", "record", null, new UserControl()), // This should be changed because radio will change...
               new NavigationItemViewModel("F A V O U R I T E", "favorite", null, new UserControl()) // This should be changed because radio will change...
            };
        }
    }
}
