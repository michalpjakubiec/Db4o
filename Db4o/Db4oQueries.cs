using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;

namespace Nbd_Db4o
{
    public class Db4oQueries
    {
        public static readonly string YapFileName = "MJ_Db4o.yap";
        public static void ListResult(IObjectSet result)
        {
            foreach (object item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void ClearDb()
        {
            File.Delete(YapFileName);
        }

        public static void DisplayStats(IObjectContainer db)
        {
            IObjectSet resultPersons = db.QueryByExample(typeof(Person));
            IObjectSet resultAddress = db.QueryByExample(typeof(Address));
            IObjectSet resultPhones = db.QueryByExample(typeof(Phone));

            var retrievedPersonsList = new List<object>();
            var retrievedAddressList = new List<object>();

            Console.WriteLine("Statystyka bazy");
            Console.WriteLine();
            Console.WriteLine($"Osób:\t {resultPersons.Count}");
            Console.WriteLine($"Adresów:\t {resultAddress.Count}");
            Console.WriteLine($"Telefonów:\t {resultPhones.Count}");
        }

        public static void CreateExampleDb(IObjectContainer db)
        {
            var person1 = new Person()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                Address = new Address(),
                //{
                //    Street = "Kolorowa 2",
                //    PostCode = "12-234",
                //    City = "Warszawa"
                //},
                Phones = new List<Phone>()
                {
                    new Phone("123456791", "Play", "mobilny"),
                    new Phone("123654789", "T-Mobile", "stajonarny")
                }
            };

            var person2 = new Person()
            {
                FirstName = "Adam",
                LastName = "Nowak",
                Address = new Address(),
                //{
                //    Street = "Kosmiczna 10",
                //    PostCode = "32-567",
                //    City = "Kraków"
                //},
                Phones = new List<Phone>()
                //{
                //    new Phone("123654378", "Play", "mobilny"),
                //    new Phone("456234556", "Orange", "służbowy")
                //}
            };

            var person3 = new Person()
            {
                FirstName = "Paweł",
                LastName = "Adamus",
                Address = new Address()
                {
                    Street = "Zielona",
                    PostCode = "14-256",
                    City = "Bielsko-Biała"
                },
                Phones = new List<Phone>()
                {
                    new Phone("435765379", "VirginMobile", "służbowy"),
                    new Phone("098769578", "Orange", "stacjonarny")
                }
            };

            db.Store(person1);
            db.Store(person2);
            db.Store(person3);
        }
    }
}
