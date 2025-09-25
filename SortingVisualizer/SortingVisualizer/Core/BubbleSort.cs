using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    public class BubbleSort : ISortAlgorithm
    {
        public int[] Array { get; set; }

        public BubbleSort(int[] array)
        {
            Array = array;
        }

        // Bubble sort with async visualization
        public async Task SortAsync(IVisualizer visualizer)
        {
            int n = Array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        // Swap elements
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;

                        // Update visualization after each swap
                        await visualizer.UpdateAsync(Array);
                    }
                }
            }
        }
    }
}
