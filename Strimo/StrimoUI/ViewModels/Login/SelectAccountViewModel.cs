
using Caliburn.Micro;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StrimoUI.ViewModels.Login
{
    public class SelectAccountViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;

        private ObservableCollection<UserDBModel> _Users;
        public ObservableCollection<UserDBModel> Users {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
                NotifyOfPropertyChange(() => Users);
            }
        }

        public SelectAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            
            Users = new ObservableCollection<UserDBModel>(DatabaseService.GetLastUsers());

        }

        public void SelectAccount() {
            
        }
    }
}
