namespace MyEcommerce.Products
{
    public class Category
    {
        private int id;
        private string name;
        private List<Product> products;

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
            products = new List<Product>();
        }


        public override string? ToString()
        {
            return this.name + " id = " + this.id;
        }

        public int Id { get { return id; } set { id = value; } }

        public List<Product> Products { get => products; set => products = value; }
    }
}
