

namespace EFDersi.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int ProductDetailId { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public List<SaleHistory> SaleHistories { get; set; }
    }
}
