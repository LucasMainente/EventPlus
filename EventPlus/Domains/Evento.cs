using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EventPlus.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? Descricao { get; set; }


        public Guid IdTipoEvento { get; set; }
        [ForeignKey("IdTipoEvento")]
        public TipoEvento? TipoEvento { get; set; }

        public Guid IdInstituicao { get; set; }
        [ForeignKey("IdInstituicao")]
        public Instituicao? Instituicao { get; set; }

        public Presenca? Presenca { get; set; }
    }
}
