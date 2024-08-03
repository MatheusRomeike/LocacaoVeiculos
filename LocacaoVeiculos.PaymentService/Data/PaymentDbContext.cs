using LocacaoVeiculos.PaymentService.Models;
using Microsoft.EntityFrameworkCore;

namespace LocacaoVeiculos.PaymentService.Data
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
