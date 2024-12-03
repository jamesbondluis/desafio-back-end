using AutoMapper;
using DesafioBackEnd.BLL.Models.DataBaseModels;
using DesafioBackEnd.BLL.Repositories;
using DesafioBackEnd.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.DAL.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly IMapper _mapper;
        private AbstractDbContext _dbContext;

        public PedidoRepository(IMapper mapper, AbstractDbContext context)
        {
            _mapper = mapper;
            _dbContext = context;
        }

        public async Task<BLL.Models.DataBaseModels.Pedido> BuscarPedido(int numeroPedido)
        {
            try
            {
                var pedidoDataBase = await _dbContext.Pedidos.Include(p => p.Itens).SingleOrDefaultAsync(p => p.NumeroPedido == numeroPedido);

                var pedido = _mapper.Map<BLL.Models.DataBaseModels.Pedido>(pedidoDataBase);

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o pedido na base de dados. " + ex.Message);
            }
        }

        public async Task<int> CriarPedido(Pedido pedido)
        {
            try
            {
                var pedidoDataBase = _mapper.Map<Models.Pedido>(pedido);
                await _dbContext.Pedidos.AddAsync(pedidoDataBase);
                await _dbContext.SaveChangesAsync();
                return pedidoDataBase.NumeroPedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao criar o pedido na base de dados. " + ex.Message);
            }
        }

        public async Task<bool> AlterarPedido(Pedido pedido)
        {
            try
            {
                var local = _dbContext.Set<Models.Pedido>().Local.FirstOrDefault(entry => entry.NumeroPedido.Equals(pedido.NumeroPedido));

                if (local != null)
                {
                    _dbContext.Entry(local).State = EntityState.Detached;
                }

                var pedidoDataBase = _mapper.Map<Models.Pedido>(pedido);

                _dbContext.Pedidos.Update(pedidoDataBase);

                //_dbContext.Entry(pedidoDataBase).State = EntityState.Modified;

                _dbContext.SaveChanges();


                //_dbContext.Pedidos.Update(pedidoDataBase);
                //await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> ExcluirPedido(int numeroPedido)
        {
            try
            {
                var pedido = await _dbContext.Pedidos.SingleOrDefaultAsync(p => p.NumeroPedido == numeroPedido);

                if (pedido != null)
                {
                    _dbContext.Pedidos.Remove(pedido);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Pedido>> BuscarPedidos()
        {
            try
            {
                var pedidosDataBase = await _dbContext.Pedidos.Include(p => p.Itens).ToListAsync();
                var pedidos = _mapper.Map<List<Pedido>>(pedidosDataBase);
                return pedidos;
            }
            catch
            {
                throw;
            }
        }
    }
}
