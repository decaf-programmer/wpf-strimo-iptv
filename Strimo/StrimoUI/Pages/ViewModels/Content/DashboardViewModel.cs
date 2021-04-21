using Caliburn.Micro;
using StrimoUI.Components.Models;
using StrimoUI.Components.ViewModels;
using StrimoUI.Globals;
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

        public DashboardViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            eventAggregator.Subscribe(this);

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
        }

    }
}
