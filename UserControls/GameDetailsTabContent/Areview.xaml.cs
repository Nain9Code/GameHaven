using MiscUtil;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameHaven.UserControls.GameDetailsTabContent
{
 
    public partial class Areview : UserControl
    {
        List<string> Names;
        public Areview()
        {
            InitializeComponent();
            Names = new List<string>() { "Aitorsito", "NainThink", "Eugene", "Tony", "Sensei", "German" };
            string reviewerName = Names[StaticRandom.Next(Names.Count)];
            ReviewerNameLabel.Content = reviewerName;
            AvatarLabel.Content = reviewerName[0];
            NumOfStarsLabel.Content = GetRandomNumOfStars();
            ReviewTitle.Content = GetReviewTitleBasedOnStars(NumOfStarsLabel.Content.ToString());
        }
        private string GetRandomNumOfStars()
        {
            string content = "";
            for (int i = 0; i < StaticRandom.Next(1, 6); i++)
            {
                content += "★";
            }
            return content;
        }
        private string GetReviewTitleBasedOnStars(string inStars)
        {
            string retStr = "";
            if (inStars.Length >= 4)
            {
                retStr = "This game is awesome!";
            }
            else if (inStars.Length == 3)
            {
                retStr = "Not bad";
            }
            else
            {
                retStr = "I don't like it";
            }
            return retStr;
        }
    }
}
