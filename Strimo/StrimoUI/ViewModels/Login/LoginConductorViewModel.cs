using Caliburn.Micro;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Login
{
    public class LoginConductorViewModel:Conductor<Screen>.Collection.OneActive, IHandle<AuthSuccessMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginPageViewModel loginPageViewModel;
        private readonly LoadAccountViewModel loadAccountViewModel;

        public LoginConductorViewModel(IEventAggregator _eventAggregator, LoginPageViewModel _loginPageViewModel, LoadAccountViewModel _loadAccountViewModel)
        {
            eventAggregator = _eventAggregator;
            loginPageViewModel = _loginPageViewModel;
            loadAccountViewModel = _loadAccountViewModel;
            Items.AddRange(new Screen[] { loginPageViewModel, loadAccountViewModel });
        }

        public void Handle(AuthSuccessMessage message)
        {
            ActivateItem(loadAccountViewModel);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

            ActivateItem(loginPageViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }
}
