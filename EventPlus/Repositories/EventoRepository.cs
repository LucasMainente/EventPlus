using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventPlus_Context _context;
        public EventoRepository(EventPlus_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _context.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            }
            _context.Evento.Update(eventoBuscado);

            _context.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        TipoEvento = new TipoEvento
                        {
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        Instituicao = new Instituicao
                        {
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.IdEvento == id)!;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Cadastrar(Evento novoEvento)
        {
            try
            {
                // Verifica se a data do evento é maior que a data atual
                if (novoEvento.DataEvento < DateTime.Now)
                {
                    throw new ArgumentException("A data do evento deve ser maior ou igual a data atual.");
                }

                novoEvento.IdEvento = Guid.NewGuid();

                _context.Evento.Add(novoEvento);

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
                Evento eventoBuscado = _context.Evento.Find(id)!;

                if (eventoBuscado != null)
                {
                    _context.Evento.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> Listar()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ListarPorId(Guid id)
        {
            try
            {
                return _context.Evento
                    .Include(e => e.Presenca)
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        },
                        Presenca = new Presenca
                        {
                            IdUsuario = e.Presenca!.IdUsuario,
                            Situacao = e.Presenca!.Situacao
                        }
                    })
                    .Where(e => e.Presenca!.Situacao == true && e.Presenca.IdUsuario == id)
                    .ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Evento> ProximosEventos()
        {
            try
            {
                return _context.Evento
                    .Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        NomeEvento = e.NomeEvento,
                        Descricao = e.Descricao,
                        DataEvento = e.DataEvento,
                        IdTipoEvento = e.IdTipoEvento,
                        TipoEvento = new TipoEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            TituloTipoEvento = e.TipoEvento!.TituloTipoEvento
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }

                    })
                    .Where(e => e.DataEvento >= DateTime.Now)
                    .ToList();
            }
            catch (Exception)
            {
                    
                throw;
            }
        }
    }
}
