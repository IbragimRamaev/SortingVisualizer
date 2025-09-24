# Sorting Visualizer (WPF, C#)

## About the Project
**Sorting Visualizer** is a learning project built with **C# and WPF** that demonstrates how different sorting algorithms work in real time.  

The application allows you to:
- Generate an array of random numbers
- Choose a sorting algorithm (Bubble Sort, Insertion Sort, Selection Sort, etc.)
- Watch step-by-step visualization of the sorting process (animated on Canvas)
- Adjust the sorting speed

The main goal of this project is to **practice clean coding, software architecture, SOLID principles, and Git workflow** while building something useful and visually engaging.

---

## Technologies
- **C# (.NET Framework / WPF)**
- **XAML** for UI
- **Asynchronous programming** (`async/await`)
- **Git + GitHub** for version control

---

## Project Structure

SortingVisualizer/
│
├─ Core/ # Sorting algorithms
│ ├─ QuickSort.cs
│ ├─ MergeSort.cs
│ ├─ BubbleSort.cs
│ └─ BubbleSort.cs
│
├─ Visualization/ # Interfaces and classes for visualization
│ ├─ IVisualizer.cs
│ └─ Visualizer.cs
│
├─ UI/ # UI code (MainWindow.xaml and .cs)
│
├─ MainWindow.xaml # Main window
├─ MainWindow.xaml.cs
├─ App.xaml
└─ App.xaml.cs
