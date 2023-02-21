namespace Lab.Models
{
    public class UserTransportChoice : BaseEntity
    {
        public int UserId { get; set; }
        public int TransportId { get; set; }
        public User User { get; set; }
        public Transport Transport { get; set; }
    }
}
