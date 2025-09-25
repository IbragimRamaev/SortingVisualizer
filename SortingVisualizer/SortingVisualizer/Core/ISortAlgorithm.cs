// Interface for sorting algorithms
using System.Threading.Tasks;
using SortingVisualizer.Visualization;

namespace SortingVisualizer.Core
{
    public interface ISortAlgorithm
    {
        // The array to sort
        int[] Array { get; set; }

        // Sort method with async for visualization
        Task SortAsync(IVisualizer visualizer);
    }
}
