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
    public class DocumentoRepositoryTest
    {
        [Fact]
        public async Task GetDocumento()
        {
            //Arrange
            List<Documento> documentos = new List<Documento>();
            IDocumentoRepository documentoRepository = new DocumentoRepository();

            //Act
            documentos = documentoRepository.GetDocumento();

            //Assert
            Assert.True(documentos.Count > 0);
        }
    }
}
