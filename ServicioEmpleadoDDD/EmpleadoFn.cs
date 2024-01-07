using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.DataAcces.Repositories;
using ServicioEmpleadoDDD.Domain.Repositories;

namespace ServicioEmpleadoDDD
{
    public class EmpleadoFn
    {
        //Obtener Empleados
        [FunctionName("GetEmpleados")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Empleado> empleados = new List<Empleado>();
            try
            {
                //empleados = _empleadoRepository.GetEmpleados(0);
                IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
                empleados = empleadoRepository.GetEmpleados();
                return new OkObjectResult(empleados);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(empleados);
            }
        }

        //Insertar Empleados 
        [FunctionName("AddEmpleado")]
        public async Task<IActionResult> InsertarEmpleado(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Empleado empleado = JsonConvert.DeserializeObject<Empleado>(requestBody);

                // Validacion de todos los campos
                if (empleado != null && !string.IsNullOrEmpty(empleado.nombre))
                {
                    IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
                    empleadoRepository.AddEmpleado(empleado);

                    return new OkObjectResult(new { mensaje = "ok", response = "Empleado insertado correctamente" });
                }
                else
                {
                    return new OkObjectResult(new { mensaje = "ok", response = "Datos del empleado no válidos" });

                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error al insertar empleado: {ex.Message}");
            }
        }


        [FunctionName("UpdateEmpleado")]
        public async Task<IActionResult> UpdateEmpleado(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
        ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                Empleado empleado = JsonConvert.DeserializeObject<Empleado>(requestBody);

                // Validación de campos requeridos 
                if (empleado != null && empleado.idEmpleado > 0 && !string.IsNullOrEmpty(empleado.nombre))
                {
                    IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
                    // Llamada al método de actualización

                    empleadoRepository.UpdateEmpleado(empleado);

                    return new OkObjectResult(new { mensaje = "ok", response = "Empleado actualizado correctamente" });
                }
                else
                {
                    return new BadRequestObjectResult("Datos del empleado no válidos");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Error al actualizar empleado: {ex.Message}");
            }
        }
    }
}
