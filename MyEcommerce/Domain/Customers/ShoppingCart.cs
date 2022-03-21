using Domain.Products;

namespace Domain.Customers
{
    public class ShoppingCart : Model
    {
        public Guid Id { get { return id; } }
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            this.id = Guid.NewGuid();
            this.Products = new List<Product>();
        }
    }
}