using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace List3.Commands
{
    public class Database
    {
        public void ConnectToDatabase()
        {
            string connectionString = "Server=tcp:server-maciejkloda.database.windows.net,1433;Initial Catalog=CarRental;Persist Security Info=False;User ID=CloudSAb8c31eed;Password=Admin123!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Debug.WriteLine("Działam!");
            try
            {
                SqlConnection conn;
                conn = new SqlConnection(connectionString);
                conn.Open();
                Debug.WriteLine("Połączono z bazą danych.");
                conn.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Błąd połączenia: {ex.Message}");
            }
        }
    }
}
