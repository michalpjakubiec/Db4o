using System;
using Db4objects.Db4o;
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

        public static void RetrievePersonByName(IObjectContainer db)
        {
            Console.WriteLine("Wyświetl dane konkretnej osoby");
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

                if (found.Address == null)
                    Console.WriteLine("Brak adresów w bazie.");
                else
                {
                    Console.Write("Adres:\t\t");
                    Console.WriteLine(found.Address);
                }

                if (found.Phones == null)
                    Console.WriteLine("Brak telefonów w bazie.");
                else
                {
                    Console.WriteLine("Telefony:\t");
                    foreach (var phone in found.Phones)
                    {
                        Console.WriteLine($"\t\t{phone}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }
    }
}

