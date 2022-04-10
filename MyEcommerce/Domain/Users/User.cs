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

        private static Regex passRegex = new Regex(@"(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9])[a-zA-Z0-9]{8}");

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public string Phone { get; }
        public Guid Id { get; }
        public string Adress { get; }
        public Role Role { get; }


        internal User(string firstName, string lastName, string email, string password, string adress, string phone, Role role)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException("FirstName is not valid!");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentNullException("LastName is not valid!");

            //email checking
           
            bool isValidEmail = regex.IsMatch(email);
            if (!isValidEmail)
                throw new ArgumentNullException("Email is not valid!");

            //password validation
            var isValidPassword = passRegex.IsMatch(password);
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
            this.Role = role;
        }

        public override String ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}