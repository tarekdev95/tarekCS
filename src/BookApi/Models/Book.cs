namespace BookApi.Models;

public record Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
}
