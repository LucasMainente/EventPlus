using EventPlus.Domains;
using Microsoft.EntityFrameworkCore;

namespace EventoPlus.Context
{
    public class EventPlus_Context : DbContext
    {
        public EventPlus_Context() { }

        public EventPlus_Context(DbContextOptions<EventPlus_Context> options) : base(options)
        { 
         }

        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE38-S28\\SQLEXPRESS; Database = EventPlus; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true; ");
            }
        }

    }

}
