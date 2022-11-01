namespace Lego_Prestigieux.Models
{
    public class ProductInfoCart
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public string URL { get; set; }
        public int ProductId { get; set; }
        public int CartItemId { get; set; }
    }
}
