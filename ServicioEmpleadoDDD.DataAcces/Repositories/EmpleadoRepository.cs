using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace ServicioEmpleadoDDD.DataAcces.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> empleados = new();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ObtenerListaEmpleadosDetallada", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    //sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado()
                            {
                                idEmpleado = Convert.ToInt32(reader["idEmpleado"]),
                                idDocumento = Convert.ToInt32(reader["idDocumento"]),
                                nombreDocumento = reader["nombreDocumento"].ToString(),
                                numeroDocumento = reader["numeroDocumento"].ToString(),
                                nombre = reader["nombre"].ToString(),
                                apellido = reader["apellido"].ToString(),
                                idArea = Convert.ToInt32(reader["idArea"]),
                                nombreArea = reader["nombreArea"].ToString(),
                                idSubArea = Convert.ToInt32(reader["idSubArea"]),
                                nombreSubArea = reader["nombreSubArea"].ToString(),
                                estado = reader["estado"].ToString(),
                                idPais = Convert.ToInt32(reader["idPais"]),
                                nombrePais = reader["nombrePais"].ToString(),
                                fechaContratacion = (DateTime)reader["fechaContratacion"]
                        };
                            empleados.Add(empleado);
                        }
                    }
                }

                return empleados;

            }
            catch (Exception ex)
            {
                return empleados;
            }


        }

        public bool AddEmpleado(Empleado empleado)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertarEmpleado", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 50)).Value = empleado.nombre;
                    sqlCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar, 50)).Value = empleado.apellido;
                    sqlCommand.Parameters.Add(new SqlParameter("@idDocumento", SqlDbType.Int)).Value = empleado.idDocumento;
                    sqlCommand.Parameters.Add(new SqlParameter("@numeroDocumento", SqlDbType.NVarChar, 50)).Value = empleado.numeroDocumento;
                    sqlCommand.Parameters.Add(new SqlParameter("@fechaContratacion", SqlDbType.Date)).Value = empleado.fechaContratacion;
                    sqlCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int)).Value = empleado.idPais;
                    sqlCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int)).Value = empleado.idArea;
                    sqlCommand.Parameters.Add(new SqlParameter("@idSubArea", SqlDbType.Int)).Value = empleado.idSubArea;

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar empleado: {ex.Message}");
                return false;
            }
        }

        public bool UpdateEmpleado(Empleado empleado)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ActualizarEmpleado", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    sqlCommand.Parameters.Add(new SqlParameter("@idEmpleado", SqlDbType.Int)).Value = empleado.idEmpleado;
                    sqlCommand.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar, 50)).Value = empleado.nombre;
                    sqlCommand.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar, 50)).Value = empleado.apellido;
                    sqlCommand.Parameters.Add(new SqlParameter("@idDocumento", SqlDbType.Int)).Value = empleado.idDocumento;
                    sqlCommand.Parameters.Add(new SqlParameter("@numeroDocumento", SqlDbType.NVarChar, 50)).Value = empleado.numeroDocumento;
                    sqlCommand.Parameters.Add(new SqlParameter("@fechaContratacion", SqlDbType.Date)).Value = empleado.fechaContratacion;
                    sqlCommand.Parameters.Add(new SqlParameter("@idPais", SqlDbType.Int)).Value = empleado.idPais;
                    sqlCommand.Parameters.Add(new SqlParameter("@idArea", SqlDbType.Int)).Value = empleado.idArea;
                    sqlCommand.Parameters.Add(new SqlParameter("@idSubArea", SqlDbType.Int)).Value = empleado.idSubArea;
                    sqlCommand.Parameters.Add(new SqlParameter("@estado", SqlDbType.NVarChar)).Value = empleado.estado;

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar empleado: {ex.Message}");
                return false;
            }
        }
    }
}