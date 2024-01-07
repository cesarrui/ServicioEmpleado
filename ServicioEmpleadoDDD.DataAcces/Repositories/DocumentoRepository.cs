using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;
using System.Data.SqlClient;
using System.Data;

namespace ServicioEmpleadoDDD.DataAcces.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        public List<Documento> GetDocumento()
        {
            List<Documento> documentos = new();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("ObtenerDocumentos", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    //sqlCommand.Parameters.Add(new SqlParameter("@id", id));
                    connection.Open();

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Documento documento = new Documento()
                            {
                                idDocumento = Convert.ToInt32(reader["idDocumento"]),
                                nombreDocumento = reader["nombreDocumento"].ToString(),

                            };
                            documentos.Add(documento);
                        }
                    }
                }

                return documentos;

            }
            catch (Exception ex)
            {
                return documentos;
            }
        }
    }
}