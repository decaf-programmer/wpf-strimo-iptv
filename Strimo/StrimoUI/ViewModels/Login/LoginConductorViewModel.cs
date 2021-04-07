using Caliburn.Micro;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrimoUI.ViewModels.Login
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

        protected override void OnActivate()
        {
            base.OnActivate();
            eventAggregator.Subscribe(this);

            List<UserDBModel> users = DatabaseService.GetLastUsers();
            if (users != null)
            {
                ActivateItem(selectAccountVM);
            } else
            {
                ActivateItem(loginPageVM);
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

        public UserModel getLastUsers()
        {

            return null;
        }
    }
}
