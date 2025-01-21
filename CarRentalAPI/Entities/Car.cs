using System.Text.Json.Serialization;

namespace CarRentalAPI.Entities
{
    public class Car {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string VinNumber { get; set; } = string.Empty;

        [JsonIgnore]
        public Rental? Rental { get; set; }
    }
}
