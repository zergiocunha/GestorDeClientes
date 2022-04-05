
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeClientes.Models.Cliente
{
    [Table("ClienteEndereco")]
    public class ClsClienteEndereco
    {
        [Key]
        public int IdClienteEndereco { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public int CEP { get; set; }
        [Required]
        public string UF { get; set; }

    }


}
