using SortingVisualizer.Visualization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Core
{
    public class SelectionSort : ISortAlgorithm
    {
        public string Name { get;}

        public SelectionSort(int[] array)
        {
            Name = "SelectionSort";
        }

        public async Task SortAsync(int[] array, IVisualizer visualizer, Func<int> getDelay,CancellationToken token)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                // Find the minimum element in the remaining unsorted array
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;

                    // Visualize current comparison
                    await visualizer.UpdateAsync(array, new[] { i, j, minIndex });
                    await Task.Delay(getDelay(), token);
                }

                // Swap found minimum element with the first element
                if (minIndex != i)
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                }
            }
        }
    }
}
