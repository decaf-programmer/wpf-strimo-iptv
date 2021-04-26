using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Models;
using StrimoUI.Components.ViewModels;
using StrimoUI.Globals;
using StrimoUI.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class MovieViewModel:Screen
    {
        private IEventAggregator eventAggregator;

        public CarouselListViewModel LatestMovieCarouselList { get; set; }

        public ObservableCollection<CarouselListViewModel> GenreList { get; set; }
        
        public MovieViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

            ObservableCollection<CarouselModel> latestVodCollection = new ObservableCollection<CarouselModel>(GlobalVars.latestVodCarouselList);
            LatestMovieCarouselList = new CarouselListViewModel()
            {
                CarouselListHeader = "Latest Movies",
                CarouselListWidth = 1920,
                CarouselListHeight = 390,
                CarouselListCollection = latestVodCollection
            };


            SetGenreList();

            GenreList = new ObservableCollection<CarouselListViewModel>();

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        public void SetGenreList()
        {
            GenreList = new ObservableCollection<CarouselListViewModel>();
            foreach (XCCategoryModel categoryModel in GlobalVars.currentUserVodCategories)
            {
                CarouselListViewModel oneGenreListView = new CarouselListViewModel();
                

                var categoryId = categoryModel.category_id;
                List<XCVodStreamModel> selectedGenreVodStreams = GlobalVars.currentVodStreams.Where<XCVodStreamModel>(vodStream => vodStream.category_id == categoryId).ToList();

                
                List<CarouselModel> selectedStreamCarouselList = Utility.ConvertStreamListToCarouselList(selectedGenreVodStreams);
                ObservableCollection<CarouselModel> selectedStreamCarouselCollection = new ObservableCollection<CarouselModel>(selectedStreamCarouselList);

                oneGenreListView.CarouselListHeader = categoryModel.category_name;
                oneGenreListView.CarouselListWidth = 1920;
                oneGenreListView.CarouselListHeight = 222;
                oneGenreListView.CarouselListCollection = selectedStreamCarouselCollection;

                GenreList.Add(oneGenreListView);
            }

            Console.WriteLine(GenreList);
        }

        

    }
}
