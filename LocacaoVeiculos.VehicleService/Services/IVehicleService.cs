using LocacaoVeiculos.VehicleService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.VehicleService.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}
