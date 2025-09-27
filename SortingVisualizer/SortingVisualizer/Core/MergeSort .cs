using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    public class MergeSort : ISortAlgorithm
    {
        // Algorithm name
        public string Name { get;}

        public MergeSort(int[] array)
        {
            Name = "MergeSort";
        }

        // Public entry point
        public async Task SortAsync(int[] array, IVisualizer visualizer, int delayMs)
        {
            await MergeSortRecursive(array, 0, array.Length - 1, visualizer, delayMs);
        }

        // Recursive merge sort
        private async Task MergeSortRecursive(int[] array, int left, int right, IVisualizer visualizer, int delayMs)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // Sort first half
                await MergeSortRecursive(array, left, middle, visualizer, delayMs);

                // Sort second half
                await MergeSortRecursive(array, middle + 1, right, visualizer, delayMs);

                // Merge both halves
                await Merge(array, left, middle, right, visualizer, delayMs);
            }
        }

        // Merge two sorted halves
        private async Task Merge(int[] array, int left, int middle, int right, IVisualizer visualizer, int delayMs)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copy data to temp arrays
            for (int i = 0; i < n1; i++) L[i] = array[left + i];
            for (int j = 0; j < n2; j++) R[j] = array[middle + 1 + j];

            int iIndex = 0, jIndex = 0;
            int k = left;

            // Merge back into array
            while (iIndex < n1 && jIndex < n2)
            {
                if (L[iIndex] <= R[jIndex])
                {
                    array[k] = L[iIndex];
                    iIndex++;
                }
                else
                {
                    array[k] = R[jIndex];
                    jIndex++;
                }

                k++;
                await visualizer.UpdateAsync(array);
                await Task.Delay(delayMs);
            }

            // Copy remaining elements of L[]
            while (iIndex < n1)
            {
                array[k] = L[iIndex];
                iIndex++;
                k++;

                await visualizer.UpdateAsync(array);
                await Task.Delay(delayMs);
            }

            // Copy remaining elements of R[]
            while (jIndex < n2)
            {
                array[k] = R[jIndex];
                jIndex++;
                k++;

                await visualizer.UpdateAsync(array);
                await Task.Delay(delayMs);
            }
        }
    }
}
