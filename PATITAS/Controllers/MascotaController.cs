using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PATITAS.Datos;
using PATITAS.Models;

namespace PATITAS.Controllers
{
    public class MascotaController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public MascotaController(ApplicationDbContext dbContext)
        {
            _contexto = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Mascota> Mascota = await _contexto.Mascota.Include(x=>x.Cliente).ToListAsync();
            Mascota Mascotas = new Mascota();
            ViewBag.Mascota = Mascota;
            return View(Mascotas);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            ClienteMascotaVM mascotaCliente = new ClienteMascotaVM();
            mascotaCliente.ListaClientes = _contexto.Cliente.Select(i => new SelectListItem
            {
                Text = i.NombreApellido,
                Value = i.Cliente_Id.ToString(),
            });
            return View(mascotaCliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                _contexto.Mascota.Add(mascota);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return View();
            }
            ClienteMascotaVM mascotaCliente = new ClienteMascotaVM();
            mascotaCliente.ListaClientes = _contexto.Cliente.Select(i => new SelectListItem
            {
                Text = i.NombreApellido,
                Value = i.Cliente_Id.ToString()
            });

            mascotaCliente.Mascota = _contexto.Mascota.FirstOrDefault(c => c.Mascota_Id == id);
            if (mascotaCliente == null)
            {
                return NotFound();
            }
            var mascota = _contexto.Mascota.FirstOrDefault(c => c.Mascota_Id == id);
            return View(mascotaCliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(ClienteMascotaVM mascotaVM)
        {
            if (mascotaVM.Mascota.Mascota_Id == 0)
            {
                return View(mascotaVM.Mascota);
            }
            else
            {
                _contexto.Mascota.Update(mascotaVM.Mascota);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Borrar(int? id)
        {
            var mascota = _contexto.Mascota.FirstOrDefault(c => c.Mascota_Id == id);
            _contexto.Mascota.Remove(mascota);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Descripcion(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var mascota = _contexto.Mascota.Include(d => d.Descripcion).FirstOrDefault(u => u.Mascota_Id == id);
            if (mascota == null)
            {
                return NotFound();
            }
            return View(mascota);
        }
        [HttpPost]
        public IActionResult AgregarDescripcion(Mascota mascota)
        {
            if (mascota.Descripcion.Descripcion_Id == 0)
            {

                _contexto.Descripcion.Add(mascota.Descripcion);
                _contexto.SaveChanges();

                var mascotaBd = _contexto.Mascota.FirstOrDefault(u => u.Mascota_Id == mascota.Mascota_Id);
                mascotaBd.Descripcion_Id = mascota.Descripcion.Descripcion_Id;
                _contexto.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }



    }
}
