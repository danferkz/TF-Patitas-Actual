using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using PATITAS.Models;
using System.Security.Claims;

namespace PATITAS.Controllers
{
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        
        public CuentaController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Registro(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            RegistroViewModel registroVM = new RegistroViewModel();
            return View(registroVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel rgViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usuario = new AppTrabajador { UserName = rgViewModel.Email, Email = rgViewModel.Email, Nombre = rgViewModel.Nombre, Direccion = rgViewModel.Direccion, DNI = rgViewModel.DNI, Telefono = rgViewModel.Telefono, Turno = rgViewModel.Turno, Tipo = rgViewModel.Tipo };
                var resultado = await _userManager.CreateAsync(usuario, rgViewModel.Password);

                if (resultado.Succeeded)
                {
                 

                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }

                ValidarErrores(resultado);
            }

            return View(rgViewModel);
        }

        //Manejador de errores
        private void ValidarErrores(IdentityResult resultado)
        {
            foreach (var error in resultado.Errors)
            {
                ModelState.AddModelError(String.Empty, error.Description);
            }
        }

        //Método mostrar fomulario de acceso
        [HttpGet]
        public IActionResult Acceso(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Acceso(AccesoViewModel accViewModel, string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(accViewModel.Email, accViewModel.Password, accViewModel.RememberMe, lockoutOnFailure: true);

                if (resultado.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    return LocalRedirect(returnurl);
                }
                if (resultado.IsLockedOut)
                {
                    return View("Bloqueado");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Acceso inválido");
                    return View(accViewModel);
                }
            }

            return View(accViewModel);
        }

        //Salir o cerrar sesión de la aplicacion (logout)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalirAplicacion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

      

   


    }
}
