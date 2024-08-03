using LocacaoVeiculos.RentalService.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculos.RentalService.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext(DbContextOptions<RentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }
    }
}
