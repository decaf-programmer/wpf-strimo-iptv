using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Models;
using StrimoUI.Globals;
using StrimoUI.Messages;
using StrimoUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI.Pages.ViewModels.Login
{
    public class LoadAccountViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;
        public string username = null;
        public string password = null;

        private int loadAccountProgressBarValue;
        public int LoadAccountProgressBarValue
        {
            get
            {
                return loadAccountProgressBarValue;
            }
            set
            {
                if (loadAccountProgressBarValue == value)
                {
                    return;
                }
                loadAccountProgressBarValue = value;
                NotifyOfPropertyChange(() => LoadAccountProgressBarValue);
            }
        }

        public LoadAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            if (GlobalVars.currentAuthInfo != null)
            {
                username = GlobalVars.currentAuthInfo.user_info.username;
                password = GlobalVars.currentAuthInfo.user_info.password;
                await DownloadData();
                eventAggregator.PublishOnUIThread(new LoadedAccountMessage());
            } 
        }
        
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }


        private async Task DownloadData()
        {
            Progress<int> progress = new Progress<int>();
            progress.ProgressChanged += ReportProgress;
            

            List<List<XCCategoryModel>> allCategories = await XtreamCodeService.DownloadAllCategories(username, password, XCCommands.GET_CATEGORIES, progress, LoadAccountProgressBarValue);

            List<XCLiveStreamModel> liveStreams = await XtreamCodeService.ReadLiveStreams(username, password, progress, LoadAccountProgressBarValue);
            List<XCVodStreamModel> vodStreams = await XtreamCodeService.ReadVodStreams(username, password, progress, LoadAccountProgressBarValue);
            
            List<XCSerieStreamModel> serieStreams = await XtreamCodeService.ReadSerieStreams(username, password, progress, LoadAccountProgressBarValue);
            List<XCLiveStreamModel> radioStreams = liveStreams.Where<XCLiveStreamModel>(liveStream => liveStream.stream_type == "radio_streams").ToList();

            // Extract Global Vod IDs...

            // SET the Variables to Global Vars...
            // SET the Categories into Global Vars...
            foreach (List<XCCategoryModel> categoryList in allCategories)
            {
                switch (categoryList[0].category_type)
                {
                    case XCCategoryType.Live:
                        GlobalVars.currentUserLiveCategories = categoryList;
                        break;
                    case XCCategoryType.Movie:
                        GlobalVars.currentUserVodCategories = categoryList;
                        break;
                    case XCCategoryType.Serie:
                        GlobalVars.currentUserSerieCategories = categoryList;
                        break;
                }
            }

            // SET the Streams into Global Vars...
            GlobalVars.currentLiveStreams = liveStreams;
            GlobalVars.currentSerieStreams = serieStreams;
            GlobalVars.currentVodStreams = vodStreams;
            GlobalVars.currentRadioStreams = radioStreams;





            PrepareHomeView(progress, LoadAccountProgressBarValue);

        }

        public void PrepareHomeView(IProgress<int> progress, int currentProgress)
        {
            List<XCLiveStreamModel> latestLiveStreams = new List<XCLiveStreamModel>();
            List<XCSerieStreamModel> latestSerieStreams = new List<XCSerieStreamModel>();
            List<XCVodStreamModel> latestVodStreams = new List<XCVodStreamModel>();
            List<XCLiveStreamModel> latestRadioStreams = new List<XCLiveStreamModel>();

            latestLiveStreams = GlobalVars.currentLiveStreams.OrderByDescending(liveStream => liveStream.added).Take<XCLiveStreamModel>(10).ToList();
            latestSerieStreams = GlobalVars.currentSerieStreams.OrderByDescending(serieStream => serieStream.last_modified).Take<XCSerieStreamModel>(10).ToList();
            latestVodStreams = GlobalVars.currentVodStreams.OrderByDescending(vodStream => vodStream.added).Take<XCVodStreamModel>(10).ToList();
            latestRadioStreams = GlobalVars.currentRadioStreams.OrderByDescending(radioStream => radioStream.added).Take<XCLiveStreamModel>(10).ToList();

            List<CarouselModel> latestLiveCarouselList = new List<CarouselModel>();
            List<CarouselModel> latestVodCarouselList = new List<CarouselModel>();
            List<CarouselModel> latestSerieCarouselList = new List<CarouselModel>();
            List<CarouselModel> latestRadioCarouselList = new List<CarouselModel>();

            latestLiveCarouselList = Utility.ConvertStreamListToCarouselList(latestLiveStreams);
            latestVodCarouselList = Utility.ConvertStreamListToCarouselList(latestVodStreams);
            latestSerieCarouselList = Utility.ConvertStreamListToCarouselList(latestSerieStreams);
            latestRadioCarouselList = Utility.ConvertStreamListToCarouselList(latestRadioStreams);

            // Set First Item of all Streams to Active...
            // Set the Vod Or Serie 
            latestVodCarouselList[1].CarouselItemActive = true;
            latestVodCarouselList[1].CarouselItemImageHeight = 349;
            latestVodCarouselList[1].CarouselItemImageTop = 0;

            latestSerieCarouselList[1].CarouselItemActive = true;
            latestSerieCarouselList[1].CarouselItemImageHeight = 349;
            latestSerieCarouselList[1].CarouselItemImageTop = 0;

            for(int i = 1; i < 6; i++)
            {
                latestLiveCarouselList[i].CarouselItemActive = true;
            }

            currentProgress += 15;
            progress.Report(currentProgress);

            GlobalVars.latestLiveCarouselList = latestLiveCarouselList;
            GlobalVars.latestSerieCaoureslList = latestSerieCarouselList;
            GlobalVars.latestVodCarouselList = latestVodCarouselList;
            GlobalVars.latestRadioCarouselList = latestRadioCarouselList;

        }

        private void ReportProgress(object sender, int e)
        {
            LoadAccountProgressBarValue = e;
        }

        
    }

    
}
