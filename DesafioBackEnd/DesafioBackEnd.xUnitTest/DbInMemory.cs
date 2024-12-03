using DesafioBackEnd.DAL.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.xUnitTest
{
    public class DbInMemory
    {
        private SQLiteContext _context;

        public DbInMemory()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<SQLiteContext>()
                .UseSqlite(connection)
                .EnableSensitiveDataLogging()
                .Options;

            _context = new SQLiteContext(options);

            CriarDadosParaTeste();
        }

        public SQLiteContext GetContext() => _context;

        private void CriarDadosParaTeste()
        {
            if (_context.Database.EnsureCreated())
            {
                var pedido = new DAL.Models.Pedido();

                pedido.Itens.Add(new DAL.Models.Item
                {
                    Descricao = "Item A",
                    PrecoUnitario = 10,
                    Quantidade = 1
                });

                pedido.Itens.Add(new DAL.Models.Item
                {
                    Descricao = "Item B",
                    PrecoUnitario = 5,
                    Quantidade = 2
                });

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
            }
        }
    }
}
