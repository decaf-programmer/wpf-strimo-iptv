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
            

            List<string> categoryActions = new List<string>();
            categoryActions.Add("get_live_categories");
            categoryActions.Add("get_series_categories");
            categoryActions.Add("get_vod_categories");

            List<List<XCCategoryModel>> allCategories = await XtreamCodeService.DownloadAllCategories(username, password, categoryActions, progress, LoadAccountProgressBarValue);

            List<XCLiveStreamModel> liveStreams = await XtreamCodeService.ReadLiveStreams(username, password, progress, LoadAccountProgressBarValue);
            List<XCVodStreamModel> vodStreams = await XtreamCodeService.ReadVodStreams(username, password, progress, LoadAccountProgressBarValue);
            List<XCSerieStreamModel> serieStreams = await XtreamCodeService.ReadSerieStreams(username, password, progress, LoadAccountProgressBarValue);

            //Sort the Streams...
            liveStreams.Sort((liveStream1, liveStream2) => liveStream2.added.CompareTo(liveStream1.added));
            vodStreams.Sort((vodStream1, vodStream2) => vodStream2.added.CompareTo(vodStream1.added));
            serieStreams.Sort((serieStream1, serieStream2) => serieStream2.last_modified.CompareTo(serieStream1.last_modified));

            // GET Last Streams...
            List<XCLiveStreamModel> lastLives = (List<XCLiveStreamModel>)liveStreams.Take(10);
            List<XCVodStreamModel> lastVods = (List<XCVodStreamModel>)vodStreams.Take(10);
            List<XCSerieStreamModel> lastSeries = (List<XCSerieStreamModel>)serieStreams.Take(10);

            // SET the Variables to Global Vars...
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

            GlobalVars.currentLiveStreams = liveStreams;
            GlobalVars.currentVodStreams = vodStreams;
            GlobalVars.currentSerieStreams = serieStreams;

            List<CarouselModel> vodCarouselList = new List<CarouselModel>();
            List<CarouselModel> liveCarouselList = new List<CarouselModel>();
            List<CarouselModel> serieCarouselList = new List<CarouselModel>();

            // Geerate CarouselList
            for(int i = 0; i < lastLives.Count; i++)
            {
                CarouselModel temp = new CarouselModel();
                if(i == 1 && i == 2 && i == 3 && i == 4 && i == 5 )
                {
                    temp.CarouselItemTitle = lastLives[i].name;
                    temp.CarouselItemImageName = lastLives[i].stream_icon;
                    temp.CarouselItemImageWidth = 274;
                    temp.CarouselItemImageHeight = 162;
                    temp.CarouselItemInnerImageWidth = 270;
                    temp.CarouselItemInnerImageHeight = 160;
                    temp.CarouselItemImageTop = 0;
                    temp.CarouselItemTitleVisible = false;
                    temp.CarouselItemAlphaVisible = false;
                    temp.CarouselItemBorderColor = "Transparent";
                    temp.CarouselItemCategoryType = XCCategoryType.Live;
                    temp.CarouselItemCategoryId = lastLives[i].category_id;
                    temp.CarouselItemParentId = null;
                } else
                {
                    temp.CarouselItemTitle = lastLives[i].name;
                    temp.CarouselItemImageName = lastLives[i].stream_icon;
                    temp.CarouselItemImageWidth = 274;
                    temp.CarouselItemImageHeight = 162;
                    temp.CarouselItemInnerImageWidth = 270;
                    temp.CarouselItemInnerImageHeight = 160;
                    temp.CarouselItemImageTop = 0;
                    temp.CarouselItemTitleVisible = false;
                    temp.CarouselItemAlphaVisible = true;
                    temp.CarouselItemBorderColor = "Transparent";
                    temp.CarouselItemCategoryType = XCCategoryType.Live;
                    temp.CarouselItemCategoryId = lastLives[i].category_id;
                    temp.CarouselItemParentId = null;
                }

                liveCarouselList.Add(temp);
            }

            for (int i = 0; i < lastVods.Count; i++)
            {
                CarouselModel temp = new CarouselModel();
                if (i == 1)
                {

                    temp.CarouselItemTitle = lastVods[i].name;
                    temp.CarouselItemImageName = lastVods[i].stream_icon;
                    temp.CarouselItemImageWidth = 670;
                    temp.CarouselItemImageHeight = 349;
                    temp.CarouselItemInnerImageWidth = 667;
                    temp.CarouselItemInnerImageHeight = 347;
                    temp.CarouselItemImageTop = 0;
                    temp.CarouselItemTitleVisible = false;
                    temp.CarouselItemAlphaVisible = false;
                    temp.CarouselItemBorderColor = "Transparent";
                    temp.CarouselItemCategoryType = XCCategoryType.Live;
                    temp.CarouselItemCategoryId = lastVods[i].category_id;
                    temp.CarouselItemParentId = null;
                }
                else
                {
                    temp.CarouselItemTitle = lastVods[i].name;
                    temp.CarouselItemImageName = lastVods[i].stream_icon;
                    temp.CarouselItemImageWidth = 274;
                    temp.CarouselItemImageHeight = 162;
                    temp.CarouselItemInnerImageWidth = 270;
                    temp.CarouselItemInnerImageHeight = 160;
                    temp.CarouselItemImageTop = 0;
                    temp.CarouselItemTitleVisible = false;
                    temp.CarouselItemAlphaVisible = true;
                    temp.CarouselItemBorderColor = "Transparent";
                    temp.CarouselItemCategoryType = XCCategoryType.Live;
                    temp.CarouselItemCategoryId = lastVods[i].category_id;
                    temp.CarouselItemParentId = null;
                }

                vodCarouselList.Add(temp);
            }

            for (int i = 0; i < lastSeries.Count; i++)
            {
                CarouselModel temp = new CarouselModel();
                if (i == 1)
                {

                    temp.CarouselItemTitle = lastSeries[i].name;
                    //temp.CarouselItemImageName = lastSeries[i].stream_icon;
                    //temp.CarouselItemImageWidth = 670;
                    //temp.CarouselItemImageHeight = 349;
                    //temp.CarouselItemInnerImageWidth = 667;
                    //temp.CarouselItemInnerImageHeight = 347;
                    //temp.CarouselItemImageTop = 0;
                    //temp.CarouselItemTitleVisible = false;
                    //temp.CarouselItemAlphaVisible = false;
                    //temp.CarouselItemBorderColor = "Transparent";
                    //temp.CarouselItemCategoryType = XCCategoryType.Live;
                    //temp.CarouselItemCategoryId = lastSeries[i].category_id;
                    //temp.CarouselItemParentId = null;
                }
                else
                {
                    temp.CarouselItemTitle = lastVods[i].name;
                    //temp.CarouselItemImageName = lastVods[i].stream_icon;
                    //temp.CarouselItemImageWidth = 274;
                    //temp.CarouselItemImageHeight = 162;
                    //temp.CarouselItemInnerImageWidth = 270;
                    //temp.CarouselItemInnerImageHeight = 160;
                    //temp.CarouselItemImageTop = 0;
                    //temp.CarouselItemTitleVisible = false;
                    //temp.CarouselItemAlphaVisible = true;
                    //temp.CarouselItemBorderColor = "Transparent";
                    //temp.CarouselItemCategoryType = XCCategoryType.Live;
                    //temp.CarouselItemCategoryId = lastVods[i].category_id;
                    //temp.CarouselItemParentId = null;
                }

                serieCarouselList.Add(temp);
            }


        }

        private void ReportProgress(object sender, int e)
        {
            LoadAccountProgressBarValue = e;
        }
    }
}
