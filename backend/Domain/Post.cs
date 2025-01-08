namespace Domain;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Visibility Visibility { get; set; }
    public Guid ProfileId { get; set; }
}

public enum Visibility
{
    Public,
    Followers,
    Private
}   