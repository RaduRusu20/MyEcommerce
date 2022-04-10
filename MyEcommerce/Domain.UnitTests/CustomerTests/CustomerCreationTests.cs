using Domain.Roles;
using Domain.Users;
using Moq;
using System;
using Xunit;

namespace Domain.UnitTests
{
    public class CustomerCreationTests
    {
        //tests for firstName
        [Fact]
        public void NullFirstName()
        {
           Action action = () => new User(null, It.IsAny<string>(), "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
           var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EmptyFirstName()
        {
            Action action = () => new User("", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void WhiteSpacesFirstName()
        {
            Action action = () => new User("            ", "Rusu", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        //tests for lastName
        [Fact]
        public void NullLastName()
        {
            Action action = () => new User("Radu", null, "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void EmptyLastName()
        {
            Action action = () => new User("Radu", "", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void WhiteSpacesLastName()
        {
            Action action = () => new User("Radu", "       ", "rusu.radu12@yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        //tests for email
        [Fact]
        public void InvalidEmail1()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact(DisplayName = "name")]
        public void InvalidEmail2()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12.yahoo.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidEmail3()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12.com", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidEmail4()
        {
            Action action = () => new User("Radu", "Radu", "@gmail.de", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidEmail5()
        {
            Action action = () => new User("Radu", "Radu", "", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidEmail6()
        {
            Action action = () => new User("Radu", "Radu", "         ", "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidEmail7()
        {
            Action action = () => new User("Radu", "Radu", null, "Password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        //tests for password
        [Fact]
        public void InvalidPassword1()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "password123", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPassword2()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Passwordaaaa", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPassword3()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "pass1234wordaaaa", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPassword4()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPassword5()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "            ", "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPassword6()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", null, "0752190344", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        //tests for phone number
        [Fact]
        public void InvalidPhoneNumber1()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "075219034", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPhoneNumber2()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPhoneNumber3()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "        ", "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidPhoneNumber4()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", null, "adresa", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        //tests for adress
        [Fact]
        public void InvalidAdress1()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "0752190344", "", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidAdress2()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "0752190344", "        ", Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidAdress3()
        {
            Action action = () => new User("Radu", "Radu", "rusu.radu12@yahoo.com", "Alexandru123", "0752190344", null, Role.Customer);
            var exception = Assert.Throws<ArgumentNullException>(action);
        }
    }
}