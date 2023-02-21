namespace Lab.DTOs
{
    public class TripGetDTO : BaseDTO
    {
        public int UserId { get; set; }
        public string User { get; set; }
        public string Transport { get; set; }
        public float Price { get; set; }
    }
}
