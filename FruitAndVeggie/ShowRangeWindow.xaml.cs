using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FruitAndVeggie
{
    /// <summary>
    /// Interaction logic for ShowRangeWindow.xaml
    /// </summary>
    public partial class ShowRangeWindow : Window
    {
        public int StartValue { get; private set; }
        public int EndValue { get; private set; }
        public ShowRangeWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StartValue = Convert.ToInt32(Regex.Replace(txtStart.Text, "[^0-9.]", ""));
                EndValue = Convert.ToInt32(Regex.Replace(txtEnd.Text, "[^0-9.]", ""));
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
            }
        }
    }
}
