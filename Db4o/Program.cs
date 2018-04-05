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

                //do
                //{
                //    Console.Clear();
                //    Console.WriteLine("Pick an option . . .");

                //    for (c = 0; c < menuItems.Length; c++)
                //    {
                //        if (curItem == c)
                //        {
                //            Console.Write(">>");
                //            Console.WriteLine(menuItems[c]);
                //        }
                //        else
                //        {
                //            Console.WriteLine(menuItems[c]);
                //        }
                //    }
                //    key = Console.ReadKey(true);

                //    if (key.Key.ToString() == "DownArrow")
                //    {
                //        curItem++;
                //        if (curItem > menuItems.Length - 1) curItem = 0;
                //    }
                //    else if (key.Key.ToString() == "UpArrow")
                //    {
                //        curItem--;
                //        if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                //    }
                //} while (key.KeyChar != 13);
                //////////////////////////////////////////////////

                string[] menuItems = { "Dodaj\\modyfikuj\\usuń osobę",
                                       "Dodaj\\modyfikuj\\usuń adres",
                                       "Dodaj\\modyfikuj\\usuń telefon",
                                       "Wyświetl dane konkretnej osoby",
                                       "Wyświetl wszystkie osoby w bazie",
                                       "Statystyka"
                                     };

                int curItem = 0, c;
                ConsoleKeyInfo key;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Wybierz opcję . . .");
                    int choice;

                    for (c = 0; c < 6; c++)
                    {
                        if (curItem == c)
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(menuItems[c].PadRight(Console.WindowWidth - 1));
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine(menuItems[c].PadRight(Console.WindowWidth - 1));
                        }
                    }
                    choice = curItem;
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        curItem++;
                        if (curItem > menuItems.Length - 1) curItem = 0;
                    }
                    else if (key.Key == ConsoleKey.UpArrow)
                    {
                        curItem--;
                        if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                    }

                    Console.Clear();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        switch (choice)
                        {
                            case 0:
                                StorePerson(db);
                                Menu.BottomLine();
                                break;
                            case 2:
                                StoreAddress(db);
                                Menu.BottomLine();
                                break;
                            case 3:
                                StorePhone(db);
                                Menu.BottomLine();
                                break;
                            case 4:
                                ModifyPerson(db);
                                Menu.BottomLine();
                                break;
                            case 5:
                                ModifyAddress(db);
                                Menu.BottomLine();
                                break;
                            case 6:
                                ModifyPhone(db);
                                Menu.BottomLine();
                                break;
                            case 7:
                                DeletePerson(db);
                                Menu.BottomLine();
                                break;
                            case 8:
                                DeleteAddress(db);
                                Menu.BottomLine();
                                break;
                            case 9:
                                DeletePhones(db);
                                Menu.BottomLine();
                                break;
                            case 10:
                                RetrievePersonByName(db);
                                Menu.BottomLine();
                                break;
                            case 11:
                                DisplayStats(db);
                                Menu.BottomLine();
                                break;
                            case 12:
                                db.Close();
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }
                    }

                } while (key.KeyChar != 13);


            }
        }
    }
}

