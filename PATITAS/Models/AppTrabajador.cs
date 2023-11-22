using Microsoft.AspNetCore.Identity;

namespace PATITAS.Models
{
    public class AppTrabajador : IdentityUser
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string DNI { get; set; }

        public string Telefono { get; set; }

        public string Turno { get; set; }

        public string Tipo { get; set; }

        public bool Estado { get; set; }
    }
}
