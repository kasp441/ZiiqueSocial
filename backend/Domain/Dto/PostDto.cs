namespace Domain.Dto;

public class PostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid ProfileId { get; set; }
}