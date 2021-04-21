using Caliburn.Micro;
using StrimoUI.Components.Models;
using StrimoUI.Components.ViewModels;
using StrimoUI.Globals;
using StrimoUI.Utilities;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class DashboardViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;
        public ObservableCollection<CarouselListViewModel> DashCarouselLists { get; set; }

        public string Username { get; set; }
        public string Status { get; set; }
        public string AllowedFormats { get; set; }
        public string Trial { get; set; }
        public string Maxconnections { get; set; }
        public string CreatedAt { get; set; }
        public string Expired { get; set; }
        

        public DashboardViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            eventAggregator.Subscribe(this);

            // Set the Carousel Lists...
            ObservableCollection<CarouselModel> latestVodCollection = new ObservableCollection<CarouselModel>(GlobalVars.latestVodCarouselList);
            ObservableCollection<CarouselModel> latestLiveCollection = new ObservableCollection<CarouselModel>(GlobalVars.latestLiveCarouselList);
            ObservableCollection<CarouselModel> latestSerieCollection = new ObservableCollection<CarouselModel>(GlobalVars.latestSerieCaoureslList);
            ObservableCollection<CarouselModel> latestRadioCollection = new ObservableCollection<CarouselModel>(GlobalVars.latestRadioCarouselList);

            DashCarouselLists = new ObservableCollection<CarouselListViewModel>()
            {
                new CarouselListViewModel()
                {
                    CarouselListHeader = "Latest Movies",
                    CarouselListWidth = 1920,
                    CarouselListHeight = 390,
                    CarouselListCollection = latestVodCollection
                },
                new CarouselListViewModel()
                {
                    CarouselListHeader = "Favourite Lives",
                    CarouselListWidth = 1920,
                    CarouselListHeight = 222,
                    CarouselListCollection = latestLiveCollection
                },
                new CarouselListViewModel()
                {
                    CarouselListHeader = "Latest Series",
                    CarouselListWidth = 1920,
                    CarouselListHeight = 390,
                    CarouselListCollection = latestSerieCollection
                },
                new CarouselListViewModel()
                {
                    CarouselListHeader = "Favourtie Radios",
                    CarouselListWidth = 1920,
                    CarouselListHeight = 222,
                    CarouselListCollection = latestRadioCollection
                }
            };

            // Set User Info...
            Username = Utility.MakeLetterSpace(GlobalVars.currentAuthInfo.user_info.username);
            Status = Utility.MakeLetterSpace(GlobalVars.currentAuthInfo.user_info.status);
            AllowedFormats = Utility.MakeLetterSpace(string.Join(" , ", GlobalVars.currentAuthInfo.user_info.allowed_output_formats));
            Trial = Utility.MakeLetterSpace(GlobalVars.currentAuthInfo.user_info.is_trial == "0" ? "No" : "Yes");
            Maxconnections = Utility.MakeLetterSpace(GlobalVars.currentAuthInfo.user_info.max_connections);
            CreatedAt = Utility.MakeLetterSpace(Utility.MilliSecondsToDate(GlobalVars.currentAuthInfo.user_info.created_at));
            Expired = Utility.MakeLetterSpace(Utility.MilliSecondsToDate(GlobalVars.currentAuthInfo.user_info.exp_date));

        }

    }
}
