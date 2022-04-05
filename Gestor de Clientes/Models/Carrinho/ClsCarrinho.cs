using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeClientes.Models.Carrinho
{
    [Table("Carrinho")]
    public class ClsCarrinho
    {
        [Key]
        public int IdCarrinho { get; set; }
        [ForeignKey("IdCliente")]
        public int Cliente { get; set; }
        public int TotalGeral { get; set; }


    }
}
