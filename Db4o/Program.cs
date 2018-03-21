using System;
using Db4objects.Db4o;
using static Nbd_Db4o.Db4oQueries;
using static Nbd_Db4o.Db4oStore;
using static Nbd_Db4o.Db4oModify;
using static Nbd_Db4o.Db4oRetrieve;
using static Nbd_Db4o.Db4oDelete;

namespace Nbd_Db4o
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ClearDb();

            using (IObjectContainer db = Db4oEmbedded.OpenFile(Db4oQueries.YapFileName))
            {
                CreateExampleDb(db);

                while (true)
                {
                    //Menu.Draw();
                    Console.WriteLine("1)\tDodaj osobę");
                    Console.WriteLine("2)\tDodaj adres");
                    Console.WriteLine("3)\tDodaj telefon");

                    Console.WriteLine("4)\tModyfikuj osobę");
                    Console.WriteLine("5)\tModyfikuj adres");
                    Console.WriteLine("6)\tModyfikuj telefon");

                    Console.WriteLine("7)\tUsuń osobę");
                    Console.WriteLine("8)\tUsuń adres");
                    Console.WriteLine("9)\tUsuń telefon");

                    Console.WriteLine("0)\tWyświetl dane konkretnej osoby");
                    Console.WriteLine("STATS\tStatystyka");
                    Console.WriteLine();
                    Console.WriteLine("Q)\tWyjście");

                    string menuChoice = Console.ReadLine()?.ToUpper();

                    Console.Clear();
                    switch (menuChoice)
                    {
                        case "1":
                            StorePerson(db);
                            Menu.BottomLine();
                            break;
                        case "2":
                            StoreAddress(db);
                            Menu.BottomLine();
                            break;
                        case "3":
                            StorePhone(db);
                            Menu.BottomLine();
                            break;
                        case "4":
                            ModifyPerson(db);
                            Menu.BottomLine();
                            break;
                        case "5":
                            ModifyAddress(db);
                            Menu.BottomLine();
                            break;
                        case "6":
                            ModifyPhone(db);
                            Menu.BottomLine();
                            break;
                        case "7":
                            DeletePerson(db);
                            Menu.BottomLine();
                            break;
                        case "8":
                            DeleteAddress(db);
                            Menu.BottomLine();
                            break;
                        case "9":
                            DeletePhones(db);
                            Menu.BottomLine();
                            break;
                        case "0":
                            RetrievePersonByName(db);
                            Menu.BottomLine();
                            break;
                        case "STATS":
                            DisplayStats(db);
                            Menu.BottomLine();
                            break;
                        case "Q":
                            db.Close();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                

            }
        }
    }
}

