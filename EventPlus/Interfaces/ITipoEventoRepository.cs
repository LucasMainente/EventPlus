using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoEventos);

        List<TipoEvento> Listar();

        void Deletar(Guid id);

        void Atualizar(Guid id, TipoEvento tipoEventos); 

        TipoEvento BuscarPorId(Guid id);


    }
}
