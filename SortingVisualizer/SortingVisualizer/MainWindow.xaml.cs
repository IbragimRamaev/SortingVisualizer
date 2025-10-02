using System;
using System.Linq;
using System.Threading;
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
        private bool _isSorting;
        private CancellationTokenSource _cts;
        private Random rand = new Random(); // Random generator


        public MainWindow()
        {
            InitializeComponent();
            GenerateArray((int)ArraySizeSlider.Value);

            // Populate algorithm selection
            AlgorithmComboBox.ItemsSource = new string[] { "Bubble Sort", "Insertion Sort", "Selection Sort", "MergeSort" };
            AlgorithmComboBox.SelectedIndex = 0;

            // Button events
            ResetButton.Click += (s, e) =>
            {
                _cts?.Cancel(); // Stop cycle
                GenerateArray((int)ArraySizeSlider.Value); // recreat array
            };
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
            if (_isSorting) return;
            _isSorting = true;

            GenerateArray((int)ArraySizeSlider.Value);

            _cts = new CancellationTokenSource();
            var visualizer = new Visualizer(ArrayCanvas);

            // Get selected algorithm from ComboBox
            string selectedAlgorithm = AlgorithmComboBox.SelectedItem as string;

            // Create sorter instance
            ISortAlgorithm sorter;
            switch (selectedAlgorithm)
            {
                case "Bubble Sort":
                    sorter = new BubbleSort(array);
                    break;
                case "Insertion Sort":
                    sorter = new InsertionSort(array);
                    break;
                case "Selection Sort":
                    sorter = new SelectionSort(array);
                    break;
                case "MergeSort":
                    sorter = new MergeSort(array);
                    break;
                default:
                    throw new Exception("Unknown sorting algorithm");
            }

            // Get delay in ms from slider
            int delayMs = (int)this.SpeedSlider.Value;
            try
            {
                // Run sorting asynchronously
                await sorter.SortAsync(
                        array,
                        visualizer,
                        () =>
                        {
                            int speed = (int)SpeedSlider.Value;
                            if (speed >= 1000) return 0;       
                            return Math.Max(1, 1000 / speed);  
                        },
                        _cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorting was canceled");
            }
            finally
            {
                _isSorting = false; 
            }

        }


    }
}
