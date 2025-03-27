using EventoPlus.Context;
using EventoPlus.Interfaces;
using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly EventPlus_Context _context;
        public PresencaRepository(EventPlus_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencaBuscado = _context.Presenca.Find(id)!;
                if (presencaBuscado != null)
                {
                    presencaBuscado.Situacao = presenca.Situacao;
                }
                int v = _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            IdEvento = p.IdEvento!,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresenca == id)!;
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
                Presenca presencaBuscada = _context.Presenca.Find(id)!;
                if (presencaBuscada != null)
                {
                    _context.Presenca.Remove(presencaBuscada);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca novaPresenca)
        {
             try
            {
                _context.Presenca.Add(novaPresenca);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                return _context.Presenca
                    .Select(p => new Presenca
                    {
                        IdPresenca = p.IdPresenca,
                        Situacao = p.Situacao,

                        Evento = new Evento
                        {
                            IdEvento = p.IdEvento,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicao
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Presenca> ListarMinhas(Guid id)
        {
            return _context.Presenca
                  .Select(p => new Presenca
                  {
                      IdPresenca = p.IdPresenca,
                      Situacao = p.Situacao,
                      IdUsuario = p.IdUsuario,
                      IdEvento = p.IdEvento,

                      Evento = new Evento
                      {
                          IdEvento = p.IdEvento,
                          DataEvento = p.Evento!.DataEvento,
                          NomeEvento = p.Evento!.NomeEvento,
                          Descricao = p.Evento!.Descricao,

                          Instituicao = new Instituicao
                          {
                              IdInstituicao = p.Evento!.IdInstituicao,
                          }
                      }
                  })
                  .Where(p => p.IdUsuario == id)
                  .ToList();
        }
    }
}
