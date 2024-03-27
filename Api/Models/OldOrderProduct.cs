namespace Api.Models
{
    public class OldOrderProduct
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public OldProduct Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
