namespace Lab.DTOs
{
    public class TripDTO : BaseDTO
    {
        public int UserId { get; set; }
        public int TransportId { get; set; }
        public float Price { get; set; }
    }
}
