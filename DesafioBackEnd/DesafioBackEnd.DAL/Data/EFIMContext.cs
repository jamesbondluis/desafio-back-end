using Microsoft.EntityFrameworkCore;

namespace DesafioBackEnd.DAL.Data
{
    public class EFIMContext(DbContextOptions<EFIMContext> options) : AbstractDbContext(options) { }
}
