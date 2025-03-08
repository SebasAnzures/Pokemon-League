using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_League
{
    class Pokemonentrenadorrepository : Ipokemonentrenadorrepository
    {
        private readonly string connectionString;
        public Pokemonentrenadorrepository(Conexión conexion)
        {
            connectionString = conexion.GetConnectionString();
        }
        public void Actualizar(Entrenadores entrenador)
        {
            throw new NotImplementedException();
        }

        public void Crear(Entrenadores entrenador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "insert into entrenadores (nombre, ciudad, pokemon," +
                    "tipo, nivel, m1, m2, m3, m4, ligadanada) values (@nombre, @ciudad, @pokemon," +
                    "@tipo, @nivel, @m1, @m2, @m3, @m4, @ligadanada)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", entrenador.nombre);
                cmd.Parameters.AddWithValue("@ciudad", entrenador.ciudad);
                cmd.Parameters.AddWithValue("@pokemon", entrenador.pokemon);
                cmd.Parameters.AddWithValue("@tipo", entrenador.tipo);
                cmd.Parameters.AddWithValue("@nivel", entrenador.nivel);
                cmd.Parameters.AddWithValue("@m1", entrenador.m1);
                cmd.Parameters.AddWithValue("@m2", entrenador.m2);
                cmd.Parameters.AddWithValue("@m3", entrenador.m3);
                cmd.Parameters.AddWithValue("@m4", entrenador.m4);
                cmd.Parameters.AddWithValue("@ligadanada", entrenador.ligadanada);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine($"Entrenador {entrenador.nombre} agregado con exito");
        }

        public void Eliminar(int identrenador)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "delete from entrenadores where identrenador = @identrenador";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@identrenador", identrenador);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine($"El entrenador {identrenador} ha sido eliminado con exito");
        }

        public List<Entrenadores> Leer()
        {
            List<Entrenadores> entrenadors = new List<Entrenadores>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "Select * from entrenadores";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    entrenadors.Add(new Entrenadores
                    {
                        identrenador = Convert.ToInt32(reader["identrenador"]),
                        nombre = reader["nombre"].ToString(),
                        ciudad = reader["ciudad"].ToString(),
                        pokemon = reader["pokemon"].ToString(),
                        tipo = reader["tipo"].ToString(),
                        nivel = Convert.ToInt32(reader["nivel"]),
                        m1 = reader["m1"].ToString(),
                        m2 = reader["m2"].ToString(),
                        m3 = reader["m3"].ToString(),
                        m4 = reader["m4"].ToString(),
                        ligadanada = reader["ligadanada"].ToString()
                    });
                }
            }
            return entrenadors;
        }
    }
}
