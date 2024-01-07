using ServicioEmpleadoDDD.DataAcces.Repositories;
using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioEmpleadoDDD.DataAcces.Test
{
    public class UsuarioRepositoryTest
    {
        [Fact]
        public async Task VerificarUsuario()
        {
            //Arrange
            int respuesta;
            IUsuarioRepository usuarioRepository = new UsuarioRepository();
            var usuario = new Usuario
            {
                usuario = "cesar",
                clave = "123"

            };

            //Act
            respuesta = usuarioRepository.VerificarUsuario(usuario);

            //Assert
            Assert.True(respuesta > 0);
        }
    }
}
