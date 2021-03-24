using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Dialogs.AlertDialog;
using StrimoUI.Dialogs.References;
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
        private IDialogService dialogService;

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
            dialogService = new DialogService();
        }

        public void Login()
        {
            string loginResponse = XtreamCodeService.Auth(Username, Password);
            if (Username.Equals("Username") || Password.Equals("Password"))
            {
                openAlertDialog("WARNING", "YOU SHOULD INPUT USERNAME OR PASSWORD");
            }
            else
            {
                string authResult = XtreamCodeService.Auth(Username, Password);
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

                        //GlobalVars.currentUserModel = authUserModel;
                        //_eventAggregator.PublishOnUIThread(new AuthSuccessMessage());
                    }
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
