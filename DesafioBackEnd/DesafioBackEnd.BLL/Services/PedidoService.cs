using AutoMapper;
using DesafioBackEnd.BLL.Models.DataBaseModels;
using DesafioBackEnd.BLL.Models.DTOModels;
using DesafioBackEnd.BLL.Models.Enums;
using DesafioBackEnd.BLL.Repositories;

namespace DesafioBackEnd.BLL.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<int> CriarPedido(List<ItemCriarPedidoRequest> itens)
        {
            Pedido pedido = new();
            pedido.Itens.AddRange(_mapper.Map<List<Item>>(itens));
            return await _pedidoRepository.CriarPedido(pedido);
        }

        public async Task<bool> AlterarPedido(AlterarPedidoRequest pedidoRequest)
        {
            Pedido pedido = new();
            pedido.NumeroPedido = pedidoRequest.Pedido;
            pedido.Itens.AddRange(_mapper.Map<List<Item>>(pedidoRequest.Itens));
            return await _pedidoRepository.AlterarPedido(pedido);
        }

        public async Task<bool> ExcluirPedido(int numeroPedido)
        {
            return await _pedidoRepository.ExcluirPedido(numeroPedido);
        }

        public async Task<List<BuscarPedidoResponse>?> BuscarPedidos()
        {
            List<Pedido> pedidosDataBase = await _pedidoRepository.BuscarPedidos();
            List<BuscarPedidoResponse> pedidos = _mapper.Map<List<BuscarPedidoResponse>>(pedidosDataBase);
            return pedidos.Count > 0 ? pedidos : null;
        }

        public async Task<BuscarPedidoResponse> BuscarPedido(int numeroPedido)
        {
            Pedido pedidoDataBase = await _pedidoRepository.BuscarPedido(numeroPedido);
            BuscarPedidoResponse pedido = _mapper.Map<BuscarPedidoResponse>(pedidoDataBase);
            return pedido;
        }

        public async Task<EstadoPedidoResponse> BuscarEstadoPedido(StatusPedidoRequest pedidoRequest)
        {
            Pedido pedido = await _pedidoRepository.BuscarPedido(pedidoRequest.Pedido);
            string status = await BuscarStatusPedido(pedido, pedidoRequest);
            return new EstadoPedidoResponse(pedidoRequest.Pedido, status);
        }

        public async Task<string> BuscarStatusPedido(Pedido pedido, StatusPedidoRequest pedidoRequest)
        {
            List<string> listaStatus = new List<string>();

            if (pedidoRequest.Status != StatusEnum.APROVADO.ToString() && pedidoRequest.Status != StatusEnum.REPROVADO.ToString())
            {
                throw new Exception("O status deve ser APROVADO ou REPROVADO.");
            }
            if (pedido == null)
            {
                listaStatus.Add(StatusEnum.CODIGO_PEDIDO_INVALIDO.ToString());
            }
            else if (pedidoRequest.Status == StatusEnum.REPROVADO.ToString())
            {
                listaStatus.Add(StatusEnum.REPROVADO.ToString());
            }
            else
            {
                decimal valorTotal = pedido.BuscarValorTotal();
                int qtdtensTotal = pedido.BuscarQTDItensTotal();

                if (pedidoRequest.ItensAprovados == qtdtensTotal && pedidoRequest.ValorAprovado == valorTotal)
                {
                    listaStatus.Add(StatusEnum.APROVADO.ToString());
                }
                if (pedidoRequest.ValorAprovado < valorTotal)
                {
                    listaStatus.Add(StatusEnum.APROVADO_VALOR_A_MENOR.ToString());
                }
                if (pedidoRequest.ValorAprovado > valorTotal)
                {
                    listaStatus.Add(StatusEnum.APROVADO_VALOR_A_MAIOR.ToString());
                }
                if (pedidoRequest.ItensAprovados < qtdtensTotal)
                {
                    listaStatus.Add(StatusEnum.APROVADO_QTD_A_MENOR.ToString());
                }
                if (pedidoRequest.ItensAprovados > qtdtensTotal)
                {
                    listaStatus.Add(StatusEnum.APROVADO_QTD_A_MAIOR.ToString());
                }
            }

            return string.Join(", ", listaStatus);
        }
    }
}
