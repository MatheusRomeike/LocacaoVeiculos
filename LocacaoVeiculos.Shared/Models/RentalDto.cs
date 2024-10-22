namespace LocacaoVeiculos.Shared.Models
{
    public class RentalDto
    {
        public long Id { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
