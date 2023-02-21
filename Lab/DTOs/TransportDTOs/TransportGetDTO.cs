namespace Lab.DTOs
{
    public class TransportGetDTO : BaseDTO
    {
        public int KindId { get; set; }
        public string Number { get; set; }
        public string Route { get; set; }
        public float Price { get; set; }
    }
}
