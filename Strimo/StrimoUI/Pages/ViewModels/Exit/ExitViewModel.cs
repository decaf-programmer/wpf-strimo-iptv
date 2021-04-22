using Caliburn.Micro;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoUI.Globals;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI.Pages.ViewModels.Exit
{
    public class ExitViewModel: Screen
    {
        private readonly IEventAggregator eventAggregator;

        public ExitViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            eventAggregator.Unsubscribe(this);
        }

        public void Logout()
        {
            if(GlobalVars.currentAuthInfo != null)
            {
                string currentUsername = GlobalVars.currentAuthInfo.user_info.username;
                string currentPassword = GlobalVars.currentAuthInfo.user_info.password;

                DateTime currentDate = DateTime.Now;
                string currentDateStr = currentDate.ToString("yyyy-MM-dd HH:mm:ss");
                SQLDatabaseService.UpdateUser(currentUsername, currentPassword, 0, currentDateStr);
            }
            eventAggregator.PublishOnUIThread(new LogoutMessage());
        }

        public void Exit()
        {
            eventAggregator.PublishOnUIThread(new ExitMessage());
        }
    }
}
