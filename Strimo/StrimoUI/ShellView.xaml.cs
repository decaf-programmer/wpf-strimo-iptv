using StrimoDBLibrary.Services;
using StrimoUI.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StrimoUI
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        public void MainWindow_Closing(object sender, CancelEventArgs e)
        {

            string msg = "Do you want to close the window?";
            MessageBoxResult result = MessageBox.Show(msg, "Close Window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            } else
            {
                if(GlobalVars.currentUser != null)
                {
                    string currentUsername = GlobalVars.currentUser.username;
                    string currentPassword = GlobalVars.currentUser.password;


                    DateTime currentDate = DateTime.Now;
                    string currentDateStr = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                    SQLDatabaseService.UpdateUser(currentUsername, currentPassword, 0, currentDateStr);
                } else
                {
                    return;
                }
            }
        }
    }
}
