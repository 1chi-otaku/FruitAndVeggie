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
    /// Interaction logic for MoreLessWindow.xaml
    /// </summary>
    public partial class MoreLessWindow : Window
    {
        public int Value { get; private set; }
        public MoreLessWindow()
        {
            InitializeComponent();

           
        }

        
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Value = Convert.ToInt32(Regex.Replace(txtNumber.Text, "[^0-9.]", ""));
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
            }
        }
    }


}
