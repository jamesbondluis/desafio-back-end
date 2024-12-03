namespace DesafioBackEnd.BLL.Models.DataBaseModels
{
    public class Pedido
    {
        public Pedido()
        {
            Itens = new List<Item>();
        }

        public int NumeroPedido { get; set; }

        public List<Item> Itens { get; set; }

        public decimal BuscarValorTotal()
        {
            return Itens.Sum(x => x.PrecoUnitario * x.Quantidade);
        }

        public int BuscarQTDItensTotal()
        {
            return Itens.Sum(x => x.Quantidade);
        }
    }
}
