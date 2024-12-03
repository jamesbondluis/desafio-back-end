using AutoMapper;
using DesafioBackEnd.BLL.Models.DTOModels;
using DesafioBackEnd.BLL.Models.Enums;
using DesafioBackEnd.BLL.Profiles;
using DesafioBackEnd.BLL.Services;
using DesafioBackEnd.DAL.Profiles;
using DesafioBackEnd.DAL.Repositories;

namespace DesafioBackEnd.xUnitTest
{
    public class StatusPedidoTest
    {
        private readonly PedidoService _pedidoService;
        private readonly PedidoRepository _pedidoRepository;
        private readonly IMapper _mapperDAL;
        private readonly IMapper _mapperBLL;

        public StatusPedidoTest()
        {
            var dbInMemory = new DbInMemory();
            var context = dbInMemory.GetContext();

            _mapperDAL = new Mapper(new MapperConfiguration(mc => mc.AddProfile(typeof(MapProfilesDAL))));
            _mapperBLL = new Mapper(new MapperConfiguration(mc => mc.AddProfile(typeof(MapProfilesBLL))));
            _pedidoRepository = new PedidoRepository(_mapperDAL, context);
            _pedidoService = new PedidoService(_pedidoRepository, _mapperBLL);
        }

        [Fact]
        public async void RetornarErroAoBuscarStatus()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "stringDiferenteDeAprovadoOuReprovado",
                ItensAprovados = 10,
                Pedido = 1,
                ValorAprovado = 10
            };

            await Assert.ThrowsAsync<Exception>(async () => await _pedidoService.BuscarEstadoPedido(pedidoRequest));
        }

        [Fact]
        public async void RetornarStatusReprovado()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "reprovado",
                ItensAprovados = 10,
                Pedido = 1,
                ValorAprovado = 10
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.REPROVADO.ToString(), retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovado()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 3,
                Pedido = 1,
                ValorAprovado = 20
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.APROVADO.ToString(), retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoValorAMaior()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 3,
                Pedido = 1,
                ValorAprovado = 30
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString(), retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoValorAMenor()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 3,
                Pedido = 1,
                ValorAprovado = 10
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.APROVADO_VALOR_A_MENOR.ToString(), retorno.Status);
        }        

        [Fact]
        public async void RetornarStatusAprovadoQtdAMaior()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 4,
                Pedido = 1,
                ValorAprovado = 20
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.APROVADO_QTD_A_MAIOR.ToString(), retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoQtdAMenor()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 2,
                Pedido = 1,
                ValorAprovado = 20
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.APROVADO_QTD_A_MENOR.ToString(), retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoValorAMenorQtdAMenor()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 1,
                Pedido = 1,
                ValorAprovado = 10
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            var retornoEsperado = string.Concat(StatusEnum.APROVADO_VALOR_A_MENOR.ToString(), ", ", StatusEnum.APROVADO_QTD_A_MENOR.ToString());

            Assert.Equal(retornoEsperado, retorno.Status);
        }        

        [Fact]
        public async void RetornarStatusAprovadoValorAMaiorQtdAMaior()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 4,
                Pedido = 1,
                ValorAprovado = 25
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            var retornoEsperado = string.Concat(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString(), ", ", StatusEnum.APROVADO_QTD_A_MAIOR.ToString());

            Assert.Equal(retornoEsperado, retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoValorAMenorQtdAMaior()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 4,
                Pedido = 1,
                ValorAprovado = 15
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            var retornoEsperado = string.Concat(StatusEnum.APROVADO_VALOR_A_MENOR.ToString(), ", ", StatusEnum.APROVADO_QTD_A_MAIOR.ToString());

            Assert.Equal(retornoEsperado, retorno.Status);
        }

        [Fact]
        public async void RetornarStatusAprovadoValorAMaiorQtdAMenor()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 2,
                Pedido = 1,
                ValorAprovado = 25
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            var retornoEsperado = string.Concat(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString(), ", ", StatusEnum.APROVADO_QTD_A_MENOR.ToString());

            Assert.Equal(retornoEsperado, retorno.Status);
        }

        [Fact]
        public async void RetornarStatusCodigoPedidoInvalido()
        {
            StatusPedidoRequest pedidoRequest = new StatusPedidoRequest
            {
                Status = "aprovado",
                ItensAprovados = 3,
                Pedido = 10,
                ValorAprovado = 20
            };

            var retorno = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

            Assert.Equal(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString(), retorno.Status);
        }
    }
}
