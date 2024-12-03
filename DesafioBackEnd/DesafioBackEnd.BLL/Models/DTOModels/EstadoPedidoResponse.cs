namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class EstadoPedidoResponse
    {
        public int Pedido { get; set; }
        public string Status { get; set; }

        public EstadoPedidoResponse(int pedido, string status) {
            Pedido = pedido;
            Status = status;
        }
    }
}
