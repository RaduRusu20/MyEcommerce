using Domain.Products;

namespace Domain.Customers
{
    public class Customer : Model
    {
     
        public string FirstName { get; }
        public string LastName { get;  }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public Guid Id { get { return id; } private set { id = value; } }
        public string Adress{ get; }
        public ShoppingCart ShoppingCart { get; }


        public Customer(string firstName, string lastName, string email, string password, string phone, string adress)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException("email");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException("password");

            if (string.IsNullOrEmpty(phone))
                throw new ArgumentNullException("phone");

            if (string.IsNullOrEmpty(adress))
                throw new ArgumentNullException("adress");



            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Id = Guid.NewGuid();
            this.Adress = adress;
            this.ShoppingCart = new ShoppingCart();
        }

        public void AddToCart(Product product)
        {
            ShoppingCart.Products.Add(product);
        }

        public void DeleteFromCart(Product product)
        {
            ShoppingCart.Products.Remove(product);
        }

        public float Checkout()
        {
            float totalPrice = 0;

            foreach (var product in ShoppingCart.Products)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
        public void SeeCartProducts()
        {
            ShoppingCart.Products.ForEach(x => Console.WriteLine(x));
        }

        public void SortProducts()
        {
            var sortProducts = ShoppingCart.Products.OrderBy(x => x.Name);
            foreach (var product in sortProducts)
            {
                Console.WriteLine(product);
            }
        }

        public void ReverseSortProducts()
        {
            var sortProducts = ShoppingCart.Products.OrderByDescending(x => x.Name);
            foreach (var product in sortProducts)
            {
                Console.WriteLine(product);
            }
        }

        public override String ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}