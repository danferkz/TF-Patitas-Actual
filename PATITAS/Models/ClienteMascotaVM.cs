using Microsoft.AspNetCore.Mvc.Rendering;

namespace PATITAS.Models
{
    public class ClienteMascotaVM
    {
        public Mascota Mascota { get; set; }

        public IEnumerable<SelectListItem> ListaClientes { get; set; }
       
    }
}
