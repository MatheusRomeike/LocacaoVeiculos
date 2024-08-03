using LocacaoVeiculos.RentalService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.RentalService.Repositories
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }
}
