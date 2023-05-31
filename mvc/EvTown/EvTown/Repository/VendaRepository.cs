using EvTown.Data;
using EvTown.Interface;
using EvTown.Models;

namespace EvTown.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;

        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public Venda Get(int id)
        {
            return _context.Venda.Where(v => v.Id == id).FirstOrDefault(); 
        }

        public List<Venda> Get()
        {
            return _context.Venda.ToList();
        }

        public bool Create(Venda usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return true;
        }

    }
}
