using EvTown.Models;

namespace EvTown.Interface
{
    public interface IEventoRepository
    {
        List<Evento> Get();

        Evento Get(Guid id);

        bool Create(Evento evento);

        bool Update(Evento evento);
    }
}
