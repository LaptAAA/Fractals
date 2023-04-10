using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp2
{
    /// <summary>
    /// Класс, отвечающий за отрисовку Множества Кантора.
    /// </summary>
    class CantorSet : Fractal
    {
        /// <summary>
        /// Отступ фпактала.
        /// </summary>
        static public int Indent { get; set; }
        /// <summary>
        /// Метод, отвечающий за старт отрисовки фрактала.
        /// </summary>
        /// <param name="sender"> Объект, вызывающий событие.</param>
        /// <param name="e"> Информация о событии. </param>
        static public void DrawCantorSet(object sender, RoutedEventArgs e)
        {
            CantorSet fractal = new();
            // Отчищение холста
            MainWindow.MainCanvas.Children.Clear();
            // Если при вводе была совершена ошибка, то не начинаем отрисовку.
            if (CantorWindow.Good == false)
                return;
            else
                fractal.DrawFractal();
        }
        /// <summary>
        ///  Входная точка рекурсии.
        /// </summary>
        public override void DrawFractal()
        {
            // Точки с коордимнатами начала и конца начального отрезка.
            PointF A = new((float)(10 * MainWindow.MainCanvas.ActualWidth / 100), 2);
            PointF B = new((float)(90 * MainWindow.MainCanvas.ActualWidth / 100), A.Y);

            // Отрисовывание первой итерации.
            DrawLine( Brushes.Black, A, B, 4, Deep);
            // Следующий шаг рекурсии.
            Draw( A, B, Indent, Deep - 1);
        }

        // Рекурсивный метод отрисовки фрактала.
        private void Draw( PointF A, PointF B, float indent, int deep)
        {
            // Проверка для выхода из рекурсии.
            if (deep > 0)
            {
                // Определение длины отрисовываемых отрезков.
                float len = (B.X - A.X) / 3;

                // Вычисление координат начала и конца первого отрезка.
                PointF Aa = new(A.X, A.Y + indent);
                PointF Ab = new(A.X + len, Aa.Y);

                // Отрисовка первого отрезка.
                DrawLine( Brushes.Black, Aa, Ab, 4, deep);

                // Вычисление координат начала и конца второго отрезка.
                PointF Ba = new(B.X - len, indent + B.Y);
                PointF Bb = new(B.X, Ba.Y);

                // Отрисовка второго отрезка.
                DrawLine( Brushes.Black, Bb, Ba, 4, deep);

                // Следующий шаг рекурсии для только что нарисованных отрезков.
                Draw( Aa, Ab, indent, deep - 1);
                Draw( Ba, Bb, indent, deep - 1);

            }
        }
    }
}

