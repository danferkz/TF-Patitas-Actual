using System.ComponentModel.DataAnnotations.Schema;

namespace PATITAS.Models
{
    public class VentaProducto
    {
        [ForeignKey("Producto")]
        public int Producto_Id { get; set; }

        [ForeignKey("Venta")]
        public int Venta_Id { get; set;}

        public Producto Producto { get; set;}   

        public Venta Venta { get; set;} 

        public double Monto { get; set;}    
    }
}
