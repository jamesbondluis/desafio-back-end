namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class StatusPedidoRequest
    {
        private string status;        
        public string Status
        {
            get { return status.ToUpper(); }
            set { status = value; }
        }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public int Pedido { get; set; }
    }
}
