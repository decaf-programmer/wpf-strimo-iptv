using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WindowsVideoDesktopApplicationServiceLibrary;

namespace WindowsVideoDesktopApplicationUI.ViewModels.Login
{
    public class LoginFormViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public string Username { get; set; } = "Username";
        public string Password { get; set; } = "Password";

        
        public LoginFormViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            //dialogService = new DialogService();
        }

        public void Login()
        {
            if(Username.Equals("Username") || Password.Equals("Password"))
            {

                return;
            }

            var authenticatedResult = XtreamCodeService.Authenticate(Username, Password);
            if (authenticatedResult.Equals("Error"))
            {

            } else if (authenticatedResult.Equals("Bad"))
            {

            } else
            {

            }
            
        }

        public void ShowAlertDialog(string title, string message) {
            
        }


    }
}
