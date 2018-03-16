using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using static Nbd_Db4o.Db4oQueries;

namespace Nbd_Db4o
{
    class Db4oRetrieve
    {
        public static void RetrieveAll(IObjectContainer db)
        {
            IObjectSet result = db.QueryByExample(typeof(Person));
            ListResult(result);
        }
        public static void RetrieveAllAlt(IObjectContainer db)
        {
            IObjectSet resultPersons = db.QueryByExample(typeof(Person));
            IObjectSet resultAddress = db.QueryByExample(typeof(Address));

            var retrievedPersonsList = new List<object>();
            var retrievedAddressList = new List<object>();

            foreach (var person in resultPersons)
            {
                retrievedPersonsList.Add(person);
            }

            foreach (var address in resultAddress)
            {
                retrievedAddressList.Add(address);
            }

            foreach (var a in retrievedPersonsList.Zip(retrievedAddressList, (t, w) => new { t, w }))
            {
                Console.WriteLine(a.t + " " + a.w);
            }
        }

        public static void RetrievePersonByName(IObjectContainer db)
        {
            Console.WriteLine("Wyświetl dane konkretnej osoby");
            Console.WriteLine();
            Console.Write("Imię:\t\t");
            string firstName = Console.ReadLine();
            Console.Write("Nazwisko:\t");
            string lastName = Console.ReadLine();

            Person proto = new Person(firstName, lastName);
            IObjectSet result = db.QueryByExample(proto);

            Console.WriteLine();

            if (result.Count > 0)
            {
                foreach (object item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("Brak wyników dla zapytania.");
        }
    }

}

