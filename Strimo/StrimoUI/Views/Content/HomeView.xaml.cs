using StrimoUI.ViewModels.Content;
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

namespace StrimoUI.Views.Content
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            var homeMenuRegister = new List<SubItem>();
            homeMenuRegister.Add(new SubItem("Customer"));
            homeMenuRegister.Add(new SubItem("Providers"));

            var item0 = new ItemMenu("Register", homeMenuRegister, "home.png");

            var livetvMenuRegister = new List<SubItem>();
            livetvMenuRegister.Add(new SubItem("Customer"));
            livetvMenuRegister.Add(new SubItem("Providers"));

            var item1 = new ItemMenu("Register", livetvMenuRegister, "home.png");

            var movieMenuRegister = new List<SubItem>();
            movieMenuRegister.Add(new SubItem("Customer"));
            movieMenuRegister.Add(new SubItem("Providers"));

            var item2 = new ItemMenu("Register", movieMenuRegister, "home.png");

            var favoriteMenuRegister = new List<SubItem>();
            favoriteMenuRegister.Add(new SubItem("Customer"));
            favoriteMenuRegister.Add(new SubItem("Providers"));

            var item3 = new ItemMenu("Register", favoriteMenuRegister, "home.png");

            var recordMenuRegister = new List<SubItem>();
            recordMenuRegister.Add(new SubItem("Customer"));
            recordMenuRegister.Add(new SubItem("Providers"));

            var item4 = new ItemMenu("Register", recordMenuRegister, "home.png");

            var item5 = new ItemMenu("Dashboard", new UserControl(), "dashboard.png");

            NavigationMenu.Children.Add(new NavigationItemView(item0));
            NavigationMenu.Children.Add(new NavigationItemView(item1));
            NavigationMenu.Children.Add(new NavigationItemView(item2));
            NavigationMenu.Children.Add(new NavigationItemView(item3));
            NavigationMenu.Children.Add(new NavigationItemView(item4));
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)sender;
            string nameListItem = (string)listViewItem.GetType().GetProperty("Name").GetValue(listViewItem, null);
            switch (nameListItem)
            {
                case "HomeListViewItem":
                    break;
                case "LiveListViewItem":
                    break;
                case "MovieListViewItem":
                    break;
                case "SerieListViewItem":
                    break;
                case "RadioListViewItem":
                    break;
                case "RecordingListViewItem":
                    break;
                case "FavoriteListViewItem":
                    break;
            }
        }

        private void ListViewItem_MouseLeave(object sender, MouseEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)sender;
            string nameListViewItem = (string)listViewItem.GetType().GetProperty("Name").GetValue(listViewItem, null);

            switch (nameListViewItem)
            {
                case "HomeListViewItem":
                    break;
                case "LiveListViewItem":
                    break;
                case "MovieListViewItem":
                    break;
                case "SerieListViewItem":
                    break;
                case "RadioListViewItem":
                    break;
                case "RecordingListViewItem":
                    break;
                case "FavoriteListViewItem":
                    break;
            }
        }
    }
}
