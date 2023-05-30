using EvTown.Data;
using EvTown.Interface;
using EvTown.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace EvTown.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        
        public Usuario Get(Usuario usuario)
        {
            return _context.Usuario.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).FirstOrDefault();
        }

        public bool Create(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return true;
        }

    }
}
