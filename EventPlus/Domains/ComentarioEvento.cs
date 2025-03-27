using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus.Domains
{
    [Table("ComentarioEvento")]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        public bool Exibe { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        public Guid IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }

    }
}
