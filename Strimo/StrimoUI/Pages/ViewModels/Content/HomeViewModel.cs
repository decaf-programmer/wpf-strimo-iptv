
using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoUI.Components.Models;
using StrimoUI.Components.ViewModels;
using StrimoUI.Globals;
using StrimoUI.Messages;
using StrimoUI.Pages.Models;
using StrimoUI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class HomeViewModel : Conductor<Screen>.Collection.OneActive, IHandle<NavigationItemClickedMessage>, IHandle<NavigationSubItemClickedMessage>
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

        public DashboardViewModel dashboardVM;
        public MovieViewModel movieViewModel;

        public HomeViewModel(IEventAggregator _eventAggregator, DashboardViewModel _dashboardVM, MovieViewModel _movieViewModel)
        {
            eventAggregator = _eventAggregator;
            eventAggregator.Subscribe(this);

            dashboardVM = _dashboardVM;
            movieViewModel = _movieViewModel;

            Items.AddRange(new Screen[] { dashboardVM, movieViewModel });
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);
            
            // Set NavigationMenu
            SetNavigationMenu();

            // Actiavet DashboardView
            ActivateItem(dashboardVM);
        }

        protected void SetNavigationMenu()
        {
            List<XCCategoryModel> liveCategories = GlobalVars.currentUserLiveCategories;
            List<SubItemModel> liveSubItems = new List<SubItemModel>();

            foreach (XCCategoryModel liveCategory in liveCategories)
            {
                liveSubItems.Add(
                    new SubItemModel()
                    {
                        Name = liveCategory.category_name,
                        CategoryId = liveCategory.category_id,
                        ParentId = liveCategory.parent_id,
                        CategoryType = liveCategory.category_type,
                    }
                );
            }

            List<XCCategoryModel> serieCategories = GlobalVars.currentUserSerieCategories;
            List<SubItemModel> serieSubItems = new List<SubItemModel>();

            foreach (XCCategoryModel serieCategory in serieCategories)
            {
                serieSubItems.Add(
                    new SubItemModel()
                    {
                        Name = serieCategory.category_name,
                        CategoryId = serieCategory.category_id,
                        ParentId = serieCategory.parent_id,
                        CategoryType = serieCategory.category_type,
                    }
                );
            }

            List<XCCategoryModel> vodCategories = GlobalVars.currentUserVodCategories;
            List<SubItemModel> vodSubItems = new List<SubItemModel>();

            foreach (XCCategoryModel vodCategory in vodCategories)
            {
                vodSubItems.Add(
                    new SubItemModel()
                    {
                        Name = vodCategory.category_name,
                        CategoryId = vodCategory.category_id,
                        ParentId = vodCategory.parent_id,
                        CategoryType = vodCategory.category_type,
                    }
                );
            }

            NavigationMenuItems = new ObservableCollection<NavigationItemViewModel>() {
               new NavigationItemViewModel("H O M E", "home", null, NavigationItemType.Home, eventAggregator),
               new NavigationItemViewModel("L I V E  T V", "monitor", liveSubItems, NavigationItemType.Live, eventAggregator),
               new NavigationItemViewModel("M O V I E S", "movie", vodSubItems,  NavigationItemType.Movies, eventAggregator),
               new NavigationItemViewModel("T V  S E R I E S", "tvseries", serieSubItems, NavigationItemType.Movies, eventAggregator),
               new NavigationItemViewModel("R A D I O", "radio", null, NavigationItemType.Movies, eventAggregator),    // This should be changed because radio will change...
               new NavigationItemViewModel("R E C O R D I N G S", "record", null, NavigationItemType.Movies, eventAggregator), // This should be changed because radio will change...
               new NavigationItemViewModel("F A V O U R I T E", "favorite", null, NavigationItemType.Movies, eventAggregator) // This should be changed because radio will change...
            };
        }

        // Router for the Navigation Menus...
        // Go to Pages Directly.
        public void Handle(NavigationItemClickedMessage message)
        {
            //MessageBox.Show(message.ClickedItemTitle);
            NavigationItemType selectedNavigationItemType = message.SelectedNavigationItemType;

            switch (selectedNavigationItemType)
            {
                case NavigationItemType.Home:
                    ActivateItem(dashboardVM);
                    break;
                case NavigationItemType.Live:
                    // Switch Right panel to Live Pane
                    break;
                case NavigationItemType.Movies:
                    // Switch Right panel to Movie Pane
                    ActivateItem(movieViewModel);
                    break;
                case NavigationItemType.Serie:
                    // Switch Right panel to Serie Pane
                    break;
                case NavigationItemType.Radio:
                    // Switch Right panel to Radio Pane
                    break;
                case NavigationItemType.Records:
                    // Switch Right panel to Records Pane
                    break;
                case NavigationItemType.Favorites:
                    // Switch Right panel to Favorites Pane
                    break;
                default:
                    // Switch Right panel to Home Pane
                    break;
            }

        }


        // Go to Pages for subItems in Lives, Movies, Series....
        public void Handle(NavigationSubItemClickedMessage message)
        {
            //message.SelectedCategoryType; // XCCategory;;;////
            // message.SelectedCategoryId; //  int;;; 
            switch (message.SelectedCategoryType)
            {
                case XCCategoryType.Live:
                    // Switch Right panel to Sub Live Pane
                    break;
                case XCCategoryType.Movie:
                    // Switch Right panel to Sub Movie Pane
                    break;
                case XCCategoryType.Serie:
                    // Switch Right panel to Sub Serie Pane
                    break;
                default:
                    break;
            }
        }
    }
}
