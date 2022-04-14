namespace Domain.Products
{
    public class Product
    {

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public float Price { get; }
        public float Rating { get; }
        public List<ShoppingCartsProducts> ShoppingCarts { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        internal Product(string name, string description, float price, float rating)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException("description");

            if (price <= 0)
                throw new ArgumentOutOfRangeException("price");

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Rating = rating;
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}