using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PATITAS.Datos;
using PATITAS.Models;

namespace PATITAS.Controllers
{
    public class CitaController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public CitaController(ApplicationDbContext dbContext)
        {
            _contexto = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Cita> Cita = await _contexto.Cita.Include(x => x.Mascota).ToListAsync();
            Cita Citas = new Cita();
            ViewBag.Cita = Cita;
            return View(Citas);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            CitaMascotaTrabajadorVM citaMascota = new CitaMascotaTrabajadorVM();
            citaMascota.ListaMascota = _contexto.Mascota.Select(i => new SelectListItem
            {
                Text = i.NombreMascota,
                Value = i.Mascota_Id.ToString(),
            });
            return View(citaMascota);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cita.Add(cita);
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
            CitaMascotaTrabajadorVM citaMascota = new CitaMascotaTrabajadorVM();
            citaMascota.ListaMascota = _contexto.Mascota.Select(i => new SelectListItem
            {
                Text = i.NombreMascota,
                Value = i.Mascota_Id.ToString()
            });

            citaMascota.Cita = _contexto.Cita.FirstOrDefault(c => c.Cita_Id == id);
            if (citaMascota == null)
            {
                return NotFound();
            }
            var cita = _contexto.Cita.FirstOrDefault(c => c.Cita_Id == id);
            return View(citaMascota);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(CitaMascotaTrabajadorVM citaVM)
        {
            if (citaVM.Cita.Cita_Id == 0)
            {
                return View(citaVM.Cita);
            }
            else
            {
                _contexto.Cita.Update(citaVM.Cita);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult Borrar(int? id)
        {
            var cita = _contexto.Cita.FirstOrDefault(c => c.Cita_Id == id);
            _contexto.Cita.Remove(cita);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Diagnostico(int? id)
        {
            if (id == null)
            {
                return View();
            }

            var cita = _contexto.Cita.Include(d => d.Diagnostico).FirstOrDefault(u => u.Cita_Id == id);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }
        [HttpPost]
        public IActionResult AgregarDiagnostico(Cita cita)
        {
            if (cita.Diagnostico.Diagnostico_Id == 0)
            {

                _contexto.Diagnostico.Add(cita.Diagnostico);
                _contexto.SaveChanges();

                var citaBd = _contexto.Cita.FirstOrDefault(u => u.Cita_Id == cita.Cita_Id);
                citaBd.Diagnostico_Id = cita.Diagnostico.Diagnostico_Id;
                _contexto.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

