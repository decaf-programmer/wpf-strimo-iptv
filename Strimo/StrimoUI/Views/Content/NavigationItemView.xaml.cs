using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for NavigationItemView.xaml
    /// </summary>
    public partial class NavigationItemView : UserControl
    {
        public NavigationItemView()
        {
            InitializeComponent();
        }

        public void SubMenuMouseEnter(Object sender, MouseEventArgs e)
        {
            Grid subMenu = (Grid)sender;
            Grid subMenuBar = (Grid)subMenu.Children[0];
            subMenuBar.Visibility = Visibility.Visible;
        }

        public void SubMenuMouseLeave(Object sender, MouseEventArgs e)
        {
            Grid subMenu = (Grid)sender;
            Grid subMenuBar = (Grid)subMenu.Children[0];
            subMenuBar.Visibility = Visibility.Hidden;
        }

        private void Expander_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
