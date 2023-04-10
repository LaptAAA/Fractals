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
    /// Логика взаимодействия для DeepWindow.xaml
    /// </summary>
    public partial class DeepWindow : Window
    {
        /// <summary>
        /// Свойство, обозначающее корректность данных.
        /// </summary>
        static public bool Good { get; set; }
        private int deep;
        /// <summary>
        /// Конструктор окна глубины.
        /// </summary>
        /// <param name="name"> Имя текущего фрактала. </param>
        public DeepWindow(string name)
        {
            // Обнуляем статическое свойство.
            Good = false;
            InitializeComponent();
            // Меняем название окна на имя текущего фрактала.
            labelName.Content = name;
            Select();
        }
        /// <summary>
        /// Выбор привязки на кнопку.
        /// </summary>
        private void Select()
        {
            switch (labelName.Content)
            {
                case "Кривая Коха":
                    buttonCreate.Click += KochСurve.DrawKoch;
                    break;
                case "Ковер Серпинского":
                    buttonCreate.Click += Сarpet.DrawSierpinskiСarpet; 
                    break;
                case "Треугольник Серпинского":
                    buttonCreate.Click += Triangle.DrawSierpinskiTriangle;
                    break;
                case "Меню":
                    SelectFractal();
                    break;
            }
        }
        /// <summary>
        /// Перерисовка фрактала при изменении глубины из меню.
        /// </summary>
        private void SelectFractal()
        {
            switch (Fractal.Name)
            {
                case "Кривая Коха":
                    buttonCreate.Click += KochСurve.DrawKoch;
                    break;
                case "Ковер Серпинского":
                    buttonCreate.Click += Сarpet.DrawSierpinskiСarpet;
                    break;
                case "Треугольник Серпинского":
                    buttonCreate.Click += Triangle.DrawSierpinskiTriangle;
                    break;
                case "Множество Кантора":
                    buttonCreate.Click += CantorSet.DrawCantorSet;
                    break;
                case "Фрактальное дерево":
                    buttonCreate.Click += Tree.DrawTree;
                    break;
            }
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            // Если глубина не была выбрана, то выводим напоминание.
            if (deep != 0)
            {
                Good = true;
                Close();
            }
            else
                MessageBox.Show("Провертье, выбрали ли Вы глубину.");
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            int.TryParse(selectedItem.Text, out int n);
            deep = n;
            Fractal.Deep = n;
        }
    }
}
