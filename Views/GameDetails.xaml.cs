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
using GameHaven.UserControls;

namespace GameHaven.Views
{

    public partial class GameDetails : Page
    {
        public delegate void OnGameDeatilsAnotherGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnGameDeatilsAnotherGameClicked GameClicked;

        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;

        public GameDetails(AnGame inGame)
        {
            InitializeComponent();
            GameDetailsTitleAndBackgroundUC.AppNameLabel.Content = inGame.FreeGameName;
            GameDetailsTitleAndBackgroundUC.GameImage.Source = inGame.GameImageSource;
            GameDetailsTitleAndBackgroundUC.BackButtonClicked += GameDetailsTitleAndBackgroundUC_BackButtonClicked;

            OverviewTabUC.GameClicked += OverviewTabUC_GameClicked;
        }
        private void OverviewTabUC_GameClicked(AnGame sender, RoutedEventArgs e)
        {
            GameClicked(sender, e);
        }
        private void GameDetailsTitleAndBackgroundUC_BackButtonClicked(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);
        }
    }
}
