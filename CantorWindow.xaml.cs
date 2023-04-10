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
    /// Логика взаимодействия для CantorWindow.xaml
    /// </summary>
    public partial class CantorWindow : Window
    {
        /// <summary>
        /// Свойство, обозначающее корректность данных.
        /// </summary>
        static public bool Good { get; set; }
        private int deep;
        private int indent;
        /// <summary>
        /// Конструктор окна настроек множеcтва Кантора.
        /// </summary>
        public CantorWindow()
        {
            // Обнуляем статическое свойство.
            Good = false;
            InitializeComponent();
            // Привязка отрисовки множества кантора по щелчку на кнопку.
            buttonCreate.Click += CantorSet.DrawCantorSet;
        }

        private void ComboBox_SelectionChanged_Deep(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            int.TryParse(selectedItem.Text, out int n);
            deep = n;
            Fractal.Deep = n;
        }

        private void ComboBox_SelectionChanged_Indent(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TextBlock selectedItem = (TextBlock)comboBox.SelectedItem;
            int.TryParse(selectedItem.Text, out int n);
            // Из-за установленной толщины линий, добавляем +4 для получения именного того числа, которое было выбрано.
            indent = n + 4;
            CantorSet.Indent = n + 4;
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            // Если что-то из ввода не было выбранно, то выводим напоминание.
            if (deep != 0 && indent != 0)
            {
                Good = true;
                Close();
            }
            else
                MessageBox.Show("Провертье, выбрали ли все характеристики.");
        }
    }
}
