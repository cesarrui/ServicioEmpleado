using ServicioEmpleadoDDD.Domain.Entities;

namespace ServicioEmpleadoDDD.Domain.Repositories
{
    public interface IDocumentoRepository
    {
        List<Documento> GetDocumento();
    }
}