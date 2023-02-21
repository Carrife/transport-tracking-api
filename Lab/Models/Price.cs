namespace Lab.Models
{
    public class Price : BaseEntity
    {
        public int KindId { get; set; }
        public float TripPrice { get; set; }
        public SuperDictionary Kind { get; set; }
    }
}
