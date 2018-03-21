namespace Nbd_Db4o
{
    public class Address
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public Person Person { get; set; }

        public Address(string street, string postCode, string city, Person person)
        {
            Street = street;
            PostCode = postCode;
            City = city;
            Person = person;
        }

        public Address()
        {
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", Street, PostCode, City);
        }
    }
}
