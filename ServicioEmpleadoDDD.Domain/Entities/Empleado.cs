namespace ServicioEmpleadoDDD.Domain.Entities
{
    public class Empleado
    {
        public int idEmpleado { get; set; }
        public int idDocumento { get; set; }
        public string nombreDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaContratacion { get; set; }
        public int idPais { get; set; }
        public string nombrePais { get; set; }
        public int idArea { get; set; }
        public string nombreArea { get; set; }
        public int idSubArea { get; set; }
        public string nombreSubArea { get; set; }
        public string estado { get; set; }
    }
}