using SortingVisualizer.Visualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Core
{
    public class InsertionSort : ISortAlgorithm
    {

        public string Name { get;}

        public InsertionSort(int[] array)
        {
            Name = "Insertion Sort";
        }

        public async Task SortAsync(int[] array, IVisualizer visualizer, int delayMs)
        {
            int n = array.Length;

            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i-1;
                
                // Shift larger elements to the right
                while (j >= 0 && array[j] > key) 
                {
                    array[j+1] = array[j];  
                    j--;

                    // Visualize shifting
                    await visualizer.UpdateAsync(array, new[] { i, j });
                    await Task.Delay(delayMs);
                }

                //Insert element at the correct position
                array[j+1] = key;

                //Visualize after insertion
                await visualizer.UpdateAsync(array, new[] { i });
            }
        }

        public Task SortAsync(IVisualizer visualizer)
        {
            throw new NotImplementedException();
        }
    }
}
