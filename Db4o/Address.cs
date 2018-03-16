namespace Nbd_Db4o
{
    public class Address
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public Person Person { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", City, Street, PostCode);
        }
    }
}
