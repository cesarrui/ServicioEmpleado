using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ServicioEmpleadoDDD.DataAcces.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

        public int VerificarUsuario(Usuario usuario)
        {
            try
            {
                using (var conection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("VerificarUsuario", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@usuario", SqlDbType.VarChar, 50)).Value = usuario.usuario;
                    sqlCommand.Parameters.Add(new SqlParameter("@clave", SqlDbType.VarChar, 1000)).Value = usuario.clave;

                    conection.Open();

                    // Ejecutar la consulta y obtener el resultado
                    int resultado = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar usuario: {ex.Message}");
                return -1;
            }
        }
    }
}