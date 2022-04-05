using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeClientes.Models.Carrinho
{
    [Table("CarrinhoItens")]
    public class ClsCarrinhoItens
    {
        [Key]
        public int IdItens { get; set; }
        [ForeignKey("IdProduto")]
        public int Produto { get; set; }
        public int Quantidade { get; set; }
        public int SubTotal { get; set; }

    }
}
