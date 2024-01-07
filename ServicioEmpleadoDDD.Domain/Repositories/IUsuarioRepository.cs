using ServicioEmpleadoDDD.Domain.Entities;

namespace ServicioEmpleadoDDD.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        int VerificarUsuario(Usuario usuario);
    }
}