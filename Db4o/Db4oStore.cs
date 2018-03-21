using Db4objects.Db4o;
using System;
using System.Collections.Generic;

namespace Nbd_Db4o
{
    static class Db4oStore
    {
        public static void StorePerson(IObjectContainer db)
        {
            var person = new Person();

            Console.Write("Imie:\t\t");
            person.FirstName = Console.ReadLine();
            Console.Write("Nazwisko:\t");
            person.LastName = Console.ReadLine();

            db.Store(person);
            Console.WriteLine("Pomyślnie dodano osobę!");
        }

        public static void StoreAddress(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, do której chcesz dodać adres:");
            Console.WriteLine();
            Console.Write("Imię:\t\t");
            string firstName = Console.ReadLine();
            Console.Write("Nazwisko:\t");
            string lastName = Console.ReadLine();

            try
            {
                Person ex = new Person(firstName, lastName);
                IObjectSet result = db.QueryByExample(ex);
                Person found = (Person)result.Next();

                Console.WriteLine();
                Console.WriteLine("Podaj nowy adres:");
                Console.WriteLine();
                var address = new Address();

                Console.Write("Ulica:\t\t");
                address.Street = Console.ReadLine();
                Console.Write("Kod pocztowy:\t");
                address.PostCode = Console.ReadLine();
                Console.Write("Miasto:\t\t");
                address.City = Console.ReadLine();
                Console.WriteLine();

                found.AddAddress(address);
                db.Store(found);

                Console.WriteLine("Pomyślnie dodano adres!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }

        public static void StorePhone(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, do której chcesz dodać telefon:");
            Console.WriteLine();
            Console.Write("Imię\t\t");
            string firstName = Console.ReadLine();
            Console.Write("Nazwisko\t");
            string lastName = Console.ReadLine();

            //try
            {
                Person ex = new Person(firstName, lastName);
                IObjectSet result = db.QueryByExample(ex);
                Person found = (Person)result.Next();

                Console.WriteLine();
                Console.WriteLine("Podaj nowy telefon:");
                Console.WriteLine();
                var phone = new Phone();

                Console.Write("Numer\t\t");
                phone.Number = Console.ReadLine();
                Console.Write("Operator\t");
                phone.OperatorName = Console.ReadLine();
                Console.Write("Typ\t\t");
                phone.Type = Console.ReadLine();
                Console.WriteLine();

                found.AddPhone(phone);
                db.Store(found);

                Console.WriteLine("Pomyślnie dodano telefon!");
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            //}
        }
    }
}
