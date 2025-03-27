using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus.Domains
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; }

        [Column(TypeName ="VARCHAR(50)")]
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string? TituloTipoEvento { get; set; }
    }
}
