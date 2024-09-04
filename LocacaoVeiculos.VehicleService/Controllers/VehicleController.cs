using LocacaoVeiculos.VehicleService.Models;
using LocacaoVeiculos.VehicleService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.VehicleService.Controllers
{
    /// <summary>
    /// Controller for managing vehicle-related operations.
    /// </summary>
    [ApiController]
    [Route("/")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("PIMBAS")]
        public string GetPimbas()
        {
            return "PIMBAS";
        }

        /// <summary>
        /// Retrieves a list of all vehicles.
        /// </summary>
        /// <returns>A list of vehicles.</returns>
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _vehicleService.GetVehiclesAsync();
        }

        /// <summary>
        /// Retrieves a specific vehicle by its ID.
        /// </summary>
        /// <param name="id">The ID of the vehicle to retrieve.</param>
        /// <returns>The requested vehicle if found; otherwise, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle data to create.</param>
        /// <returns>The created vehicle.</returns>
        [HttpPost]
        public async Task<ActionResult> AddVehicle(Vehicle vehicle)
        {
            await _vehicleService.AddVehicleAsync(vehicle);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="id">The ID of the vehicle to update.</param>
        /// <param name="vehicle">The updated vehicle data.</param>
        /// <returns>No content if successful; otherwise, NotFound.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            await _vehicleService.UpdateVehicleAsync(vehicle);
            return NoContent();
        }

        /// <summary>
        /// Deletes a vehicle.
        /// </summary>
        /// <param name="id">The ID of the vehicle to delete.</param>
        /// <returns>No content if successful; otherwise, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicle(int id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return NoContent();
        }
    }
}
