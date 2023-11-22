using System.ComponentModel.DataAnnotations;

namespace PATITAS.Models
{
    public class Descripcion
    {
        [Key]
        public int Descripcion_Id { get; set; }

        public string Contenido { get; set; }

        public Mascota Mascota { get; set; }
    }
}