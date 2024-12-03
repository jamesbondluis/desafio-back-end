using DesafioBackEnd.BLL.Models.DataBaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class BuscarPedidoResponse
    {
        public BuscarPedidoResponse()
        {            
            Itens = new List<BuscarPedidoItemResponse>();
        }

        public int Pedido { get; set; }

        public List<BuscarPedidoItemResponse> Itens { get; set; }
    }
}
