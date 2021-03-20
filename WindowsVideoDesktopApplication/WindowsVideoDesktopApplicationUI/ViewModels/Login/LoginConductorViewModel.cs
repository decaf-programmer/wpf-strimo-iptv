using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsVideoDesktopApplicationUI.ViewModels.Login
{
    public class LoginConductorViewModel:Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator _eventAggregator;

        private readonly LoginFormViewModel _loginFormViewModel;
        
        public LoginConductorViewModel(IEventAggregator eventAggregator, LoginFormViewModel loginFormViewModel)
        {
            _eventAggregator = eventAggregator;
            _loginFormViewModel = loginFormViewModel;
            Items.AddRange(new Screen[] { _loginFormViewModel });
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            _eventAggregator.Subscribe(this);
            ActivateItem(_loginFormViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }
}
