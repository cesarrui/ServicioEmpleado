using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ServicioEmpleadoDDD.DataAcces.Repositories;
using ServicioEmpleadoDDD.Domain.Entities;
using ServicioEmpleadoDDD.Domain.Repositories;

namespace ServicioEmpleadoDDD
{
    public class DocumentoFn
    {
        //Obtener Documentos
        [FunctionName("GetDocumentos")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Documento> documentos = new List<Documento>();
            try
            {

                IDocumentoRepository documentoRepository = new DocumentoRepository();
                documentos = documentoRepository.GetDocumento();
                return new OkObjectResult(documentos);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(documentos);
            }
        }
    }
}
