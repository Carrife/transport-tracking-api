namespace Lab.Models
{
    public class Trip : BaseEntity
    {
        public int UserId { get; set; }
        public int TransportId { get; set; }
        public float Price { get; set; }
        public User User { get; set; }
        public Transport Transport { get; set; }
    }
}
