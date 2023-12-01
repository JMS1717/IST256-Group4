using FinalProject.DAL.Models;

namespace FinalProject.Web.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }

        // Additional properties specific to the view or for presentation purposes
        // For example, formatted price, additional data for display, etc.
        public string FormattedPrice => $"${Price:F2}"; // Example: Formats price with two decimal places

        // You can add other properties or methods as needed for the view
    }
}
