using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Login
{
    public class LoginPageViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;

        private string username = "Username";
        private string password = "Password";

        public string Username
        {
            get { return username; }
            set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                NotifyOfPropertyChange(() => Username);

            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public LoginPageViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
        }

        public void Login()
        {
            
        }

    }
}
