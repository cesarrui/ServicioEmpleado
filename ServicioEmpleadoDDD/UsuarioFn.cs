using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServicioEmpleadoDDD.DataAcces.Repositories;
using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;

namespace ServicioEmpleadoDDD
{
    public class UsuarioFn
    {
        //Verificar Usuario
        [FunctionName("VerificarUsuario")]
        public async Task<IActionResult> VerificarUsuario(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(requestBody);

                // Validacion de todos los campos
                if (usuario != null && !string.IsNullOrEmpty(usuario.usuario))
                {
                    IUsuarioRepository usuarioRepository = new UsuarioRepository();
                    int resultadoVerificacion = usuarioRepository.VerificarUsuario(usuario);

                    // Retornar el resultado de la verificación
                    return new OkObjectResult(resultadoVerificacion);
                }
                else
                {
                    return new BadRequestObjectResult("Datos del Usuario no válidos");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error al encontrar Usuario: {ex.Message}");
            }
        }
    }
}
