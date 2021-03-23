using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Login
{
    public class LoginConductorViewModel:Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginPageViewModel loginPageViewModel;

        public LoginConductorViewModel(IEventAggregator _eventAggregator, LoginPageViewModel _loginPageViewModel)
        {
            eventAggregator = _eventAggregator;
            loginPageViewModel = _loginPageViewModel;

            Items.AddRange(new Screen[] { loginPageViewModel });
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
