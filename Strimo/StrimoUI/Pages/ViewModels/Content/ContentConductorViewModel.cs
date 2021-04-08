using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Pages.ViewModels.Content
{
    public class ContentConductorViewModel:Conductor<Screen>.Collection.OneActive
    {
        private readonly IEventAggregator eventAggregator;
        private readonly HomeViewModel homeViewModel;

        
        public ContentConductorViewModel(IEventAggregator _eventAggregator, HomeViewModel _homeViewModel)
        {
            eventAggregator = _eventAggregator;
            homeViewModel = _homeViewModel;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

            ActivateItem(homeViewModel);
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }
    }
}
