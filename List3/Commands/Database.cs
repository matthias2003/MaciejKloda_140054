using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;
using List3.Models;

namespace List3.Commands
{
    public class Database
    {
        private string _connectionString;
        private SqlConnection _conn;

        public string query;
        public void ConnectToDatabase()
        {
            
            _connectionString = "Server=tcp:server-maciejkloda.database.windows.net,1433;Initial Catalog=CarRental;Persist Security Info=False;User ID=CloudSAb8c31eed;Password=Admin123!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            try
            {
                _conn = new SqlConnection(_connectionString);
                _conn.Open();
                Debug.WriteLine("Połączono z bazą danych.");
                //_conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd połączenia: {ex.Message}");
            }
        }

        public ObservableCollection<Car> GetData()
        {
            query = "SELECT * FROM Cars";
            ObservableCollection<Car> Cars = new ObservableCollection<Car>();

            using (SqlCommand command = new SqlCommand(query, _conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int id = (int)reader["ID"];
                        string brand = reader["Brand"].ToString();
                        string model = reader["Model"].ToString();
                        string vinNumber = reader["VinNumber"].ToString();

                        Cars.Add(new Car(brand, model, vinNumber));

                        Debug.WriteLine($"ID: {id}, Brand: {brand}, Model: {model}, vinNumber: {vinNumber}");
                    }
                }
            }

            return Cars;
        }
    }
}
