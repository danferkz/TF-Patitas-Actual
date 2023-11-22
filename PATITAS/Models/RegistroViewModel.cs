
using System.ComponentModel.DataAnnotations;

namespace PATITAS.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe estar entre al menos {2} caracteres de longitud", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es obligatoria")]
        [Compare("Password", ErrorMessage = "La contraseña y confirmación de contraseña no coinciden")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        
        public string DNI { get; set; }
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El turno es obligatorio")]
        public string Turno { get; set; }
        public string Tipo { get; set; }
        public string Direccion { get; set; }

        public bool Estado { get; set; }


    }
}
