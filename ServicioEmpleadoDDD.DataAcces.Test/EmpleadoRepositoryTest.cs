using ServicioEmpleadoDDD.DataAcces.Repositories;
using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;

namespace ServicioEmpleadoDDD.DataAcces.Test
{
    public class EmpleadoRepositoryTest
    {
        [Fact]
        public async Task GetEmpleados()
        {
            //Arange
            List<Empleado> empleados = new List<Empleado>();
            IEmpleadoRepository empleadoRepository = new EmpleadoRepository();

            //act 
            empleados = empleadoRepository.GetEmpleados();

            //Assert
            Assert.True(empleados.Count() > 0);
        }

        [Fact]
        public void AddEmpleado()
        {
            // Arrange
            var empleadoRepository = new EmpleadoRepository();
            var empleado = new Empleado
            {
                idDocumento = 1,
                numeroDocumento = "1234",
                nombre = "Test",
                apellido = "Test",
                fechaContratacion = new DateTime(2024, 1, 4),
                idPais = 1,
                idArea = 1,
                idSubArea = 1
            };

            // Act
            bool respuesta = empleadoRepository.AddEmpleado(empleado);


            // Assert
            Assert.True(respuesta);
        }

        [Fact]
        public void UpdateEmpleado()
        {
            // Arrange
            var empleadoRepository = new EmpleadoRepository();
            var empleado = new Empleado
            {
                idEmpleado = 11,
                idDocumento = 1,
                numeroDocumento = "4321",
                nombre = "actualizado",
                apellido = "actualizado",
                fechaContratacion = new DateTime(2024, 1, 4),
                idPais = 2,
                idArea = 7,
                idSubArea = 4,
                estado = "Inactivo"
            };

            // Act
            bool respuesta = empleadoRepository.UpdateEmpleado(empleado);


            // Assert
            Assert.True(respuesta);
        }

    }
}
