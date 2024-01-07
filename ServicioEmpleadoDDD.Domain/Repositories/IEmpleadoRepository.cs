using ServicioEmpleadoDDD.Domain.Entities;

namespace ServicioEmpleadoDDD.Domain.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> GetEmpleados();
        bool AddEmpleado(Empleado empleado);
        bool UpdateEmpleado(Empleado empleado);
    }
}