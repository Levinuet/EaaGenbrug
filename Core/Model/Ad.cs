namespace Core.Model
{
    public class AdItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; } = 0;

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

    }
}