using System.ComponentModel.DataAnnotations;

namespace Catalog.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double? Rating { get; set; }
        public int? StockCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
