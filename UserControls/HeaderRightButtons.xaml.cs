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
using GameHaven.Models;
using GameHaven.Views;

namespace GameHaven.UserControls
{

    public partial class HeaderRightButtons : UserControl
    {
        public delegate void OnDownloadButtonClick(object sender, RoutedEventArgs e);
        public event OnDownloadButtonClick HeaderRightButtonsDownloadButtonClick;

        public HeaderRightButtons()
        {
            InitializeComponent();
        }

        public void MouseDown_OutsideOfHeaderRightButtons()
        {
            if (!SeachTextBox.IsMouseOver)
            {
                SeachTextBox.Visibility = Visibility.Collapsed;
               
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClick(sender, e);
        }
        private void DownloadsAndUpdatesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            HeaderRightButtonsDownloadButtonClick(sender, e);
            HeaderRightButtonsDownloadButtonClick(sender, e);
        }

        public delegate void OnLogInClickHandler(object sender, RoutedEventArgs e);
        public event OnLogInClickHandler LogInClickEvent;

        public delegate void OnRegisterClickHandler(object sender, RoutedEventArgs e);
        public event OnRegisterClickHandler RegisterClickEvent;

        public delegate void OnProfileClickHandler(object sender, RoutedEventArgs e);
        public event OnProfileClickHandler ProfileClickEvent;

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInClickEvent?.Invoke(sender, e);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterClickEvent?.Invoke(sender, e);
        }
        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            ProfileClickEvent?.Invoke(sender, e);
        }


        private void GameListPageButton_Click(object sender, RoutedEventArgs e)
        {
     
              var navigationService = GetParentNavigationService(this);

            if (navigationService != null)
            {
              
                var context = new GameHavenContext();
              
                navigationService.Navigate(new GameListPage(context));
            }
        }
        private NavigationService GetParentNavigationService(DependencyObject child)
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            Page parentPage = parentObject as Page;
            if (parentPage != null)
            {
                return parentPage.NavigationService;
            }

            return GetParentNavigationService(parentObject);
        }


    }
}
