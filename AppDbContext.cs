using GolfWarehouse.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfWarehouse.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PointOfSaleTransaction> PointOfSaleTransactions { get; set; }
    }
}
