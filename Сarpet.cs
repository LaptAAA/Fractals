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
    /// Класс, отвечающий за отрисовку ковера Серпинского.
    /// </summary>
    class Сarpet : Fractal
    {
        /// <summary>
        /// Метод, отвечающий за старт отрисовки фрактала.
        /// </summary>
        /// <param name="sender">Объект, вызывающий событие.</param>
        /// <param name="e"> Информация о событии. </param>
        static public void DrawSierpinskiСarpet(object sender, RoutedEventArgs e)
        {
            Сarpet fractal = new();
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
        public override void DrawFractal()
        {
           // Точки начального квадрата.
            PointF A = new((float)(10 * MainWindow.MainCanvas.ActualWidth / 100), 0);
            PointF B = new((float)(90 * MainWindow.MainCanvas.ActualWidth / 100), A.Y);
            PointF D = new(A.X, (float)(80 * MainWindow.MainCanvas.ActualWidth / 100));
            PointF C = new(B.X, (float)(80 * MainWindow.MainCanvas.ActualWidth / 100));

            // Отрисовка первой итерации.
            DrawRectangle(A, B, Deep);
            // Следующий шаг рекурсии.
            Draw(A, B, C, D, Deep - 1);
        }

        private SolidColorBrush SelectColor(System.Windows.Shapes.Rectangle rect, int level)
        {
            var brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
            // Если градиент не установлен, то пенрвая итерация должна быть черной, остальные белой. 
            if (RedStart == 0 && GreenStart == 0 && BlueStart == 0 &&
                  RedEnd == 0 && GreenEnd == 0 && BlueEnd == 0)
            {
                if (level == Deep)
                    brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 0, 0, 0));
                else
                    brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            }
            // Если глубина равна 1 то устанавливаем стартовый цвет.
            else if (Deep == 1)
                brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, RedStart, GreenStart, BlueStart));
            // Иначе расчитываем цвет в зависимости от уровня.
            else
                brush = SelectBrush(level);
            return brush;
        }
        private void DrawRectangle(PointF A, PointF B, int level)
        {
            // Создаем пярмоугольник.
            System.Windows.Shapes.Rectangle rect = new();
            // Устанавливаем цвет  и настройки.
            var brush = SelectColor(rect, level);

            rect.Stroke = brush;
            rect.Fill = brush;
            rect.Width = B.X - A.X;
            rect.Height = rect.Width;

            // Устанавливаем где будет рисоваться  квадарат.
            Canvas.SetLeft(rect, A.X);
            Canvas.SetTop(rect, A.Y);
            // Добавляем квадрат на холст.
            MainWindow.MainCanvas.Children.Add(rect);
        }


        private void DoNextStep(PointF A, PointF B, PointF C, PointF D,
                             PointF Aa, PointF Bb, PointF Cc, PointF Dd,
                             PointF Ad, PointF Ba, PointF Cb, PointF Dc,
                             PointF Ab, PointF Bc, PointF Cd, PointF Da, int deep)
        {
            // Левый верхний квадрат.
            Draw(A, Ab, Aa, Ad, deep - 1);
            // Правый верхний квадрат.
            Draw(Ba, B, Bc, Bb, deep - 1);
            // Правый нижний квадрат.
            Draw(Cc, Cb, C, Cd, deep - 1);
            // Левый нижний квадрат.
            Draw(Da, Dd, Dc, D, deep - 1);

            // Верхний центральный квадрат.
            Draw(Ab, Ba, Bb, Aa, deep - 1);
            // Левый центральный квадрат.
            Draw(Ad, Aa, Dd, Da, deep - 1);
            // Правый центральный квадрат.
            Draw(Bb, Bc, Cb, Cc, deep - 1);
            // Нижний центральный квадрат.
            Draw(Dd, Cc, Cd, Dc, deep - 1);


        }
        /// <summary>
        /// Отрисовка следующего уровня.
        /// </summary>
        /// <param name="A"> Верхняя левая точка квадрата.</param>
        /// <param name="B"> Верхняя правая точка квадрата.</param>
        /// <param name="C"> Нижняя правая точка квадрата.</param>
        /// <param name="D"> Нижняя левая точка квадрата.</param>
        /// <param name="deep"> Текущий уровень.</param>
        public void Draw(PointF A, PointF B, PointF C, PointF D, int deep)
        {
            // Проверка для выхода из рекурсии.
            if (deep > 0)
            {
                float x = (float)(B.X - A.X) / 3;
                float y = (float)(D.Y - A.Y) / 3;

                // Центральный квадрат.
                PointF Aa = new(x + A.X, y + A.Y);
                PointF Bb = new(2 * x + A.X, Aa.Y);
                PointF Cc = new(Bb.X, 2 * y + A.Y);
                PointF Dd = new(Aa.X, Cc.Y);

                DrawRectangle(Aa, Bb, deep);

                // Подсчет координат точек для не центральных квадратов.
                PointF Ab = new(Aa.X, A.Y);
                PointF Ad = new(A.X, Aa.Y);

                PointF Ba = new(Bb.X, B.Y);
                PointF Bc = new(B.X, Bb.Y);

                PointF Cb = new(C.X, Cc.Y);
                PointF Cd = new(Cc.X, C.Y);

                PointF Da = new(D.X, Dd.Y);
                PointF Dc = new(Dd.X, D.Y);

                // Следующий шаг рекурсии.
                DoNextStep(A, B, C, D, Aa, Bb, Cc, Dd, Ad, Ba, Cb, Dc, Ab, Bc, Cd, Da, deep);

            }
        }
    }
}
