using Db4objects.Db4o;
using Nbd_Db4o;
using System;

namespace Nbd_Db4o
{
    class Db4oDelete
    {
        public static void DeletePerson(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, którą chcesz usunąć:");
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

                db.Delete(found.Address);
                found.Phones.Clear();
                db.Delete(found.Phones);
                db.Delete(found);
                db.Commit();
                Console.WriteLine();
                Console.WriteLine("Pomyślnie usunięto osobę!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }

        public static void DeleteAddress(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, której chcesz usunąć adres:");
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

                db.Delete(found.Address);
                db.Commit();
                Console.WriteLine();
                Console.WriteLine("Pomyślnie usunięto adres!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }

        public static void DeletePhones(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, której chcesz usunąć telefony:");
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
                
                found.Phones.Clear();
                db.Delete(found.Phones);
                db.Commit();
                Console.WriteLine();
                Console.WriteLine("Pomyślnie usunięto telefony!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }
    }
}
