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
    /// Класс, отвечающий за отрисовку треугольника Серпинского.
    /// </summary>
    class Triangle : Fractal
    {
        /// <summary>
        /// Метод, отвечающий за старт отрисовки фрактала.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e"> Информация о событии. </param>
        static public void DrawSierpinskiTriangle(object sender, RoutedEventArgs e)
        {
            Triangle fractal = new();
            // Отчищение холста
            MainWindow.MainCanvas.Children.Clear();
            // Если при вводе была совершена ошибка, то не начинаем отрисовку.
            if (DeepWindow.Good == false)
                return;
            else
                fractal.DrawFractal();
        }
        /// <summary>
        /// Входная точка рекурсии.
        /// </summary>
        override public void DrawFractal()
        {
            // Точки с коордимнатами начала и конца основания.
            PointF A = new((float)(0.05 * MainWindow.MainCanvas.ActualWidth), (float)MainWindow.MainCanvas.ActualHeight);
            PointF B = new((float)(0.95 * MainWindow.MainCanvas.ActualWidth), A.Y);
            // Точка вершины.
            PointF C = new((float)((B.X - A.X) * Math.Cos(60 * Math.PI * 2 / 360.0) + A.X),
                           (float)(-(B.X - A.X) * Math.Sin(60 * Math.PI * 2 / 360.0) + A.Y));

            // Отрисовка первой итерации.
            DrawTriangle(A, B, C, Deep);
            // Следующий шаг рекурсии.
            Draw(A, B, C, Deep - 1);
        }

        // Отрисовка треугольника.
        private void DrawTriangle(PointF A, PointF B, PointF C, int deep)
        {
            DrawLine(Brushes.Black, A, B, 0.15, deep);
            DrawLine(Brushes.Black, B, C, 0.15, deep);
            DrawLine(Brushes.Black, C, A, 0.15, deep);
        }
        public void Draw(PointF A, PointF B, PointF C, int deep)
        {
            // Проверка для выхода из рекурсии.
            if (deep > 0)
            {
                // Подсчет координат нового треугольника.
                PointF AB = new((float)(A.X + B.X) / 2, (float)(A.Y + B.Y) / 2);
                PointF BC = new((float)(C.X + B.X) / 2, (float)(C.Y + B.Y) / 2);
                PointF CA = new((float)(A.X + C.X) / 2, (float)(A.Y + C.Y) / 2);

                // Отрисовка нового треугольника.
                DrawTriangle(AB, BC, CA, deep);

                // Следующий шаг рекурсии.
                Draw(A, AB, CA, deep - 1);
                Draw(AB, B, BC, deep - 1);
                Draw(CA, BC, C, deep - 1);

            }
        }

    }
}
