using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using SQLite;
using StrimoDBLibrary.Services;
using StrimoLibrary.Models;
using StrimoLibrary.Services;
using StrimoUI.Components.Dialogs.AlertDialog;
using StrimoUI.Components.Dialogs.References;
using StrimoUI.Globals;
using StrimoUI.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace StrimoUI.Pages.ViewModels.Login
{
    public class LoginPageViewModel:Screen
    {
        private readonly IEventAggregator eventAggregator;
        private IDialogService dialogService;

        public string Username { get; set; } = "Username";
        public string Password { get; set; } = "Password";

        
        public LoginPageViewModel(IEventAggregator _eventAggregator)
        {
            eventAggregator = _eventAggregator;
            dialogService = new DialogService();
        }

        public void Login()
        {
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
                    else if (!authInfo.user_info.status.Equals("Active"))
                    {
                        openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT ACTIVATED. PLEASE MAKE YOUR ACCOUNT ACTIVATE");
                    }
                    else if (!authInfo.user_info.is_trial.Equals("0"))
                    {
                        openAlertDialog("WARNING", "YOUR ACCOUNT IS NOT TRIAL NOW. PLEASE PURCHASE APP NOW");
                    }
                    else
                    {
                        GlobalVars.currentAuthInfo = authInfo;

                        DateTime currentDate = DateTime.Now;
                        string currentDateStr = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                        SQLDatabaseService.CreateDBFile();
                        SQLDatabaseService.CreateUserTable();
                        SQLDatabaseService.UpdateUser(authInfo.user_info.username, authInfo.user_info.password, 1, currentDateStr);

                        eventAggregator.PublishOnUIThread(new AuthSuccessMessage());
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
