using System;
using System.Linq;
using Db4objects.Db4o;
using Microsoft.Win32.SafeHandles;

namespace Nbd_Db4o
{
    class Db4oModify
    {
        public static void ModifyPerson(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, której chcesz zmodyfikować dane:");
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
                Console.WriteLine("Podaj nowe dane:");
                Console.WriteLine();

                Console.Write("Imię:\t\t");
                found.FirstName = Console.ReadLine();
                Console.Write("Nazwisko:\t\t");
                found.LastName = Console.ReadLine();
                Console.WriteLine();

                db.Store(found);
                db.Commit();
                Console.WriteLine("Pomyślnie zmieniono dane osoby!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }
        public static void ModifyAddress(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, której chcesz zmodyfikować adres:");
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
                db.Commit();

                Console.WriteLine("Pomyślnie zmieniono adres!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
            }
        }

        public static void ModifyPhone(IObjectContainer db)
        {
            Console.WriteLine("Podaj osobę, której chcesz zmodyfikować telefon:");
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
                    Console.WriteLine();
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
                Console.WriteLine("Podaj numer telefonu do zmiany:");
                Console.WriteLine();
                var phoneNumber = Console.ReadLine();

                int selectedPhone = found.Phones.FindIndex(x => x.Number == phoneNumber);

                if (found.Phones[selectedPhone].Number != phoneNumber)
                {
                    Console.WriteLine("Taki numer nie istnieje. Nie można kontynuować.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("Podaj nowy telefon:");
                Console.WriteLine();

                Console.Write("Numer\t\t");
                found.Phones[selectedPhone].Number = Console.ReadLine();
                Console.Write("Operator\t");
                found.Phones[selectedPhone].Type = Console.ReadLine();
                Console.Write("Typ\t\t");
                found.Phones[selectedPhone].OperatorName = Console.ReadLine();

                db.Store(found);

                Console.WriteLine("Pomyślnie zmieniono telefon!");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Taki obiekt nie istnieje. Nie można kontynuować.");
            }
        }
    }
}
