// Interface for visualizer
using System.Threading.Tasks;

namespace SortingVisualizer.Visualization
{
    public interface IVisualizer
    {
        // Method to update visualization asynchronously
        Task UpdateAsync(int[] array);
    }
}
