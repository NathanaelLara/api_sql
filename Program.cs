using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.Win32.SafeHandles;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

string connString = "Server=localhost;Database=Northwind;User Id=Sa;Password=Sa123456;TrustServerCertificate=True";

Console.WriteLine("Conexion Abierta");

using (var conn = new SqlConnection(connString))
{
    try
    {
        conn.Open();
        string query = "SELECT * FROM employees";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@Edad", "34");

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["FirstName"]});
                    Console.WriteLine($"{reader["LastName"]});
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
