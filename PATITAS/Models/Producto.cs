using System.ComponentModel.DataAnnotations;

namespace PATITAS.Models
{
    public class Producto
    {
        [Key]
        public int Producto_Id { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public double Costo_Unitario { get; set; }

        public ICollection<VentaProducto> VentaProducto { get; set; }

    }
}
