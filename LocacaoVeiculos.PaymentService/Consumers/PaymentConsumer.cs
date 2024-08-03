using LocacaoVeiculos.Shared.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

public class PaymentConsumer : IConsumer<NewRentalMessage>
{
    private readonly ILogger<PaymentConsumer> _logger;

    public PaymentConsumer(ILogger<PaymentConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<NewRentalMessage> context)
    {
        var message = context.Message;
        _logger.LogInformation($"Received rental message in PaymentService: RentalId = {message.RentalId}, VehicleId = {message.VehicleId}, RentalDate = {message.StartDate} - {message.EndDate}");

        // Lógica de pagamento aqui

        return Task.CompletedTask;
    }
}
