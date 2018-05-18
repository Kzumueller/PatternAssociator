using AutoAssociatorSimple;
using PatternAssociator.Transformer;
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

namespace PatternAssociator.Pages
{
    /// <summary>
    /// Interaction logic for CreatePattern.xaml
    /// </summary>
    public partial class CreatePattern : Page
    {
        public AutoAssociator Associator { get; set; }

        public CreatePattern()
        {
            InitializeComponent();
            Associator = new AutoAssociator(PatternGrid.Pattern.Children.Count);

            // As this holds the original AutoAssociator, it should be kept alive so more training can be done
            KeepAlive = true;

            TrainButton.Click += TrainButton_Click;
            ToQueryButton.Click += ToQueryButton_Click;
        }

        //Converts the current pattern into a binary vector (checked <=> unchecked) and trains AutoAssociator
        private void TrainButton_Click(object sender, RoutedEventArgs e)
        {
            Associator.Train(new List<List<int>> { PatternGrid.Pattern.Children.ToBinaryVector() });

            MessageBox.Show("Training complete!");
        }


        private void ToQueryButton_Click(object sender, RoutedEventArgs e)
        {
            var nextPage = new QueryPattern(Associator);

            NavigationService.GetNavigationService(this).Navigate(nextPage);
        }
    }
}
