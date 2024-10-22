using LocacaoVeiculos.RentalService.Models;
using LocacaoVeiculos.RentalService.Repositories;
using LocacaoVeiculos.Shared.Models;
using MassTransit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.RentalService.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public RentalService(IRentalRepository rentalRepository, IPublishEndpoint publishEndpoint)
        {
            _rentalRepository = rentalRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _rentalRepository.GetRentalsAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _rentalRepository.GetRentalByIdAsync(id);
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _rentalRepository.AddRentalAsync(rental);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            await _rentalRepository.UpdateRentalAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _rentalRepository.DeleteRentalAsync(id);
        }

        public async Task CreateRental(RentalDto rentalDto)
        {
            // Lógica para criar a locação no banco de dados

            await AddRentalAsync(new Rental()
            {
                RentalDate = rentalDto.StartDate,
                ReturnDate = rentalDto.EndDate,
                UserId = rentalDto.CustomerId,
                VehicleId = rentalDto.VehicleId,
                TotalPrice = rentalDto.TotalAmount
            });

            // Enviando mensagem para o PaymentService
            var message = new NewRentalMessage
            {
                RentalId = rentalDto.Id,
                VehicleId = rentalDto.VehicleId,
                CustomerId = rentalDto.CustomerId,
                StartDate = rentalDto.StartDate,
                EndDate = rentalDto.EndDate,
            };

            await _publishEndpoint.Publish(message);
        }
            
    }
}
