using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioBackEnd.DAL.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Itens = new List<Item>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroPedido { get; set; }

        public List<Item> Itens { get; set; }
    }
}
