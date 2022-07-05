using Microsoft.EntityFrameworkCore;

namespace CasePloomes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
