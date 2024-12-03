using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class BuscarPedidoItemResponse
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
    }
}
