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

namespace GameHaven.UserControls.GameDetailsTabContent
{

    public partial class Overview : UserControl
    {
        public delegate void OnGameDetailsGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnGameDetailsGameClicked GameClicked;
        public Overview()
        {
            InitializeComponent();
            GamesViewerInsideOwerviewTab.GameClicked += GamesViewerInsideOwerviewTab_AnGameClicked;
        }

        private void GamesViewerInsideOwerviewTab_AnGameClicked(AnGame sender, RoutedEventArgs e)
        {
            GameClicked(sender, e);
        }
    }
}
