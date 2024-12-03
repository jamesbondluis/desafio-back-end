using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.DAL.Data
{
    public partial class SQLiteContext : AbstractDbContext
    {
        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options) { }
    }
}
