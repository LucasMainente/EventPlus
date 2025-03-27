using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventPlus.Domains;

namespace EventoPlus.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventosRepository
    {
        private readonly EventPlus_Context _context;
        public ComentarioEventoRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid IdEvento)
        {

            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdEvento == IdEvento)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento novoComentario)
        {
            try
            {
                novoComentario.IdComentarioEvento = Guid.NewGuid();

                _context.ComentarioEvento.Add(novoComentario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id)!;

                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ComentarioEvento> Listar(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

 

        public List<ComentarioEvento> ListarSomenteExibe(Guid id)
        {
            try
            {
                return _context.ComentarioEvento
                    .Select(c => new ComentarioEvento
                    {
                        IdComentarioEvento = c.IdComentarioEvento,
                        Descricao = c.Descricao,
                        Exibe = c.Exibe,
                        IdUsuario = c.IdUsuario,
                        IdEvento = c.IdEvento,

                        Usuario = new Usuario
                        {
                            NomeUsuario = c.Usuario!.NomeUsuario
                        },

                        Evento = new Evento
                        {
                            NomeEvento = c.Evento!.NomeEvento,
                        }

                    }).Where(c => c.Exibe == true && c.IdEvento == id).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
