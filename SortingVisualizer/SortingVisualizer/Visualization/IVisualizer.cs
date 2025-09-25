using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Visiualization
{
    public interface IVisualizer
    {
        Task UpdateAsync(int[] array, int[] highlights = null);
    }
}
