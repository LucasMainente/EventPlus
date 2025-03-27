using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventPlus.Domains;

namespace EventoPlus.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventPlus_Context _context;
        public TipoUsuarioRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            TipoUsuario usuarioBuscado = _context.TipoUsuario.Find(id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
            }
            _context.TipoUsuario.Update(usuarioBuscado);

            _context.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario usuarioBuscado = _context.TipoUsuario.Find(id)!;

                return usuarioBuscado;  
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            tipoUsuario.IdTipoUsuario = Guid.NewGuid();
            _context.TipoUsuario.Add(tipoUsuario);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {

            try
            {
                TipoUsuario usuarioBuscado = _context.TipoUsuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    _context.TipoUsuario.Remove(usuarioBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            try
            {
                return _context.TipoUsuario.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
