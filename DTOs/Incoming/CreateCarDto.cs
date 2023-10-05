namespace AmigoCars.DTOs.Incoming
{
    public class CreateCarDto
    {

        public string? RegistrationNo { get; set; }

        public string? Brand { get; set; }

        public int? Year { get; set; }

        public string? Model { get; set; }

        public string? FuelType { get; set; }

        public string? Transmission { get; set; }

        public int? RtoCircle { get; set; }

        public long? KmDriven { get; set; }

        public int? CarLocation { get; set; }

        public int? SellerId { get; set; }

        public string? CarImg { get; set; }
        public string? Price { get; set; }

    }
}
