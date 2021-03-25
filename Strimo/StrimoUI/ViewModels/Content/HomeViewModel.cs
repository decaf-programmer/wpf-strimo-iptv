using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Content
{
    public class HomeViewModel : Screen
    {
        private readonly IEventAggregator eventAggregator;
        public HomeViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }


    }
}
