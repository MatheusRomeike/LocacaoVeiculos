using LocacaoVeiculos.VehicleService.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculos.VehicleService.Data
{
    public class VehicleDbContext : DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
