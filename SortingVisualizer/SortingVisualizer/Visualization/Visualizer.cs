using SortingVisualizer.Visiualization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SortingVisualizer.Visualization
{
    public class Visualizer : IVisualizer
    {
        private readonly Canvas _canvas;

        public Visualizer(Canvas canvas)
        {
            _canvas = canvas;
        }

        public async Task UpdateAsync(int[] array, int[] highlights = null)
        {
            _canvas.Children.Clear();
            double barWidth = _canvas.ActualWidth / array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                double height = array[i];
                var rect = new Rectangle
                {
                    Width = barWidth - 2,
                    Height = height,
                    Fill = highlights != null && highlights.Contains(i)
                        ? Brushes.Red
                        : Brushes.Blue
                };

                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                _canvas.Children.Add(rect);
            }

            await Task.CompletedTask;
        }
    }
}
