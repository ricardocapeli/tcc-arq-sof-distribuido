using Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class VeiculoContext : DbContext
    {
        public VeiculoContext(DbContextOptions<VeiculoContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
