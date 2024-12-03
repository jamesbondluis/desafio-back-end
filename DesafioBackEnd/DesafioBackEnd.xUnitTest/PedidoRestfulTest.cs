using AutoMapper;
using DesafioBackEnd.BLL.Models.DTOModels;
using DesafioBackEnd.BLL.Profiles;
using DesafioBackEnd.BLL.Services;
using DesafioBackEnd.DAL.Profiles;
using DesafioBackEnd.DAL.Repositories;

namespace DesafioBackEnd.xUnitTest
{
    public class PedidoRestfulTest
    {
        private readonly PedidoService _pedidoService;
        private readonly PedidoRepository _pedidoRepository;
        private readonly IMapper _mapperDAL;
        private readonly IMapper _mapperBLL;

        public PedidoRestfulTest()
        {
            var dbInMemory = new DbInMemory();
            var context = dbInMemory.GetContext();

            _mapperDAL = new Mapper(new MapperConfiguration(mc => mc.AddProfile(typeof(MapProfilesDAL))));
            _mapperBLL = new Mapper(new MapperConfiguration(mc => mc.AddProfile(typeof(MapProfilesBLL))));
            _pedidoRepository = new PedidoRepository(_mapperDAL, context);
            _pedidoService = new PedidoService(_pedidoRepository, _mapperBLL);
        }

        [Fact]
        public async void BuscarPedidosComSucesso()
        {
            var pedidos = await _pedidoService.BuscarPedidos();

            Assert.NotNull(pedidos);
        }

        [Fact]
        public async void BuscarPedidoPorNumeroSemResultado()
        {
            int numeroPedido = 5;

            var pedido = await _pedidoService.BuscarPedido(numeroPedido);

            Assert.Null(pedido);
        }

        [Fact]
        public async void BuscarPedidoPorNumeroComResultado()
        {
            int numeroPedido = 1;

            var pedido = await _pedidoService.BuscarPedido(numeroPedido);

            Assert.NotNull(pedido);
        }

        [Fact]
        public async void CriarPedidoComSucesso()
        {
            List<ItemCriarPedidoRequest> itens = new List<ItemCriarPedidoRequest>();
            itens.Add(new ItemCriarPedidoRequest
            {
                Descricao = "A",
                PrecoUnitario = 10,
                Qtd = 2
            });

            var retorno = await _pedidoService.CriarPedido(itens);

            Assert.True(retorno > 0);
        }

        [Fact]
        public async void AlterarPedidoAdicionandoItem()
        {
            string descricao = "Item C";
            AlterarPedidoRequest pedido = new AlterarPedidoRequest();
            pedido.Pedido = 1;
            pedido.Itens.Add(new ItemAlterarPedidoRequest
            {
                Descricao = descricao,
                PrecoUnitario = 10,
                Qtd = 3
            });
            await _pedidoService.AlterarPedido(pedido);

            var pedidoRetorno = await _pedidoService.BuscarPedido(pedido.Pedido);

            Assert.Equal(descricao, pedidoRetorno.Itens.OrderBy(i => i.Id).Last().Descricao);
        }

        [Fact]
        public async void AlterarPedidoAlterandoItem()
        {
            string descricao = "Item A alterado";
            AlterarPedidoRequest pedido = new AlterarPedidoRequest();
            pedido.Pedido = 1;
            pedido.Itens.Add(new ItemAlterarPedidoRequest
            {
                Id = 1,
                Descricao = descricao,
                PrecoUnitario = 15,
                Qtd = 5
            });
            await _pedidoService.AlterarPedido(pedido);

            var pedidoRetorno = await _pedidoService.BuscarPedido(pedido.Pedido);

            Assert.Equal(descricao, pedidoRetorno.Itens.SingleOrDefault(i => i.Id == 1).Descricao);
        }

        [Fact]
        public async void ExcluirPedidoComSucesso()
        {
            int pedido = 1;
            var retorno = await _pedidoService.ExcluirPedido(pedido);
            Assert.True(retorno);
        }

        [Fact]
        public async void ExcluirPedidoComErro()
        {
            int pedido = 0;
            var retorno = await _pedidoService.ExcluirPedido(pedido);
            Assert.False(retorno);
        }
    }
}