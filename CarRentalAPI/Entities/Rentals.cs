namespace CarRentalAPI.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }

        public Car Car { get; set; } = null!;
    }
}
