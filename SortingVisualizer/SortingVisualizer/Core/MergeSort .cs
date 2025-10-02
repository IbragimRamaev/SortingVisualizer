using System;
using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    public class MergeSort : ISortAlgorithm
    {
        // Algorithm name
        public string Name { get;}
        private IVisualizer _visualizer;
        private int _delay;
        private CancellationToken _token;

        public MergeSort(int[] array)
        {
            Name = "MergeSort";
        }

        // Public entry point
        public async Task SortAsync(int[] array, IVisualizer visualizer, Func<int> getDelay, CancellationToken token)
        {
            _visualizer = visualizer;
            _delay = getDelay();
            _token = token;

            await MergeSortRecursive(array, 0, array.Length - 1);
        }

        // Recursive merge sort
        private async Task MergeSortRecursive(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                // Sort first half
                await MergeSortRecursive(array, left, middle);

                // Sort second half
                await MergeSortRecursive(array, middle + 1, right);

                // Merge both halves
                await Merge(array, left, middle, right);
            }
        }

        // Merge two sorted halves
        private async Task Merge(int[] array, int left, int middle, int right)
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
                await _visualizer.UpdateAsync(array, new[] {k});
                await Task.Delay(_delay,_token);
            }

            // Copy remaining elements of L[]
            while (iIndex < n1)
            {
                array[k] = L[iIndex];
                iIndex++;
                k++;

                await _visualizer.UpdateAsync(array, new[] {k});
                await Task.Delay(_delay,_token);
            }

            // Copy remaining elements of R[]
            while (jIndex < n2)
            {
                array[k] = R[jIndex];
                jIndex++;
                k++;

                await _visualizer.UpdateAsync(array, new[] { k });
                await Task.Delay(_delay,_token);
            }
        }
    }
}
