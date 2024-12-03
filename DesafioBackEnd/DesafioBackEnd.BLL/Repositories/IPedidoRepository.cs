using DesafioBackEnd.BLL.Models.DataBaseModels;

namespace DesafioBackEnd.BLL.Repositories
{
    public interface IPedidoRepository
    {
        public Task<int> CriarPedido(Pedido pedido);
        public Task<Pedido> BuscarPedido(int numeroPedido);
        public Task<List<Pedido>> BuscarPedidos();
        public Task<bool> AlterarPedido(Pedido pedido);
        public Task<bool> ExcluirPedido(int numeroPedido);
    }
}
