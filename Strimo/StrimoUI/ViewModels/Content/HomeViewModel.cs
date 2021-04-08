
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StrimoUI.ViewModels.Content
{
    public class HomeViewModel : Screen, IHandle<NavigationItemClickedMessage>
    //IHandleWithCoroutine<NavigationItemClickedMessage>
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
            eventAggregator.Subscribe(this);

        }

        protected override void OnActivate()
        {
            base.OnActivate();

            //eventAggregator.Subscribe(this);

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
               new NavigationItemViewModel("H O M E", "home", null, new UserControl(), eventAggregator),
               new NavigationItemViewModel("L I V E  T V", "monitor", liveSubItems, new UserControl(), eventAggregator),
               new NavigationItemViewModel("M O V I E S", "movie", vodSubItems, new UserControl(), eventAggregator),
               new NavigationItemViewModel("T V  S E R I E S", "tvseries", serieSubItems, new UserControl(), eventAggregator),
               new NavigationItemViewModel("R A D I O", "radio", null, new UserControl(), eventAggregator),    // This should be changed because radio will change...
               new NavigationItemViewModel("R E C O R D I N G S", "record", null, new UserControl(), eventAggregator), // This should be changed because radio will change...
               new NavigationItemViewModel("F A V O U R I T E", "favorite", null, new UserControl(), eventAggregator) // This should be changed because radio will change...
            };
        }

        public void Handle(NavigationItemClickedMessage message)
        {

            //foreach(NavigationItemViewModel item in NavigationMenuItems)
            //{
            //    if (item.Header == message.ClickedItemTitle)
            //        continue;

            //    Console.WriteLine(item.Header + " Item Expander Result: " + item.IsMenuExpanded);
            //    item.IsMenuExpanded = false;
            //    string iconName = extractIconStr(item.ImageName);
            //    item.ImageName = $"{iconName.Split('_')[0]}";
            //    item.TitleForegroundColor = ((SolidColorBrush)new BrushConverter().ConvertFrom("#808182"));

            //    Console.WriteLine(item.Header + " Item Expander Result: " + item.IsMenuExpanded);
            //}

        }

        public string extractIconStr(string temp)
        {
            string pattern = @"^\/.*\/([^\/]+)\.png$";
            Regex regex = new Regex(pattern);

            MatchCollection matchCollection = regex.Matches(temp);
            return matchCollection[0].Groups[1].Value;
        }
    }
}
