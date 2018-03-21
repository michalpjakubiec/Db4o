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
            Console.WriteLine("Not implemented yet");
            //Console.WriteLine("Podaj osobę, której chcesz zmodyfikować telefon:");
            //Console.WriteLine();
            //Console.Write("Imię:\t\t");
            //string firstName = Console.ReadLine();
            //Console.Write("Nazwisko:\t");
            //string lastName = Console.ReadLine();

            //try
            //{
            //    Person ex = new Person(firstName, lastName);
            //    IObjectSet result = db.QueryByExample(ex);
            //    Person found = (Person)result.Next();

            //    string menuChoice = Console.ReadLine()?.ToUpper();

            //    for (int i = 0; i <= found.Phones.Count(); i++)
            //    {
            //        Console.WriteLine($"{i + 1}\t{found.Phones[i]}");
            //    }

            //    var phonesCount = found.Phones.Count();

                
            //    switch (menuChoice)
            //    {

            //    }
            //    Console.WriteLine(found.Phones.Count());
            //    found.Phones[0] = new Phone();
                

                //Console.WriteLine();
                //Console.WriteLine("Podaj nowy telefon:");
                //Console.WriteLine();
                //var phone = new Phone();

            //Console.Write("Numer\t\t");
            //phone.Number = Console.ReadLine();
            //Console.Write("Operator\t");
            //phone.OperatorName = Console.ReadLine();
            //Console.Write("Typ\t\t");
            //phone.Type = Console.ReadLine();
            //Console.WriteLine();

            //found.AddPhone(phone);
            //db.Store(found);

            //Console.WriteLine("Pomyślnie dodano telefon!");

            //Console.WriteLine();
            //Console.WriteLine("Podaj nowy adres:");
            //Console.WriteLine();
            //var address = new Address();

            //Console.Write("Ulica:\t\t");
            //address.Street = Console.ReadLine();
            //Console.Write("Kod pocztowy:\t");
            //address.PostCode = Console.ReadLine();
            //Console.Write("Miasto:\t\t");
            //address.City = Console.ReadLine();
            //Console.WriteLine();

            //found.AddAddress(address);
            //db.Store(found);

        //    Console.WriteLine("Pomyślnie zmieniono adres!");
        //}
        //    catch (Exception e)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine("Taka osoba nie istnieje. Nie można kontynuować.");
        //    }
}
    }
}
