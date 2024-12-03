using DesafioBackEnd.BLL.Models.DataBaseModels;
using DesafioBackEnd.BLL.Models.DTOModels;
using DesafioBackEnd.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBackEnd.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        [Route("status")]
        public async Task<IActionResult> BuscarStatusPedido(StatusPedidoRequest pedidoRequest)
        {
            try
            {
                var result = await _pedidoService.BuscarEstadoPedido(pedidoRequest);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("pedido")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _pedidoService.BuscarPedidos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("pedido/{pedido}")]
        public async Task<IActionResult> GetById(int pedido)
        {
            try
            {
                var result = await _pedidoService.BuscarPedido(pedido);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("pedido")]
        public async Task<IActionResult> Add(List<ItemCriarPedidoRequest> itens)
        {
            try
            {
                var result = await _pedidoService.CriarPedido(itens);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("pedido")]
        public async Task<IActionResult> Update(AlterarPedidoRequest pedido)
        {
            try
            {
                var result = await _pedidoService.AlterarPedido(pedido);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("pedido/{pedido}")]
        public async Task<IActionResult> Delete(int pedido)
        {
            try
            {
                var result = await _pedidoService.ExcluirPedido(pedido);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}