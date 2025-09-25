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

        // Async update method to redraw the array
        public async Task UpdateAsync(int[] array)
        {
            _canvas.Children.Clear();

            double canvasWidth = _canvas.ActualWidth == 0 ? 700 : _canvas.ActualWidth;
            double canvasHeight = _canvas.ActualHeight == 0 ? 400 : _canvas.ActualHeight;
            double barWidth = canvasWidth / array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                double barHeight = (array[i] / (double)array.Length) * canvasHeight;
                var rect = new Rectangle
                {
                    Width = barWidth - 2,
                    Height = barHeight,
                    Fill = Brushes.SteelBlue
                };
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                _canvas.Children.Add(rect);
            }

            await Task.Delay(50); // small delay for visualization
        }
    }
}
