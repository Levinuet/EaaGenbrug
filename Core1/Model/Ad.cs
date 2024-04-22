namespace Core.Model;

public class Ad
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string ImageUrl { get; set; }  // URL til billedet
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }  // Kan være "Aktiv", "Reserveret", "Inaktiv"
}
