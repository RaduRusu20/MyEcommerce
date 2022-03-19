namespace Domain.Products
{
    public class Product
    {

        public Guid Id { get;}
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Raiting { get; set; }

        public Product(string name, string description, float price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("description");

            if (price <= 0)
                 throw new ArgumentOutOfRangeException("price");

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public override string? ToString()
        {
            return this.Name;
        }
    }
}