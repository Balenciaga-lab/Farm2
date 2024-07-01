using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

public class DatabaseManager
{
    private string connectionString;

    public DatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool TestConnection()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подключения: {ex.Message}");
                return false;
            }
        }
    }

    public DataTable ExecuteQuery(string query)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                var dataTable = new DataTable();
                var adapter = new NpgsqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения запроса: {ex.Message}");
                return null;
            }
        }
    }

    // Другие методы для работы с базой данных (вставка, обновление, удаление данных)
}
