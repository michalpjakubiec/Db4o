using System;
using Db4objects.Db4o;

namespace Nbd_Db4o
{
    class Db4oModify
    {
        public static void ModifyAddress(IObjectContainer db)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();

            var address = new Address();
            Console.Write("Ulica\t");
            address.Street = Console.ReadLine();
            Console.Write("Kod pocztowy\t");
            address.PostCode = Console.ReadLine();
            Console.Write("Miasto\t");
            address.City = Console.ReadLine();

            IObjectSet result = db.QueryByExample(address);
            Address found = (Address)result.Next();
            found.Person = new Person(firstName, lastName);
            db.Store(found);
            result = db.QueryByExample(address);
        }
    }
}
