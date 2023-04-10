using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для GradientWindow.xaml
    /// </summary>
    public partial class GradientWindow : Window
    {
        // Переменные, отвечающие за насыщенность красного, зеленого и синего.
        static byte redStart;
        static byte greenStart;
        static byte blueStart;

        static byte redEnd;
        static byte greenEnd;
        static byte blueEnd;

        /// <summary>
        /// Конструктор окна настроек градиента.
        /// </summary>
        public GradientWindow()
        {
            InitializeComponent();

            // Отображаем текущие выбранные цвета.
            Red1.Text = redStart.ToString();
            Green1.Text = greenStart.ToString();
            Blue1.Text = blueStart.ToString();

            Red2.Text = redEnd.ToString();
            Green2.Text = greenEnd.ToString();
            Blue2.Text = blueEnd.ToString();

            // Привязка на нажатие кнопки. 
            SelectFractal();
        }

        
        // Предварительная проверка текста.
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsOk);
        }

        private void OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            var stringData = (string)e.DataObject.GetData(typeof(string));
            if (stringData == null || !stringData.All(IsOk))
                e.CancelCommand();
        }
        /// <summary>
        /// Ограничение на ввод только цифр.
        /// </summary>
        /// <param name="c"> Вводимый элемент.</param>
        /// <returns> True - если число, False - усли не число.</returns>
        private bool IsOk(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }

        /// <summary>
        /// Перерисовка фрактала при изменении градиента.
        /// </summary>
        public void SelectFractal()
        {
            switch (Fractal.Name)
            {
                case "Кривая Коха":
                    button1.Click += KochСurve.DrawKoch;
                    break;
                case "Ковер Серпинского":
                    button1.Click += Сarpet.DrawSierpinskiСarpet;
                    break;
                case "Треугольник Серпинского":
                    button1.Click += Triangle.DrawSierpinskiTriangle;
                    break;
                case "Множество Кантора":
                    button1.Click += CantorSet.DrawCantorSet;
                    break;
                case "Фрактальное дерево":
                    button1.Click += Tree.DrawTree;
                    break;
            }
        }
        /// <summary>
        /// Проверка на корректность ввода насыщенности цветов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (byte.TryParse(Red1.Text, out redStart) == true &&
                byte.TryParse(Green1.Text, out greenStart) == true &&
                byte.TryParse(Blue1.Text, out blueStart) == true &&

                byte.TryParse(Red2.Text, out redEnd) == true &&
                byte.TryParse(Green2.Text, out greenEnd) == true &&
                byte.TryParse(Blue2.Text, out blueEnd) == true)
            {
                Fractal.RedStart = redStart;
                Fractal.GreenStart = greenStart;
                Fractal.BlueStart = blueStart;

                Fractal.RedEnd = redEnd;
                Fractal.GreenEnd = greenEnd;
                Fractal.BlueEnd = blueEnd;

                Close();
                
            }
            else
            {
                MessageBox.Show($"Проверьте введенные данные\nНапоминание: в каждой ячейке должно быть целое число от 0 до 255");
            }
        }
    }
}
