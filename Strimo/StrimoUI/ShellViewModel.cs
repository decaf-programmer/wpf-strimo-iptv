using Caliburn.Micro;
using StrimoUI.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI
{
    public class ShellViewModel:Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginConductorViewModel loginConductorViewModel;

        public ShellViewModel(IEventAggregator _eventAggregaotr, LoginConductorViewModel _loginConductorViewModel)
        {
            eventAggregator = _eventAggregaotr;
            loginConductorViewModel = _loginConductorViewModel;
            
            Items.AddRange(new Screen[] { loginConductorViewModel });
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
