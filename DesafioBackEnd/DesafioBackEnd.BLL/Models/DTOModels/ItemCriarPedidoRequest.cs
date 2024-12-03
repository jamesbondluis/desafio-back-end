namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class ItemCriarPedidoRequest
    {
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
    }
}
