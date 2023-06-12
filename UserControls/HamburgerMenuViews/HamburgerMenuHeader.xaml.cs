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

namespace GameHaven.UserControls.HamburgerMenuViews
{

    public partial class HamburgerMenuHeader : UserControl
    {
        public delegate void OnFilterMenuItemClicked(object sender, RoutedEventArgs e);
        public event OnFilterMenuItemClicked FilterMenuItemClicked;

        public delegate void OnSortByMenuItemClicked(object sender, RoutedEventArgs e);
        public event OnSortByMenuItemClicked SortByMenuItemClicked;

        public HamburgerMenuHeader()
        {
            InitializeComponent();
        }
        private void SortBy_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SortByLabel.Content = (sender as MenuItem).Header.ToString();
            FilterMenuItemClicked(sender, e);
        }
        private void Filter_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FilterByTypeLabel.Content = (sender as MenuItem).Header.ToString();
            SortByMenuItemClicked(sender, e);
        }
    }
}
