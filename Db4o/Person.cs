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
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return string.Format($"{FirstName,-15} {LastName,-15}" +
                                 $"{Address.Street, -15} {Address.PostCode, -8} {Address.City, -5}" +
                                 $"{Phones}");
        }
    }
}
