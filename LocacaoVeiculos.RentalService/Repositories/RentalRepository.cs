using LocacaoVeiculos.RentalService.Data;
using LocacaoVeiculos.RentalService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.RentalService.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalDbContext _context;

        public RentalRepository(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }
    }
}
