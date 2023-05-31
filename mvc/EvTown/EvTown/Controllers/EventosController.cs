using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvTown.Data;
using EvTown.Models;
using EvTown.Repository;
using EvTown.Interface;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace EvTown.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoRepository eventoRepository;
        private readonly IVendaRepository vendaRepository;
        public EventosController(IEventoRepository eventoRepository, IVendaRepository vendaRepository)
        {
            this.eventoRepository = eventoRepository;
            this.vendaRepository = vendaRepository;
        }

        // GET: Eventos
        public IActionResult Index()
        {
            var eventos = eventoRepository.Get();
            
            if(eventos?.Count > 0) 
                return View(eventos); 
            else
                return View("Create");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Nome,Endereco,Categoria,Acesso,Pagamento,DataEvento")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.Id = Guid.NewGuid();
                eventoRepository.Create(evento);
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }


        public IActionResult Vendas()
        {
            var vendas = vendaRepository.Get();

            if(vendas?.Count > 0)
                return View(vendas);
            else
                return View("Error");
        }

        public IActionResult Insight()
        {
            return View();
        }
    }
}
