using SistemaFacturacion.Dominio.Entidades;

namespace SistemaFacturacion.Aplicacion.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(Cliente cliente)
        {
            this.id = cliente.id;
            this.nombrecompleto = cliente.nombre + " " + cliente.apellido; 
            this.fecha_nacimiento = cliente.fecha_nacimiento.ToString("dd-MM-yyyy");
        }

        public int id { get; set; }

        public string nombrecompleto { get; set; }

        public string fecha_nacimiento { get; set; }
    }
}
