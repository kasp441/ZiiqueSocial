using System.Security.Cryptography.X509Certificates;

namespace Domain
{
    public class Profile
    {
        public Guid Guid { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string profileIcon { get; set; }
        public DateTime StartedAt { get; set; }
        public string bio { get; set; }
        public virtual required string authId { get; set; }
    }
}
