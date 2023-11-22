using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PATITAS.Models
{
    public class Cita
    {
        [Key]
        public int Cita_Id { get; set; }

        public string NombreCita { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public double Costo { get; set; }

        [ForeignKey("Mascota")]
        public int Mascota_Id { get; set; } 

        public Mascota Mascota { get; set; }

        [ForeignKey("Diagnostico")]
        public int? Diagnostico_Id { get; set; }

        public Diagnostico Diagnostico { get; set; }

        
    }
}
