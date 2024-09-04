using LocacaoVeiculos.PaymentService.Models;
using LocacaoVeiculos.PaymentService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocacaoVeiculos.PaymentService.Controllers
{
    /// <summary>
    /// Controller for managing payment-related operations.
    /// </summary>
    [ApiController]
    [Route("/")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        /// <summary>
        /// Constructor for PaymentController.
        /// </summary>
        /// <param name="paymentService">The payment service.</param>
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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
        /// Get all payments.
        /// </summary>
        /// <returns>A list of payments.</returns>
        [HttpGet]
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await _paymentService.GetPaymentsAsync();
        }

        /// <summary>
        /// Get a payment by ID.
        /// </summary>
        /// <param name="id">The ID of the payment.</param>
        /// <returns>The payment with the specified ID.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return payment;
        }

        /// <summary>
        /// Add a new payment.
        /// </summary>
        /// <param name="payment">The payment to add.</param>
        /// <returns>The created payment.</returns>
        [HttpPost]
        public async Task<ActionResult> AddPayment(Payment payment)
        {
            await _paymentService.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
        }

        /// <summary>
        /// Update a payment by ID.
        /// </summary>
        /// <param name="id">The ID of the payment to update.</param>
        /// <param name="payment">The updated payment.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment(int id, Payment payment)
        {
            if (id != payment.Id)
            {
                return BadRequest();
            }

            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        /// <summary>
        /// Delete a payment by ID.
        /// </summary>
        /// <param name="id">The ID of the payment to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
