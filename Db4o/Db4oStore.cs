using Db4objects.Db4o;
using System;
using System.Collections.Generic;

namespace Nbd_Db4o
{
    static class Db4oStore
    {
        public static void AddPerson(IObjectContainer db)
        {
            var person = new Person();

            Console.Write("Imie\t\t");
            person.FirstName = Console.ReadLine();

            Console.Write("Nazwisko\t\t");
            person.LastName = Console.ReadLine();

            person.Address = new Address();
            person.Phones = new List<Phone>();

            //AddAddress(db, person);

            //person.Phones = new List<Phone>();
            //AddPhone(db, person);

            db.Store(person);
        }

        public static void AddAddress(IObjectContainer db, Person person)
        {
            var address = new Address();

            Console.Write("Ulica\t");
            address.Street = Console.ReadLine();

            Console.Write("Kod pocztowy\t");
            address.PostCode = Console.ReadLine();

            Console.Write("Miasto\t");
            address.City = Console.ReadLine();

            address.Person = person;
            db.Store(address);
        }
        public static void AddPhone(IObjectContainer db, Person person)
        {
            var phone = new Phone();

            Console.Write("Numer\t");
            phone.Number = Console.ReadLine();

            Console.Write("Operator\t");
            phone.OperatorName = Console.ReadLine();

            Console.Write("Typ\t");
            phone.Type = Console.ReadLine();

            person.Phones.Add(phone);
        }
    }
}
