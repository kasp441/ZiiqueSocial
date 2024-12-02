namespace Domain
{
    public class Login
    {
        public int Id { get; set; }
        public string email { get; set; }
        public required string username { get; set; }
        public required byte[] password { get; set; }
    }
}