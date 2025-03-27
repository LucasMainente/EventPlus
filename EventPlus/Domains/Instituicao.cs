using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; }

        [Column(TypeName ="VARCHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string? CNPJ {  get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O endereço é obrigatório")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string? NomeFantasia { get; set; }

    }
}
