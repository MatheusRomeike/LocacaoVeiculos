﻿namespace LocacaoVeiculos.Shared.Models
{
    public class NewRentalMessage
    {
        public long RentalId { get; set; }
        public int VehicleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}