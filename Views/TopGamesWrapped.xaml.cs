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

    public partial class TopGamesWrapped : Page
    {
        public delegate void OnAnGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnAnGameClicked AnAppClicked;

        public delegate void OnBackButtonClicked(object sender, RoutedEventArgs e);
        public event OnBackButtonClicked BackButtonClicked;

        public TopGamesWrapped()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                AnGame currAnApp = new AnGame();
                currAnApp.GameClicked += CurrAnApp_AppClicked;
                TopGamesWrappedPageMainWrapPanel.Children.Add(currAnApp);
            }
        }
        private void CurrAnApp_AppClicked(AnGame sender, RoutedEventArgs e)
        {
            AnAppClicked(sender, e);
        }
        private void TopGamesWrappedPageMainSV_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalChange > 0)
            {
                int adjustment = 400;
                if (e.VerticalOffset + e.ViewportHeight + adjustment >= e.ExtentHeight)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        AnGame newGame = new AnGame();
                        newGame.GameClicked += CurrAnApp_AppClicked;
                        TopGamesWrappedPageMainWrapPanel.Children.Add(newGame);
                    }
                }
            }
        }
        private void Back_Btn(object sender, RoutedEventArgs e)
        {
            BackButtonClicked(sender, e);
        }
    }
}
