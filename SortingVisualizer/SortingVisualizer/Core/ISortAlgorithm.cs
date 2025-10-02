using System;
using System.Threading;
using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    // Interface for all sorting algorithms
    public interface ISortAlgorithm
    {
        // Name of the algorithm
        string Name { get; }

        // Asynchronous sort method with visualization
        Task SortAsync(int[] array, IVisualizer visualizer, Func<int> getDelay,CancellationToken token);
    }
}
