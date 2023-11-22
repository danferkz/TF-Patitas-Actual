using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PATITAS.Models
{
    public class Trabajador 
    {
        [Key]
        public int Trabajador_Id { get; set; } 

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string DNI { get; set; }
        
        public string Correo { get; set;}
       
        public string Telefono { get; set; }
        
        public string Turno { get; set; }

        public string Tipo { get; set; }    

        public Venta Venta { get; set; }


    }
}
