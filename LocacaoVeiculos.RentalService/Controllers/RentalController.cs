using LocacaoVeiculos.Shared.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Controller for managing rental-related operations.
/// </summary>
[ApiController]
[Route("/")]
public class RentalController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    /// <summary>
    /// Constructor for RentalController.
    /// </summary>
    /// <param name="publishEndpoint">The publish endpoint.</param>
    public RentalController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Get a test string.
    /// </summary>
    /// <returns>A test string.</returns>
    [HttpGet("PIMBAS")]
    public string GetPimbas()
    {
        return "PIMBAS";
    }

    /// <summary>
    /// Create a new rental.
    /// </summary>
    /// <param name="rentalDto">The rental data.</param>
    /// <returns>No content.</returns>
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
