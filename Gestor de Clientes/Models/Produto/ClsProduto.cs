using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeClientes.Models.Produto
{
    [Table("Produto")]
    public class ClsProduto
    {
        [Key]
        public int IdProduto { get; set; }
        [MaxLength(50)]
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        public string Foto { get; set; }
        public double Preco { get; set; }

    }
}
