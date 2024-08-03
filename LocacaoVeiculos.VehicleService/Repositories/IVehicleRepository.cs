using LocacaoVeiculos.VehicleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.VehicleService.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}
