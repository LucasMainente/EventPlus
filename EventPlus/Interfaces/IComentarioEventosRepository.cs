using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;


namespace EventoPlus.Interfaces
{
    public interface IComentarioEventosRepository
    {
        void Cadastrar(ComentarioEvento novoComentario);

        void Deletar(Guid id);
        List<ComentarioEvento> Listar(Guid id);

        ComentarioEvento BuscarPorIdUsuario(Guid idUsuario,Guid IdEvento);

    }

}
