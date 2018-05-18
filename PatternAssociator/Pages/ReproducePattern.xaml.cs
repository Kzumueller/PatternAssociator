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
    /// Interaction logic for ReproducePattern.xaml
    /// </summary>
    public partial class ReproducePattern : Page
    {
        public ReproducePattern()
        {
            InitializeComponent();
        }

        public ReproducePattern(List<int> vector): this()
        {
            Visualize(vector);
            ToQueryButton.Click += ToQueryButton_Click;
        }

        //tries to navigate back to the query page
        private void ToQueryButton_Click(object sender, RoutedEventArgs e)
        {
            var service = NavigationService.GetNavigationService(this);

            if(service.CanGoBack)
            {
                service.GoBack();
            } else
            {
                MessageBox.Show("Cannot go back, you're gonna be trapped here forever, Jim.");
            }
        }

        //checks the ToggleButtons in the PatternGrid according to the passed binary vector
        public void Visualize(List<int> vector)
        {
            var children = PatternGrid.Pattern.Children;

            for (int index = 0; index < vector.Count; ++index)
            {
                ((ToggleButton)children[index]).IsChecked = 1 == vector[index];
            }
        }
    }
}
