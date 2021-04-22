using Caliburn.Micro;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoUI.Messages;
using StrimoUI.Pages.ViewModels.Content;
using StrimoUI.Pages.ViewModels.Exit;
using StrimoUI.Pages.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Action = System.Action;

namespace StrimoUI
{
    public class ShellViewModel:Conductor<Screen>.Collection.OneActive, IHandle<LoadedAccountMessage>, IHandle<LogoutMessage>, IHandle<ExitMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginConductorViewModel loginConductorViewModel;
        private readonly ContentConductorViewModel contentConductorViewModel;
        private readonly ExitViewModel exitViewModel;

        public Window RootWindow;

        public ShellViewModel(IEventAggregator _eventAggregaotr, LoginConductorViewModel _loginConductorViewModel, ContentConductorViewModel _contentConductorViewModel, ExitViewModel _exitViewModel)
        {
            eventAggregator = _eventAggregaotr;
            loginConductorViewModel = _loginConductorViewModel;
            contentConductorViewModel = _contentConductorViewModel;
            exitViewModel = _exitViewModel;
            
            Items.AddRange(new Screen[] { loginConductorViewModel, contentConductorViewModel, exitViewModel });
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

        public override void CanClose(Action<bool> callback)
        {
            //if(some logic...)
            callback(false); // will cancel close
        }

        public void OnClose(CancelEventArgs e)
        {
            ActivateItem(exitViewModel);
        }

        public void Handle(LogoutMessage message)
        {
            ActivateItem(loginConductorViewModel);
        }

        public void Handle(ExitMessage message)
        {
            System.Environment.Exit(0);
        }

    }
}
