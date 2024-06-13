using System;
using System.Data.SqlClient;

namespace Factura
{
    public class DatabaseManagement
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=MiTienda;Integrated Security=True";

        public void ConsultarProductos()
        {
            string query = "SELECT * FROM Productos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Leer los datos de los productos y realizar las operaciones necesarias
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    decimal precio = reader.GetDecimal(2);
                    int existencia = reader.GetInt32(3);

                    Console.WriteLine($"ID: {id}, Nombre: {nombre}, Precio: {precio}, Existencia: {existencia}");
                }

                reader.Close();
            }
        }
    }
}

