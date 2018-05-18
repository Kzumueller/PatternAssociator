using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace PatternAssociator.Transformer
{
    static class PatternTransformer
    {
        // extension to transform the "checked" states of a collection of toggle buttons into a binary vector
        public static List<int> ToBinaryVector(this UIElementCollection collection)
        {
            var vector = new List<int>();

            foreach (ToggleButton child in collection)
            {
                vector.Add((bool)child.IsChecked ? 1 : 0);
            }

            return vector;
        }
    }
}
