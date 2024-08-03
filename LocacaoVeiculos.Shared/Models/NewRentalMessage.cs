namespace LocacaoVeiculos.Shared.Models
{
    public class NewRentalMessage
    {
        public long RentalId { get; set; }
        public string VehicleId { get; set; }
        public string CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}