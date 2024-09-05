using LocacaoVeiculos.Shared.Models;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]

public class RentalController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public RentalController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpGet("PIMBAS")]
    public string GetPimbas()
    {
        return "PIMBAS";
    }

    [HttpPost]
    public async Task<IActionResult> CreateRental([FromBody] RentalDto rentalDto)
    {
        // Lógica para criar a locação no banco de dados

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

        return Ok();
    }
}
