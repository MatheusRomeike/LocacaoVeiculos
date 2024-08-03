namespace LocacaoVeiculos.VehicleService.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public decimal PricePerDay { get; set; }
    }
}
