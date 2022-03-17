using MyEcommerce.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyEcommerce.Customers
{
    internal class Customer : IGuest
    {
        private string firstName;
        private string lastName;    
        private string email;
        private string password;
        private string phone;
        private int id;
        private Adress adress;

        public Customer(string firstName, string lastName, string email, string password, string phone, int id, Adress adress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.phone = phone;
            this.id = id;
            this.adress = adress;
        }

        public void SeeProducts()
        {
            throw new NotImplementedException();
        }

        public override String ToString()
        {
            return this.firstName + " " + this.lastName;
        }

    }
}
