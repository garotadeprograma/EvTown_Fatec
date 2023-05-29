using Microsoft.AspNetCore.Mvc;

namespace EvTown.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarUsuario()
        {
            return View();
        }
    }
}
