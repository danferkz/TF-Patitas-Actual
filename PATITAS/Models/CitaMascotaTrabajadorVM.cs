using Microsoft.AspNetCore.Mvc.Rendering;

namespace PATITAS.Models
{
    public class CitaMascotaTrabajadorVM
    {
        public Cita Cita { get; set; }

        public IEnumerable<SelectListItem> ListaMascota { get; set; }


    }
}
