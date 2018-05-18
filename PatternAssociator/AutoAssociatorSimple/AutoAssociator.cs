using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAssociatorSimple
{
    public class AutoAssociator
    {
        //represents an n x n matrix, holding the weights of our theoretical neurons' dendrites
        public List<List<int>> AssociativeMemory { get; set; }

        //uses length to initialize this.AssociativeMemory with a new List of Lists and every int inside with 0
        public AutoAssociator(int length)
        {
            AssociativeMemory = new List<List<int>>(length);

            for (int listIndex = 0; listIndex < length; ++listIndex)
            {
                AssociativeMemory.Add(new List<int>());

                for (int itemIndex = 0; itemIndex < length; ++itemIndex)
                {
                    AssociativeMemory[listIndex].Add(0);
                }
            }
        }

        // trains this.AssociativeMemory with a list of binary vectors
        public void Train(List<List<int>> vectors)
        {
            foreach (var vector in vectors)
            {
                //multiply vector with its transpose and binary-OR the result with each corresponding position in this.AssociativeMemory
                for (int row = 0; row < vector.Count; ++row)
                {
                    for (int column = 0; column < vector.Count; ++column)
                    {
                        AssociativeMemory[row][column] |= vector[row] * vector[column];
                    }
                }
            }
        }

        //finds the trained vector that most resembles the given vector
        public List<int> Reproduce(List<int> vector)
        {
            var result = new List<int>(vector.Count);
            var vectorSum = vector.Sum();

            for (int row = 0; row < vector.Count; ++row)
            {
                var rowSum = 0;

                for (int column = 0; column < vector.Count; ++column)
                {
                    rowSum += AssociativeMemory[row][column] * vector[column];
                }

                result.Add(rowSum);
            }

            //apply threshold function
            return result
                .Select(item => item - vectorSum < 0 ? 0 : 1)
                .ToList();
        }
    }
}
