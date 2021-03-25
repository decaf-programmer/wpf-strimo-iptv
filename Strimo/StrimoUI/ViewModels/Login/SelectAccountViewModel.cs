using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Login
{
    public class SelectAccountViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;

        public SelectAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }



    }
}
