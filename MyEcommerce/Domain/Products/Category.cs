namespace Domain.Products
{
    public class Category
    {

        public Guid Id { get;}
        public string Name { get; set; }
        public List<Product> Products { get; set; }

        public Category(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            this.Id = Guid.NewGuid();
            this.Name = name;
            Products = new List<Product>();
        }


        public override string? ToString()
        {
            return this.Name + ", id = " + this.Id;
        }
    }
}
