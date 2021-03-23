using Caliburn.Micro;
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

        public ShellViewModel(IEventAggregator _eventAggregaotr)
        {
            eventAggregator = _eventAggregaotr;
            
            Items.AddRange(new Screen[] { });
        }

        protected override void OnActivate()
        {
            base.OnActivate();

            eventAggregator.Subscribe(this);
            //ActivateItem();
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            eventAggregator.Unsubscribe(this);
        }
    }
}
