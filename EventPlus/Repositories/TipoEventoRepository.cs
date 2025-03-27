using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventPlus.Domains;

namespace EventoPlus.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventPlus_Context _context;

        public TipoEventoRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, EventPlus.Domains.TipoEvento tipoEventos)
        {
            TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.TituloTipoEvento = tipoEventos.TituloTipoEvento;
            }
            _context.TipoEvento.Update(eventoBuscado);
            
            _context.SaveChanges();
        }

        public EventPlus.Domains.TipoEvento BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _context.TipoEvento.Find(id)!;
                
                if (tipoEventoBuscado != null)
                {
                    return tipoEventoBuscado;
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(EventPlus.Domains.TipoEvento tipoEventos)
        {
            try
            {
                tipoEventos.IdTipoEvento = Guid.NewGuid();

                _context.TipoEvento.Add(tipoEventos);

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
                TipoEvento eventoBuscado = _context.TipoEvento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.TipoEvento.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<TipoEvento> Listar()
        {
            try
            {
                return _context.TipoEvento
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
