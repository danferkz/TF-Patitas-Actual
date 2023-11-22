using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PATITAS.Models
{
    public class Mascota
    {
        [Key]
        public int Mascota_Id { get; set; }

        public string NombreMascota { get; set; }
        
        public string Sexo { get; set; }

        public double Peso { get; set; }    

        public string Raza { get; set; }

        public string Color { get; set; }

        public string Esterilizacion { get; set; }

        [ForeignKey("Cliente")]
        
        public int Cliente_Id { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Descripcion")]

        public int? Descripcion_Id { get; set; }

        public Descripcion Descripcion { get; set; }

        public List<Cita> Cita { get; set; }

    }
}
