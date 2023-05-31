using EvTown.Interface;
using EvTown.Models;
using EvTown.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EvTown.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository usuario_repository;

        public LoginController(IUsuarioRepository usuario_repository)
        {
            this.usuario_repository = usuario_repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidarLogin(Usuario usuario)
        {
            var u = usuario_repository.Get(usuario);

            if (usuario_repository.Get(usuario) == null)
            {
                return View("Error");
            };

            return RedirectToAction("Index", "AreaUsuario");
        }

    }
}
