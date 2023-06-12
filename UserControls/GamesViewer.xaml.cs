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

namespace GameHaven.UserControls
{
    public partial class GamesViewer : UserControl
    {
        List<AnGame> PresentedApps;

        public delegate void OnGameClicked(AnGame sender, RoutedEventArgs e);
        public event OnGameClicked GameClicked;

        public GamesViewer()
        {
            InitializeComponent();
            PresentedApps = new List<AnGame>();
            GamesList.ItemsSource = PresentedApps;
            for (int i = 0; i < 9; i++)
            {
                AnGame curr = new AnGame();
                curr.GameClicked += Curr_AppClicked;
                PresentedApps.Add(curr);
            }
        }

        private void Curr_AppClicked(AnGame sender, RoutedEventArgs e)
        {
            GameClicked?.Invoke(sender, e);
        }

        private void ScrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)PresentedApps.First().ActualWidth + 2*(int)PresentedApps.First().Margin.Left;
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset - 4 * widthOfOneApp);
        }
        private void ScrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            int widthOfOneApp = (int)PresentedApps.First().ActualWidth + 2*(int)PresentedApps.First().Margin.Left;
            AppsScrollView.ScrollToHorizontalOffset(AppsScrollView.HorizontalOffset + 4 * widthOfOneApp);
        }
        private void AppsScrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            eventArg.RoutedEvent = UIElement.MouseWheelEvent;
            eventArg.Source = sender;
            var parent = ((Control)sender).Parent as UIElement;
            parent.RaiseEvent(eventArg);
        }
    }
}
