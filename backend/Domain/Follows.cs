namespace Domain
{
    public class Follows
    {
        public int Id { get; set; }
        public Guid profile { get; set; }
        public Guid follows { get; set; }
    }
}
