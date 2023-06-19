using Domain.Products;
using Domain.Roles;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Domain.Users
{
    public class User
    {

        private static Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
           RegexOptions.CultureInvariant | RegexOptions.Singleline);

       // private static Regex passRegex = new Regex(@"(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])[a-zA-Z0-9]{8,}");

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; set; }
        public string Phone { get; }
        public Guid Id { get; set; }
        public string Adress { get; }
        public Role Role { get; }
        public string ProfileImgUrl { get; set; }

        public ShoppingCart ShoppingCart { get; set; }



        internal User(string FirstName, string LastName, string Email, string Password, string Adress, string Phone, Role Role, string ProfileImgUrl)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentNullException("FirstName is not valid!");

            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentNullException("LastName is not valid!");

            //email checking
           
            bool isValidEmail = regex.IsMatch(Email);
            if (!isValidEmail)
                throw new ArgumentNullException("Email is not valid!");

            //password validation
            //var isValidPassword = passRegex.IsMatch(Password);
            if (Password == null)
               throw new ArgumentNullException("Invalid password!");

            if (string.IsNullOrWhiteSpace(Phone) || Phone.Length != 10)
                throw new ArgumentNullException("Phone is not valid!");

            if (string.IsNullOrWhiteSpace(Adress))
                throw new ArgumentNullException("Adress is not valid!");



            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Phone = Phone;
            this.Id = Guid.NewGuid();
            this.Adress = Adress;
            this.Role = Role;
            this.ProfileImgUrl = ProfileImgUrl;
        }

        public override String ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}