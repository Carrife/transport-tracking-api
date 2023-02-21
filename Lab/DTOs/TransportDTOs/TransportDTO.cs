namespace Lab.DTOs
{
    public class TransportDTO : BaseDTO
    {
        public int KindId { get; set; }
        public string Number { get; set; }
        public string Route { get; set; }
        public int PriceId { get; set; }
    }
}
