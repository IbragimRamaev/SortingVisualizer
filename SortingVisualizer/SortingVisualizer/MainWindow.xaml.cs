// Always use English comments
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using SortingVisualizer.Core;
using SortingVisualizer.Visualization;

namespace SortingVisualizer
{
    public partial class MainWindow : Window
    {
        private int[] array; // The array we will visualize
        private Random rand = new Random(); // Random generator

        public MainWindow()
        {
            InitializeComponent(); // Connects XAML with this C# file
            GenerateArray((int)ArraySizeSlider.Value);

            // Button events
            ResetButton.Click += (s, e) => GenerateArray((int)ArraySizeSlider.Value);
            StartButton.Click += async (s, e) => await StartSortingAsync();
        }

        // Generate a new random array
        private void GenerateArray(int size)
        {
            array = Enumerable.Range(1, size).OrderBy(x => rand.Next()).ToArray();
            DrawArray();
        }

        // Draw array as rectangles in Canvas
        private void DrawArray()
        {
            ArrayCanvas.Children.Clear();
            double canvasWidth = ArrayCanvas.ActualWidth == 0 ? 700 : ArrayCanvas.ActualWidth;
            double canvasHeight = ArrayCanvas.ActualHeight == 0 ? 400 : ArrayCanvas.ActualHeight;

            double barWidth = canvasWidth / array.Length;

            for (int i = 0; i < array.Length; i++)
            {
                double barHeight = (array[i] / (double)array.Length) * canvasHeight;
                Rectangle rect = new Rectangle
                {
                    Width = barWidth - 2,
                    Height = barHeight,
                    Fill = Brushes.SteelBlue
                };
                Canvas.SetLeft(rect, i * barWidth);
                Canvas.SetBottom(rect, 0);
                ArrayCanvas.Children.Add(rect);
            }
        }

        // Start sorting array with selected algorithm
        private async Task StartSortingAsync()
        {
            // Create visualizer linked to Canvas
            var visualizer = new Visualizer(ArrayCanvas);

            // Boublle sorting
            ISortAlgorithm sorter = new BubbleSort(array);

            // Run sorting asynchronously (with visualization)
            await sorter.SortAsync(visualizer);
        }
    }
}
