using EvTown.Interface;
using EvTown.Models;
using EvTown.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EvTown.Controllers
{   
    public class CadastroController : Controller
    {
        private readonly PessoaRepository pessoa_repository;
        private readonly IUsuarioRepository usuario_repository;

        public CadastroController()
        {
            pessoa_repository = new PessoaRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarPessoa(Pessoa pessoa)
        {
            var existente = pessoa_repository.Get(pessoa.CPF);

            if (existente != null) { return View("Error"); }

            if(!pessoa_repository.Add(pessoa))
                return View("Error");

            //if (!usuario_repository.Add(new Usuario { Email = pessoa.Email, Senha = pessoa.Senha }))
            //    return View("Error");

            return View("Index", "Home");
        }
    }
}
