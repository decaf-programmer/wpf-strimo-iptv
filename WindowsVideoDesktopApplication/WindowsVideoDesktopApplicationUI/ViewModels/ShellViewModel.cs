using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsVideoDesktopApplicationUI.ViewModels.Login;

namespace WindowsVideoDesktopApplicationUI.ViewModels
{
    public class ShellViewModel:Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly LoginConductorViewModel _loginConductorViewModel;
        
        public ShellViewModel(IEventAggregator eventAggregator, LoginConductorViewModel loginConductorViewModel)
        {
            _eventAggregator = eventAggregator;
            _loginConductorViewModel = loginConductorViewModel;
            Items.AddRange(new Screen[] { _loginConductorViewModel });
        }

        public void Handle() { }

        protected override void OnActivate()
        {
            base.OnActivate();
            _eventAggregator.Subscribe(this);

            ActivateItem(_loginConductorViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }
    }
}
