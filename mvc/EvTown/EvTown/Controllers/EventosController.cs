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

namespace EvTown.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventoRepository eventoRepository;
        public EventosController(IEventoRepository eventoRepository)
        {
            this.eventoRepository = eventoRepository;
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

        //// GET: Eventos/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null || _context.Evento == null)
        //    {
        //        return NotFound();
        //    }

        //    var evento = await _context.Evento
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (evento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(evento);
        //}

        //// GET: Eventos/Create
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

        public IActionResult Edit(Guid id)
        {
            var evento = eventoRepository.Get(id);

            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Endereco,Categoria,Acesso,Pagamento,DataEvento")] Evento evento)
        {
            var eventoBd = eventoRepository.Get(id);

            if (eventoBd == null)
            {
                return NotFound();
            }

            eventoRepository.Update(eventoBd);
                
            return RedirectToAction(nameof(Index));
            
        }

        //// GET: Eventos/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null || _context.Evento == null)
        //    {
        //        return NotFound();
        //    }

        //    var evento = await _context.Evento
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (evento == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(evento);
        //}

        //// POST: Eventos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    if (_context.Evento == null)
        //    {
        //        return Problem("Entity set 'DataContext.Evento'  is null.");
        //    }
        //    var evento = await _context.Evento.FindAsync(id);
        //    if (evento != null)
        //    {
        //        _context.Evento.Remove(evento);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EventoExists(Guid id)
        //{
        //  return (_context.Evento?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
