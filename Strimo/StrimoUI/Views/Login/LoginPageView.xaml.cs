using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StrimoUI.Views.Login
{
    /// <summary>
    /// Interaction logic for LoginPageView.xaml
    /// </summary>
    public partial class LoginPageView : UserControl
    {
        public LoginPageView()
        {
            InitializeComponent();
        }

        public void UsernameGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_Username = (TextBox)sender;
            if (tb_Username.Text.Equals("Username"))
            {
                tb_Username.Text = "";
            }
        }

        public void UsernameLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_Username = (TextBox)sender;
            if (string.IsNullOrEmpty(tb_Username.Text))
            {
                tb_Username.Text = "Username";
            }
        }

        public void PasswordGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_Password = (TextBox)sender;
            if (tb_Password.Text.Equals("Password"))
            {
                tb_Password.Text = "";
            }
        }

        public void PasswordLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb_Password = (TextBox)sender;
            if (string.IsNullOrEmpty(tb_Password.Text))
            {
                tb_Password.Text = "Password";
            }
        }
    }
}
