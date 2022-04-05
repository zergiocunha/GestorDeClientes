using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeClientes.Models.Cliente
{
    [Table("Cliente")]
    public class ClsCliente
    {
        [Key]
        public int IdCliente { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Nascimento { get; set; }
        [Required]
        public int Telefone { get; set; }
        public int? Telefone2 { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Email2 { get; set; }
        [ForeignKey("IdClienteEndereco")]
        [Required]
        public string Endereco { get; set; }

    }
}
