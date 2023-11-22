using Microsoft.AspNetCore.Mvc;     
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PATITAS.Datos;
using PATITAS.Models;

namespace PATITAS.Controllers
{
    public class ClienteController : Controller
    {
        public readonly ApplicationDbContext _contexto;

        public ClienteController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Cliente> listaClientes = _contexto.Cliente.ToList();
            return View(listaClientes);
        }
        [HttpGet]

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cliente.Add(cliente);
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
            var cliente = _contexto.Cliente.FirstOrDefault(c => c.Cliente_Id == id);
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _contexto.Cliente.Update(cliente);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            var cliente = _contexto.Cliente.FirstOrDefault(c => c.Cliente_Id == id);
            _contexto.Cliente.Remove(cliente);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

