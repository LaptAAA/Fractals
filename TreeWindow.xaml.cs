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
    /// Логика взаимодействия для TreeWindow.xaml
    /// </summary>
    public partial class TreeWindow : Window
    {
        /// <summary>
        /// Свойство, обозначающее корректность данных.
        /// </summary>
        static public bool Good { get; set; }
        private int deep;
        private int angleRight;
        private int angleLeft;
        private float coef;
        /// <summary>
        /// Конструктор окна для настроек фрактального дерева.
        /// </summary>
        public TreeWindow()
        {
            // Обнуляем статическое свойство.
            Good = false;
            InitializeComponent();
            buttonCreate.Click += Tree.DrawTree;

            buttonL.Text = angleLeft.ToString();
            buttonR.Text = angleRight.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(buttonR.Text, out angleRight);
            int.TryParse(buttonL.Text, out angleLeft);
            // Проверка ввода на корректность.
            if (deep != 0 && coef != 0 && 
                0<= angleRight && 90 >= angleRight &&
                0<= angleLeft && 90 >= angleLeft)
            {
                Tree.AngleLeft = angleLeft;
                Tree.AngleRight = angleRight;
                Good = true;
                Close();
                
            }
            else
            {
                MessageBox.Show("Провертье корректность введенных данных и все ли выбрано.\n" +
                    "Напоминание: значение углов должны находиться \n" +
                    "в пределах от 0 до 90 включительно.");
            }
            
        }

        private void ComboBox_SelectionChanged_Coef(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            // Удаление знака процента в конце.
            string text = selectedItem.Text.Trim('%');
            int.TryParse(text, out int n);
            
            coef = (float)(1.0*n/100);
            Tree.Coef = coef;

        }

        private void ComboBox_SelectionChanged_Deep(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            int.TryParse(selectedItem.Text, out int n);
            deep = n;
            Fractal.Deep = n;
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
    }
}
