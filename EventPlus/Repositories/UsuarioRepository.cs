using System.Runtime.CompilerServices;
using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventoPlus.Utils;
using EventPlus.Domains;

namespace EventoPlus.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventPlus_Context _context;

        public UsuarioRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;

            }

            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.TipoUsuario!.IdTipoUsuario,
                            TituloTipoUsuario = u.TipoUsuario!.TituloTipoUsuario
                        }

                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;

                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {
               novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);
                _context.Usuario.Add(novoUsuario);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
