namespace DesafioBackEnd.BLL.Models.DTOModels
{
    public class ItemAlterarPedidoRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set; }
    }
}
