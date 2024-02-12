using System.Windows;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Controls.Primitives;

namespace FruitAndVeggie
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Fill(string query)
        {
            SqlConnection connect = new SqlConnection(@"Data Source=PECHKA\SQLEXPRESS;Initial Catalog=FruitnVeggies;Integrated Security=True");
            SqlCommand command = new SqlCommand();

            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = query;
                SqlDataReader reader = command.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                datagrid.ItemsSource = dt.DefaultView;

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void MenuItemShowAll_Click(object sender, RoutedEventArgs e)
        {
            Fill("SELECT * FROM FruitAndVeggies");
        }

        private void MenuItemShowNames_Click(object sender, RoutedEventArgs e)
        {
            Fill("Select Name from FruitAndVeggies");
        }

        private void MenuItemShowColourStatistics_Click(object sender, RoutedEventArgs e)
        {
            Fill(@"
                SELECT
                    Color,
                    COUNT(*) AS Count
                FROM
                    FruitAndVeggies
                GROUP BY
                    Color
                ORDER BY
                    Color");
        }

        private void MenuItemShowRedYellow_Click(object sender, RoutedEventArgs e)
        {
            Fill(@" SELECT
                    Name,
                    Type,
                    Color
                FROM
                    FruitAndVeggies
                WHERE
                    Color IN ('Yellow', 'Red')");
        }

        private void MenuItemShowMaxCalorie_Click(object sender, RoutedEventArgs e)
        {
            Fill("SELECT TOP 1 * FROM FruitAndVeggies WHERE Type = 'Fruit' ORDER BY Calories DESC");
        }

        private void MenuItemShowMinCalorie_Click(object sender, RoutedEventArgs e)
        {
            Fill("SELECT TOP 1 * FROM FruitAndVeggies WHERE Type = 'Fruit' ORDER BY Calories");
        }

        private void MenuItemShowAvgCalorie_Click(object sender, RoutedEventArgs e)
        {
            Fill("SELECT AVG(Calories) AS AverageCalories FROM FruitAndVeggies");
        }

        private void MenuItemShowFruitAmount_Click(object sender, RoutedEventArgs e)
        {
            Fill(" SELECT COUNT(*) AS FruitCount FROM FruitAndVeggies WHERE Type = 'Fruit'");
        }

        private void MenuItemShowVeggieAmount_Click(object sender, RoutedEventArgs e)
        {
            Fill(" SELECT COUNT(*) AS VeggieCount FROM FruitAndVeggies WHERE Type = 'Vegetable'");
        }

        private void MenuItemShowRedAmount_Click(object sender, RoutedEventArgs e)
        {
            Fill("SELECT COUNT(*) AS RedCount FROM FruitAndVeggies WHERE Color = 'Red'");
        }

        private void MenuItemShowLowerCalorie_Click(object sender, RoutedEventArgs e)
        {
            MoreLessWindow moreless = new MoreLessWindow();
            moreless.ShowDialog();

            int value = moreless.Value;

            Fill("SELECT * FROM FruitAndVeggies WHERE Calories < " + value);
        }

        private void MenuItemShowHigherCalorie_Click(object sender, RoutedEventArgs e)
        {
            MoreLessWindow moreless = new MoreLessWindow();
            moreless.ShowDialog();

            int value = moreless.Value;

            Fill("SELECT * FROM FruitAndVeggies WHERE Calories > " + value);
        }

        private void MenuItemShowWithinCalorieRange_Click(object sender, RoutedEventArgs e)
        {
            ShowRangeWindow rangeWindow = new ShowRangeWindow();
            rangeWindow.ShowDialog();

            int startValue = rangeWindow.StartValue;
            int endValue = rangeWindow.EndValue;

            Fill("SELECT * FROM FruitAndVeggies WHERE Calories BETWEEN " + startValue + " AND " + endValue);

        }
    }
}