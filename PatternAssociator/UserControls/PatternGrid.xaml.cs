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

namespace PatternAssociator.UserControls
{
    /// <summary>
    /// Interaction logic for PatternGrid.xaml
    /// </summary>
    public partial class PatternGrid : UserControl
    {
        public PatternGrid()
        {
            InitializeComponent();
            InitializeGrid();
        }

        //initializes every cell of Pattern (UniformGrid) with a new ToggleButton
        public void InitializeGrid()
        {
            Enumerable
                .Range(0, Pattern.Rows * Pattern.Columns)
                .ToList()
                .ForEach(index => Pattern.Children.Add(new ToggleButton() { Content = "♥" }));
        }
    }
}
