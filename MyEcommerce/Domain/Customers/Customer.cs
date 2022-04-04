using Domain.Products;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Domain.Customers
{
    public class Customer
    {


        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public Guid Id { get; }
        public string Adress { get; }
        public ShoppingCart ShoppingCart { get; }


        internal Customer(string firstName, string lastName, string email, string password, string phone, string adress)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("FirstName is not valid!");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("LastName is not valid!");

            //email checking
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(email);
            if (!isValidEmail)
                throw new ArgumentNullException("Email is not valid!");

            //password validation
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");
            var isValidPassword = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password)
                               && hasMinimum8Chars.IsMatch(password);
            if (!isValidPassword)
                throw new ArgumentNullException("Invalid password!");

            if (string.IsNullOrWhiteSpace(phone) || phone.Length != 10)
                throw new ArgumentNullException("Phone is not valid!");

            if (string.IsNullOrWhiteSpace(adress))
                throw new ArgumentNullException("Adress is not valid!");



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
            float totalPrice = 0f;

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