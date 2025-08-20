namespace UserRegistrationAndGameLibrary.Application.Dtos;

public class CreateGameDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
}