using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    public class BubbleSort : ISortAlgorithm
    {
        // Algorithm name
        public string Name { get;}

        public BubbleSort(int[] array)
        {
            Name = "Bubble Sort";
        }


        // Sort method with visualization and delay
        public async Task SortAsync(int[] array, IVisualizer visualizer, int delayMs,CancellationToken token)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Compare adjacent elements
                    if (array[j] > array[j + 1])
                    {
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        // Visualize swap
                        await visualizer.UpdateAsync(array, new[] { j, j + 1 });
                    }
                    await Task.Delay(delayMs, token);
                }
            }

            // Final visualization after sorting
            await visualizer.UpdateAsync(array);
        }
    }
}
