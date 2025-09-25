using SortingVisualizer.Visiualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Core
{
    public interface ISortAlgorithm
    {
        Task SortAsync(int[] array, IVisualizer visualizer, int delayMs);
    }
}
