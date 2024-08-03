using LocacaoVeiculos.PaymentService.Models;
using LocacaoVeiculos.PaymentService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.PaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _paymentRepository.GetPaymentsAsync();
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _paymentRepository.GetPaymentByIdAsync(id);
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _paymentRepository.AddPaymentAsync(payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _paymentRepository.UpdatePaymentAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeletePaymentAsync(id);
        }
    }
}
