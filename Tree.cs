using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Класс, отвечающий за отрисовку фрактального дерева.
    /// </summary>
    public class Tree : Fractal
    {
        double startLen = 30;
        double minLen = 2;

        /// <summary>
        /// Правый угол фрактального дерева.
        /// </summary>
        static public int AngleRight { get; set; }
        /// <summary>
        /// Девый угол фрактального дерева.
        /// </summary>
        public static int AngleLeft { get; set; }

        /// <summary>
        /// Коэффициент фрактала.
        /// </summary>
        static public float Coef { get; set; }
        /// <summary>
        /// Метод, отвечающий за старт отрисовки фрактала.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e"> Информация о событии. </param>
        static public void DrawTree(object sender, RoutedEventArgs e)
        {
            Tree fractal = new();
            // Отчищение холста
            MainWindow.MainCanvas.Children.Clear();
            // Если при вводе была совершена ошибка, то не начинаем отрисовку.
            if (TreeWindow.Good == false)
                return;
            else
                fractal.DrawFractal();
            
        }
        /// <summary>
        /// Входная точка рекурсии.
        /// </summary>
        override public void DrawFractal()
        {
            // Точка начала.
            PointF A = new((float)(MainWindow.MainCanvas.ActualWidth / 2), (float)MainWindow.MainCanvas.ActualHeight);
            // Следующий шаг рекурсии.
            Draw( A, startLen, Coef, 0, Deep);
        } 

        // Рекурсивный метод отрисовки фрактала.
        void Draw( PointF A, double len, double coef, int angle, int deep)
        {
            // Проверка для выхода из рекурсии.
            if (deep > 0)
            {
                // Точка конца отрезка в зависимости от угла наклона.
                PointF p2 = new((float)(A.X + len * Math.Sin(angle * Math.PI * 2 / 360.0)),
                               (float)(A.Y - len * Math.Cos(angle * Math.PI * 2 / 360.0)));

                // Подсчет толщины.
                double thickness = 2 * ((len - minLen) / (startLen - minLen));
                DrawLine( Brushes.Black, A, p2, thickness, deep);

                // Следующий шаг рекурсии.
                Draw( p2, len * coef, coef , angle + AngleRight, deep - 1);
                Draw( p2, len * coef, coef, angle - AngleLeft, deep - 1);

            }
        }

    }
}
