using System.Threading.Tasks;
using SortingVisualizer.Visiualization;

namespace SortingVisualizer.Core
{
    public class BubbleSort : ISortAlgorithm
    {
        public async Task SortAsync(int[] array, IVisualizer visualizer, int delayMs)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }

                    // Обновляем визуализацию
                    await visualizer.UpdateAsync(array, new[] { j, j + 1 });
                    await Task.Delay(delayMs);
                }
            }
        }
    }
}
