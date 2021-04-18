
using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Dialogs.AlertDialog;
using StrimoUI.Components.Dialogs.References;
using StrimoUI.Globals;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;

namespace StrimoUI.Pages.ViewModels.Login
{
    public class SelectAccountViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;
        private IDialogService dialogService;

        private ObservableCollection<SQLUserModel> _Users;
        public ObservableCollection<SQLUserModel> Users {
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

        public string username { get; set; }
        public string password { get; set; }

        public SelectAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;

            dialogService = new DialogService();

            Users = new ObservableCollection<SQLUserModel>(SQLDatabaseService.GetLastUsers());

        }

        public void SelectAccount(object sender)
        {
            Grid accountGrid = (Grid)sender;
            Grid infoGrid = (Grid)accountGrid.Children[1];
            TextBlock usernameTB = (TextBlock)infoGrid.Children[0];
            TextBlock passwordTB = (TextBlock)infoGrid.Children[1];

            string username = usernameTB.Text;
            string password = passwordTB.Text;

            string authResult = XtreamCodeService.Auth(username, password);
            if (authResult.Equals("Error"))
            {
                openAlertDialog("WARNING", "APP OR SERVICE IS NOT WORKING WITH PROVIDER SERVICE, PLEASE CONTACT WITH PROVIDER");
            }
            else if (authResult.Equals("Bad_Streaming_URL"))
            {
                openAlertDialog("WARNING", "STREAMING URL OR YOUR IP IS NOT ALLOWED TO GET STREAMING, PLEASE USE VPN");
            }
            else
            {
                var authInfo = new JavaScriptSerializer().Deserialize<XCAuthInfoModel>(authResult);
                if (authInfo.user_info.auth == 0)
                {
                    openAlertDialog("WARNING", "INCORRECT USERNAME AND PASSWORD. PLEASE INPUT CORRECT ONE");
                }
                else if ((int)long.Parse(authInfo.user_info.active_cons) + 1 > (int)long.Parse(authInfo.user_info.max_connections))
                {
                    openAlertDialog("WARNING", "YOU HAVE LIMITED CONNECTIONS, PLEASE EXTEND CONNECTION BY UPGRADING MEMBERSHIP");
                }
                else if ((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) > (int)Int64.Parse(authInfo.user_info.exp_date) || (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) < (int)Int64.Parse(authInfo.user_info.created_at))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS EXPIRED ALREADY, PLEASE CONTACT TO PROVIDER");
                }
                else if (authInfo.user_info.status.Equals("Active"))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT ACTIVATED. PLEASE MAKE YOUR ACCOUNT ACTIVATE");
                }
                else if (authInfo.user_info.is_trial.Equals("0"))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT TRIAL NOW. PLEASE PURCHASE APP NOW");
                }
                else
                {
                    GlobalVars.currentAuthInfo = authInfo;

                    DateTime currentDate = DateTime.Now;
                    string currentDateStr = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                    SQLDatabaseService.UpdateUser(authInfo.user_info.username, authInfo.user_info.password, 1, currentDateStr);

                    eventAggregator.PublishOnUIThread(new AuthSuccessMessage());
                }
            }
        }

        private void openAlertDialog(string dialogTitle, string dialogMessage)
        {
            var warningDialog = new AlertDialogViewModel(dialogTitle, dialogMessage);
            dialogService.OpenDialog(warningDialog);
        }
    }
}
