using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_League
{
    public class Conexión
    {
        private readonly string connectionString;


        public Conexión()
        {
            connectionString = "Server=DESKTOP-UBLQO8B;Database=pkmnleaguedb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        }

        public string GetConnectionString()
        {
            return connectionString;
        }
        public void ProbarConexion()
        {
            try
            {
                using var conexion = new SqlConnection(connectionString);
                conexion.Open();
                Console.WriteLine("conexion exitosa a SQL Server");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"error al conectar{ex.Message}");
            }
        }
    }
}

