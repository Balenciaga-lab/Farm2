using System;
using System.Data;
using System.Windows;
using Npgsql;

namespace Farm2
{
    public partial class DatabaseWindow : Window
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=farmready";
        private DataTable currentTable;

        public DatabaseWindow()
        {
            InitializeComponent();
        }

        private void OpenEquipmentTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("equipment");
        }

        private void OpenFarmTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("farm");
        }

        private void OpenPlantingTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("planting");
        }

        private void OpenCropTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("crop");
        }

        private void OpenFarmersTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("farmers");
        }

        private void OpenHarvestTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("harvest");
        }

        private void OpenSuppliersTable_Click(object sender, RoutedEventArgs e)
        {
            LoadTable("suppliers");
        }


        private void LoadTable(string tableName)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var query = $"SELECT * FROM {tableName}";
                    var adapter = new NpgsqlDataAdapter(query, connection);
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    currentTable = dataSet.Tables[0];
                    dataGrid.ItemsSource = currentTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                }
            }
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (currentTable != null)
            {
                var newRow = currentTable.NewRow();
                currentTable.Rows.Add(newRow);
            }
        }

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                DataRowView rowView = dataGrid.SelectedItem as DataRowView;
                rowView.Row.Delete();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close(); // Закрыть текущее окно работы с базой данных
        }

    }
}
