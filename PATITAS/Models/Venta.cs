using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PATITAS.Models
{
    public class Venta
    {
        [Key]
        public int Venta_Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey("Cliente")]
        public int Cliente_Id { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Trabajador")]
        public int Trabajador_Id { get; set; }

        public Trabajador Trabajador { get; set; }

        public ICollection<VentaProducto> VentaProducto { get; set; }   

    }
}
