using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace List3.Commands
{
    public class Database
    {
        public void ConnectToDatabase()
        {
            string connectionString = "Server=tcp:server-maciejkloda.database.windows.net,1433;" +
                                      "Initial Catalog=CarRental;" +
                                      "Encrypt=True;" +
                                      "TrustServerCertificate=False;" +
                                      "Connection Timeout=30;" +
                                      "Authentication=Active Directory Default;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Połączono z bazą danych.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd połączenia: {ex.Message}");
            }
        }
    }
}
