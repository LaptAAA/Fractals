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
    /// Класс, реализирующий отрисовку Кривой Коха.
    /// </summary>
    public class KochСurve : Fractal
    {
        /// <summary>
        /// Метод, отвечающий за старт отрисовки фрактала.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e"> Информация о событии. </param>
        static public void DrawKoch(object sender, RoutedEventArgs e)
        {
            KochСurve fractal = new();
            // Отчищение холста
            MainWindow.MainCanvas.Children.Clear();
            // Если при вводе была совершена ошибка, то не начинаем отрисовку.
            if (DeepWindow.Good == false)
                return;
            else
                fractal.DrawFractal();
        }
        void Draw( PointF A, PointF B, int deep)
        {
            // Проверка для выхода из рекурсии.
            if (deep > 0)
            {
                // Точки лежащие на AB, Ab остоит на 1/3 от А, Ba остоит на 1/3 от B.
                PointF Ab = new PointF((float)((B.X - A.X) / 3 + A.X), (float)((B.Y - A.Y) / 3 + A.Y));
                PointF Ba = new PointF((float)(2 * (B.X - A.X) / 3 + A.X), (float)(2 * (B.Y - A.Y) / 3 + A.Y));

                DrawLine( Brushes.White, Ab, Ba, 0.5, deep);
                
                // Подсчет координат итоговыйх точек. 
                PointF C = new PointF((float)((B.X - A.X) * Math.Cos(60 * Math.PI * 2 / 360.0) 
                                   - (B.Y - A.Y) * Math.Sin(60 * Math.PI * 2 / 360.0) + A.X),
                                     (float)((B.X - A.X) * Math.Sin(60 * Math.PI * 2 / 360.0) 
                                   + (B.Y - A.Y) * Math.Cos(60 * Math.PI * 2 / 360.0) + A.Y));
                // Середина AB.
                PointF AB = new ((B.X + A.X) / 2, (B.Y + A.Y) / 2);
                // Вершина нового треугольника.
                PointF D = new ((4 * AB.X - C.X) / 3, (4 * AB.Y - C.Y) / 3);

                DrawLine( Brushes.Black, Ab, D, 0.15, deep);
                DrawLine( Brushes.Black, Ba, D, 0.15, deep);
               
                Draw(Ab, D, deep - 1);
                Draw( D, Ba, deep - 1);
                Draw( A, Ab, deep - 1);
                Draw(Ba, B, deep - 1);


            }
        }
        /// <summary>
        /// Входная точка рекурсии.
        /// </summary>
        override public void DrawFractal()
        {
            // Точки с коордимнатами начала и конца начального отрезка.
            PointF A = new ((float)(MainWindow.MainCanvas.ActualWidth / 100), (float)( 2 * MainWindow.MainCanvas.ActualHeight / 3));
            PointF B = new ((float)(99 * MainWindow.MainCanvas.ActualWidth / 100), (float)(A.Y));

            // Отрисовывание первой итерации.
            DrawLine( Brushes.Black, A, B, 0.15, Deep);
            // Следующий шаг рекурсии.
            Draw( A, B, Deep);
        }
    }
}
