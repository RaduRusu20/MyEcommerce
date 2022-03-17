using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEcommerce.Customers
{
    internal class Adress
    {
        private string city;
        private string country;
        private string street;
        private int streetNumber;
        private int zipCode;

        public Adress(string city, string country, string street, int streetNumber, int zipCode)
        {
            this.city = city;
            this.country = country;
            this.street = street;   
            this.streetNumber = streetNumber;   
            this.zipCode = zipCode; 
        }

       
    }
}
