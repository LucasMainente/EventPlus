using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario novoUsuario);
        Usuario BuscarPorId(Guid id);
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
