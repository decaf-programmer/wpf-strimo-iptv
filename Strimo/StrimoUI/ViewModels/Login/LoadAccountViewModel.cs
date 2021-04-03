using Caliburn.Micro;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Globals;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI.ViewModels.Login
{
    public class LoadAccountViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;
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

        public string username = null;
        public string password = null;

        public LoadAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;

            
            
        }

        protected override async void OnActivate()
        {
            base.OnActivate();

            if (GlobalVars.currentUserModel != null)
            {
                username = GlobalVars.currentUserModel.username;
                password = GlobalVars.currentUserModel.password;
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

            List<List<CategoryModel>> allCategories = await XtreamCodeService.DownloadAllCategories(username, password, categoryActions, progress);

            
        }

        private void ReportProgress(object sender, int e)
        {
            LoadAccountProgressBarValue = e;
        }
    }
}
