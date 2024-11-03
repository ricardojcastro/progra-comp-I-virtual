using System.ComponentModel.DataAnnotations;

namespace Productos.Models
{
    public class Productos
    {
        [Key]
        public int IdProductos { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Presentacion { get; set; }
        public string Precio { get; set; }
        public string Stock { get; set; }

    }
}
