using Caliburn.Micro;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoUI.Messages;
using StrimoUI.Pages.ViewModels.Content;
using StrimoUI.Pages.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI
{
    public class ShellViewModel:Conductor<Screen>.Collection.OneActive, IHandle<LoadedAccountMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginConductorViewModel loginConductorViewModel;
        private readonly ContentConductorViewModel contentConductorViewModel;

        public ShellViewModel(IEventAggregator _eventAggregaotr, LoginConductorViewModel _loginConductorViewModel, ContentConductorViewModel _contentConductorViewModel)
        {
            eventAggregator = _eventAggregaotr;
            loginConductorViewModel = _loginConductorViewModel;
            contentConductorViewModel = _contentConductorViewModel;
            
            Items.AddRange(new Screen[] { loginConductorViewModel, contentConductorViewModel });
        }

        public void Handle(LoadedAccountMessage message)
        {
            ActivateItem(contentConductorViewModel);
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            eventAggregator.Subscribe(this);
            ActivateItem(loginConductorViewModel);

        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            eventAggregator.Unsubscribe(this);
        }
    }
}
