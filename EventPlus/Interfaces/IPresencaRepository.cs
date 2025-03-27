using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Interfaces
{
    public interface IPresencaRepository
    {
        List<Presenca> Listar();

        Presenca BuscarPorId(Guid id);
        void Atualizar(Guid id, Presenca presenca);
        List<Presenca> ListarMinhas (Guid id);
        void Deletar(Guid id);
        void Inscrever(Presenca novaPresenca);
    }
}
