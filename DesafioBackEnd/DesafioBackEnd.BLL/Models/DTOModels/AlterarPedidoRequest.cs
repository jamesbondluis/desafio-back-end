namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class AlterarPedidoRequest
    {
        public AlterarPedidoRequest()
        {
            Itens = new List<ItemAlterarPedidoRequest>();
        }

        public int Pedido { get; set; }

        public List<ItemAlterarPedidoRequest> Itens { get; set; }

        public decimal BuscarValorTotal()
        {
            return Itens.Sum(x => x.PrecoUnitario);
        }
    }
}
