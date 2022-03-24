using Domain.Products;

namespace Domain.Customers
{
    public class ShoppingCart
    {
        public Guid Id { get; }
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            this.Id = Guid.NewGuid();
            this.Products = new List<Product>();
        }
    }
}