
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Ad
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public decimal Price { get; set; } = 0;
        [Required]
        public string Location { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Status { get; set; }
        public string SellerUserName { get; set; }
        public string BuyerUserName { get; set; } = "";
    }
}