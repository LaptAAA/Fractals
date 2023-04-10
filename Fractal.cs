using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Абстрактный класс, являющийся родительским для каждого из классов конкретных фракталов.
    /// </summary>
    public abstract class Fractal
    {
        /// <summary>
        /// Насыщенность красного в стартовом цвете.
        /// </summary>
        public static byte RedStart { get; set; }
        /// <summary>
        /// Насыщенность зеленного в стартовом цвете.
        /// </summary>
        public static byte GreenStart { get; set; }
        /// <summary>
        /// Насыщенность синего в стартовом цвете.
        /// </summary>
        public static byte BlueStart { get; set; }
        /// <summary>
        /// Насыщенность красного в конечном цвете.
        /// </summary>
        static public byte RedEnd { get; set; }
        /// <summary>
        /// Насыщенность зеленного в конечном цвете.
        /// </summary>
        static public byte GreenEnd { get; set; }
        /// <summary>
        /// Насыщенность синего в конечном цвете.
        /// </summary>
        static public byte BlueEnd { get; set; }

        /// <summary>
        /// Глубина фрактала.
        /// </summary>
        static public int Deep { get; set; }
        /// <summary>
        /// Название фрактала.
        /// </summary>
        static public string Name { get; set; }
        
        /// <summary>
        /// Метод, отвечающий за отрисовку фрактала.
        /// </summary>
        abstract public void DrawFractal();

        /// <summary>
        /// Метод, отвечающий за подсчет цвета градиента на текущем уровне рекурсии.
        /// </summary>
        /// <param name="level"> Уровень рекурсии. </param>
        /// <returns> Цвет кисти.</returns>
        public SolidColorBrush SelectBrush(int level)
        {
            // Подсчет насыщностей красного, зеленого и синего для текущего уровня.
            byte red = (byte)((level - 1) * (RedStart) / (Deep - 1) + (Deep - level) * (RedEnd) / (Deep - 1));
            byte green = (byte)((level - 1) * (GreenStart) / (Deep - 1) + (Deep - level) * (GreenEnd) / (Deep - 1));
            byte blue = (byte)((level - 1) * (BlueStart) / (Deep - 1) + (Deep - level) * (BlueEnd) / (Deep - 1));
            var brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, red, green, blue));
            return brush;
        }
        /// <summary>
        /// Метод, отвечающий за отрисовку отрезка.
        /// </summary>
        /// <param name="color"> Цвет кисти. </param>
        /// <param name="A"> Начальная точка отрезка. </param>
        /// <param name="B"> Конечная точка отрезка. </param>
        /// <param name="thickness"> Толщина кисти. </param>
        /// <param name="level"> Уровень рекурсии. </param>
        public void DrawLine( Brush color, PointF A, PointF B, double thickness, int level)
        {
            Line line = new();
            line.StrokeThickness = thickness;

            // Если в качестве параметра был передан белый цвет, то устанавливаем его, если глубина рекурсии 1, то устанавливаем начальный цвет.
            if (color == Brushes.White)
                line.Stroke = color;
            else if (Deep == 1)
                line.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, RedStart, GreenStart, BlueStart));
            else
                line.Stroke = SelectBrush(level);

            // Устанавливаем координаты для отрезка.
            line.X1 = A.X;
            line.Y1 = A.Y;
            line.X2 = B.X;
            line.Y2 = B.Y;

            // Добавляем отрезок на холст.
            MainWindow.MainCanvas.Children.Add(line);
        }

    }
}
