using EvTown.Models;

namespace EvTown.IRepository
{
    public interface IUsuarioRespository
    {
       bool ValidarUsuario(Usuario usuario);

       void ResgistrarLogin(Usuario usuario);
      
    }
}
