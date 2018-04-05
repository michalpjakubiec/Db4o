using Db4objects.Db4o;
using Nbd_Db4o;
using System;
using System.Linq;

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

            //try
            {
                Person ex = new Person(firstName, lastName);
                IObjectSet result = db.QueryByExample(ex);
                Person found = (Person)result.Next();

                db.Delete(found.Address);

                foreach (var phone in found.Phones.ToList())
                {
                    found.Phones.Remove(phone);
                }

                found.Phones.Clear();
                db.Delete(found);
                db.Commit();
                Console.WriteLine();
                Console.WriteLine("Pomyślnie usunięto osobę!");
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            //}
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

                if (found.Phones == null)
                {
                    Console.WriteLine("Brak telefonów w bazie.");
                    return;
                }
                else
                {
                    Console.WriteLine("Telefony:\t");
                    foreach (var phone in found.Phones)
                    {
                        Console.WriteLine($"\t\t{phone}");
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Podaj numer telefonu do usunięcia:");
                Console.WriteLine();
                var phoneNumber = Console.ReadLine();

                int selectedPhone = found.Phones.FindIndex(x => x.Number == phoneNumber);


                //selectedPhone zwraca -1 jesli nie istnieje
                if (found.Phones[selectedPhone].Number != phoneNumber)
                {
                    Console.WriteLine("Taki numer nie istnieje. Nie można kontynuować.");
                    return;
                }

                found.Phones.RemoveAt(selectedPhone);
                db.Delete(selectedPhone);
                db.Store(found);
                db.Commit();

                Console.WriteLine();
                Console.WriteLine("Pomyślnie usunnięto telefon!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taki obiekt nie istnieje. Nie można kontynuować.");
            }
        }
    }
}
