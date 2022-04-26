namespace WebApi.DTOs
{
    public class ShoppingCartsProductsDto
    {
        public int Quantity { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Guid ProductId { get; set; }
    }
}
