
using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using StrimoDBLibrary.Models;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Dialogs.AlertDialog;
using StrimoUI.Dialogs.References;
using StrimoUI.Globals;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StrimoUI.ViewModels.Login
{
    public class SelectAccountViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;
        private IDialogService dialogService;

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

        public string username { get; set; }
        public string password { get; set; }

        public SelectAccountViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;

            dialogService = new DialogService();

            Users = new ObservableCollection<UserDBModel>(DatabaseService.GetLastUsers());

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
                JObject authResponseJSON = JObject.Parse(authResult);
                JObject authUser = (JObject)authResponseJSON["user_info"];
                if ((int)authUser["auth"] == 0)
                {
                    openAlertDialog("WARNING", "INCORRECT USERNAME AND PASSWORD. PLEASE INPUT CORRECT ONE");
                }
                else if ((int)long.Parse((string)authUser["active_cons"]) + 1 > (int)long.Parse((string)authUser["max_connections"]))
                {
                    openAlertDialog("WARNING", "YOU HAVE LIMITED CONNECTIONS, PLEASE EXTEND CONNECTION BY UPGRADING MEMBERSHIP");
                }
                else if ((DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) > (int)Int64.Parse((string)authUser["exp_date"]) || (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() / 1000) < (int)Int64.Parse((string)authUser["created_at"]))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS EXPIRED ALREADY, PLEASE CONTACT TO PROVIDER");
                }
                else if (authUser["status"].Equals("Active"))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT ACTIVATED. PLEASE MAKE YOUR ACCOUNT ACTIVATE");
                }
                else if (authUser["is_trial"].Equals("0"))
                {
                    openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT TRIAL NOW. PLEASE PURCHASE APP NOW");
                }
                else
                {
                    UserModel authUserModel = new UserModel();
                    authUserModel.username = (string)authUser["username"];
                    authUserModel.password = (string)authUser["password"];
                    authUserModel.message = (string)authUser["message"];
                    authUserModel.auth = (int)authUser["auth"];
                    authUserModel.status = (string)authUser["status"];
                    authUserModel.exp_date = (string)authUser["exp_date"];
                    authUserModel.is_trial = (string)authUser["is_trial"];
                    authUserModel.active_cons = (string)authUser["active_cons"];
                    authUserModel.created_at = (string)authUser["created_at"];
                    authUserModel.max_connections = (string)authUser["max_connections"];
                    authUserModel.allowed_output_formats = new List<string>();
                    foreach (string format in authUser["allowed_output_formats"])
                    {
                        authUserModel.allowed_output_formats.Add(format);
                    }

                    GlobalVars.currentUser = authUserModel;

                    DateTime currentDate = DateTime.Now;
                    string currentDateStr = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                    DatabaseService.CreateDBFile();
                    DatabaseService.CreateUserTable();
                    DatabaseService.UpdateUser(authUserModel.username, authUserModel.password, 1, currentDateStr);

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
