using System.Collections.Generic;

namespace Nbd_Db4o
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Phone> Phones { get; set; }

        public Person() { }
        public Person(string firstName, string lastName, Address address, List<Phone> phones)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phones = phones;
        }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddAddress(Address address)
        {
            Address = address;
        }

        public void AddPhone(Phone phone)
        {
            if (Phones != null) Phones.Add(phone);
            else
                Phones = new List<Phone> { phone };
        }

        public override string ToString()
        {
            return string.Format($"{FirstName} {LastName}");
        }
    }
}
