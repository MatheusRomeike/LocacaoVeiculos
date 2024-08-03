using LocacaoVeiculos.PaymentService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.PaymentService.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(Payment payment);
        Task DeletePaymentAsync(int id);
    }
}
