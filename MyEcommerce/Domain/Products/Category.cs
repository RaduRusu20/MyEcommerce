namespace Domain.Products
{
    public class Category
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        internal Category(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            this.Id = Guid.NewGuid();
            this.Name = name;
            Products = new List<Product>();
        }

        public static Category CreateCategory(string name)
        {
            return new Category(name);
        }


        public override string? ToString()
        {
            return this.Name + ", id = " + this.Id;
        }
    }
}
