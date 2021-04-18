using Caliburn.Micro;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.Pages.ViewModels.Login
{
    public class LoginConductorViewModel:Conductor<Screen>.Collection.OneActive, IHandle<AuthSuccessMessage>
    {
        private readonly IEventAggregator eventAggregator;
        private readonly LoginPageViewModel loginPageVM;
        private readonly LoadAccountViewModel loadAccountVM;
        private readonly SelectAccountViewModel selectAccountVM;

        public LoginConductorViewModel(IEventAggregator _eventAggregator, LoginPageViewModel _loginPageVM, LoadAccountViewModel _loadAccountVM, SelectAccountViewModel _selectAccountVM)
        {
            eventAggregator = _eventAggregator;
            loginPageVM = _loginPageVM;
            loadAccountVM = _loadAccountVM;
            selectAccountVM = _selectAccountVM;
            Items.AddRange(new Screen[] { loginPageVM, loadAccountVM, selectAccountVM });
        }


        // Go to Login Page or Select Account Page...
        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

            if (!File.Exists("StrimoDB.db3"))
            {
                ActivateItem(loginPageVM);
            } else
            {
                List<SQLUserModel> users = SQLDatabaseService.GetLastUsers();
                if (users != null && users.Count != 0)
                {
                    ActivateItem(selectAccountVM);
                }
                else
                {
                    ActivateItem(loginPageVM);
                }
            }
        }

        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
        }

        public void Handle(AuthSuccessMessage message)
        {
            ActivateItem(loadAccountVM);
        }

    }
}
