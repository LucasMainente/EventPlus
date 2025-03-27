using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);

        List<TipoUsuario> Listar();
        
        void Atualizar(Guid id, TipoUsuario tipoUsuario);

        void Deletar(Guid id);

        TipoUsuario BuscarPorId(Guid id);
    }
}
