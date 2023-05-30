using EvTown.Data;
using EvTown.Interface;
using EvTown.Models;

namespace EvTown.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DataContext _context;

        public EventoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Evento> Get()
        {
            return _context.Evento.ToList();
        }

        public Evento Get(Guid id)
        {
            return _context.Evento.Find(id);
        }

        public bool Create(Evento evento)
        {
            _context.Add(evento);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Evento evento)
        {
            _context.Update(evento);
            _context.SaveChangesAsync();
            return true;
        }
    }
}
