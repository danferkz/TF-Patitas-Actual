using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PATITAS.Models
{
    public class Cliente
    {
        [Key]
        public int Cliente_Id { get; set; }

        public string NombreApellido { get; set; }

        public int Telefono { get; set; }

        public string Correo { get; set; }

        public string Direccion { get; set; }
 
        public List<Mascota> Mascota{ get;  set; }

        
    }
}
