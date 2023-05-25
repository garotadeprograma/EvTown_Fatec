using EvTown.Models;
using EvTown.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EvTown.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepository usuario_repository;

        public LoginController()
        {
            this.usuario_repository = new UsuarioRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        public string ValidarLogin(Usuario usuario)
        {

            if(usuario_repository.ValidarUsuario(usuario))
            {
                //return RedirectToAction("Index", "Home");
                return "sucesso";
            };

            //criar página de erro

            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return "erro";
        }

    }
}
