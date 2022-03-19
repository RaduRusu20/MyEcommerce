namespace Domain.Customers
{
    public class Adress
    {

        public string City{ get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public int ZipCode { get; set; }

        public Adress(string city, string country, string street, int streetNumber, int zipCode)
        {
            this.City = city;
            this.Country = country;
            this.Street = street;   
            this.StreetNumber = streetNumber;   
            this.ZipCode = zipCode; 
        }

       
    }
}
