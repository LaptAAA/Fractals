using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///  Основной холст программы.
        /// </summary>
        static public Canvas MainCanvas { get; set; }

        /// <summary>
        /// Конструктор основного окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            MainCanvas = mainCanvas;
        }

        /// <summary>
        /// Метод, срабатывающий при выборе отрисовки фрактального дерева.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_Tree(object sender, RoutedEventArgs e)
        {
            Fractal.Name = "Фрактальное дерево";
            TreeWindow win = new();
            // Привязываем созданное окно к основному.
            win.Owner = this;
            win.Show();
        }
        /// <summary>
        /// Метод, срабатывающий при выборе отрисовки кривой Коха.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_KochСurve(object sender, RoutedEventArgs e)
        {
            Fractal.Name = "Кривая Коха";
            DeepWindow win = new("Кривая Коха");
            win.Owner = this;
            win.Show();
        }
        /// <summary>
        /// Метод, срабатывающий при выборе отрисовки ковера Серпинского.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_SierpinskiСarpet(object sender, RoutedEventArgs e)
        {
            Fractal.Name = "Ковер Серпинского";
            DeepWindow win = new("Ковер Серпинского");
            win.Owner = this;
            win.Show();
        }
        /// <summary>
        /// Метод, срабатывающий при выборе отрисовки треугольника Серпинского.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_SierpinskiTriangle(object sender, RoutedEventArgs e)
        {
            Fractal.Name = "Треугольник Серпинского";
            DeepWindow win = new("Треугольник Серпинского");
            win.Owner = this;
            win.Show();
        }
        /// <summary>
        /// Метод, срабатывающий при выборе отрисовки множества Кантера.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_CantorSet(object sender, RoutedEventArgs e)
        {
            Fractal.Name = "Множество Кантора";
            CantorWindow win = new();
            win.Owner = this;
            win.Show();
        }
        /// <summary>
        /// Метод, срабатывающий при выборе сохранения.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие. </param>
        /// <param name="e"> Информация о событии. </param>
        private void MenuItem_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog save = new();
                save.Filter = "Изображение (.png)|*.png";
                if (save.ShowDialog() == true)
                    ToImageSource(save.FileName);

            }
            catch
            {
                MessageBox.Show("Произошла ошибка.");
            }
            
        }

        private static void ToImageSource(string filename)
        {
            // устанавливаем качество изображения
            double dpi = 300;
            double scale = dpi / 96;

            Size size = MainCanvas.RenderSize;
            RenderTargetBitmap image = new((int)(size.Width * scale), (int)(size.Height * scale), dpi, dpi, PixelFormats.Pbgra32);
            image.Render(MainCanvas);

            // конвертация в файл png
            PngBitmapEncoder encoder = new();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using FileStream file = File.Create(filename);
            encoder.Save(file);
        }

        private void MenuItem_Deep(object sender, RoutedEventArgs e)
        {
            DeepWindow win = new("Меню");
            win.Owner = this;
            win.Show();
        }

        private void MenuItem_Gradient(object sender, RoutedEventArgs e)
        {
            GradientWindow win = new();
            win.Owner = this;
            win.Show();
        }

    }


}
