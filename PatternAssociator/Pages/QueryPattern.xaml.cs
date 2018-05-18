using AutoAssociatorSimple;
using PatternAssociator.Transformer;
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

namespace PatternAssociator.Pages
{
    /// <summary>
    /// Interaction logic for QueryPattern.xaml
    /// </summary>
    public partial class QueryPattern : Page
    {
        public AutoAssociator Associator { get; set; }

        public QueryPattern()
        {
            InitializeComponent();

            QueryButton.Click += QueryButton_Click;
            ToTrainingButton.Click += ToTrainingButton_Click;
        }

        public QueryPattern(AutoAssociator associator) : this()
        {
            Associator = associator;
        }

        // transforms the current pattern into a binary vector, 
        // lets Associator reproduce a pattern and navigates to a result page where the memorized pattern is visualized
        private void QueryButton_Click(object sender, RoutedEventArgs e)
        {
            var result = Associator.Reproduce(PatternGrid.Pattern.Children.ToBinaryVector());

            var resultPage = new ReproducePattern(result);
            resultPage.KeepAlive = false;

            NavigationService.GetNavigationService(this).Navigate(resultPage);
        }

        //navigates back to the training page
        private void ToTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);

            if (service.CanGoBack)
            {
                service.GoBack();
            }
        }
    }
}
