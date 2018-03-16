using System;
using Db4objects.Db4o;
using static Nbd_Db4o.Db4oQueries;
using static Nbd_Db4o.Db4oStore;
using static Nbd_Db4o.Db4oModify;
using static Nbd_Db4o.Db4oRetrieve;

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
                    Menu.Draw();

                    string menuChoice = Console.ReadLine()?.ToUpper();

                    Console.Clear();
                    switch (menuChoice)
                    {
                        case "1":
                            AddPerson(db);
                            Menu.BottomLine();
                            break;
                        case "2":
                            AddAddress(db);
                            Menu.BottomLine();
                            break;
                        case "3":
                            AddPhone(db);
                            Menu.BottomLine();
                            break;
                        case "4":
                            ModifyAddress(db);
                            Menu.BottomLine();
                            break;
                        case "Q":
                            RetrieveAll(db);
                            Menu.BottomLine();
                            break;
                        case "W":
                            RetrievePersonByName(db);
                            Menu.BottomLine();
                            break;
                        case "E":
                            DisplayStats(db);
                            Menu.BottomLine();
                            break;
                        case "Z":
                            db.Close();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }

                //AddPerson(db);
                //}
                //StoreFirstPilot(db);
                //StoreSecondPilot(db);
                //RetrieveAllPilots(db);
                //RetrievePilotByExactPoints(db);
                //UpdatePilot(db);
                //DeleteFirstPilotByName(db);
                //DeleteSecondPilotByName(db);

            }
        }
    }
}

//public static void UpdatePerson(IObjectContainer db, Person person)
//{
//    IObjectSet result = db.QueryByExample(person);
//    Person found = (Person)result.Next();
//    found.AddPoints(11);
//    db.Store(found);
//    Console.WriteLine("Added 11 points for {0}", found);
//    RetrieveAllPilots(db);
//}

//public static void RetrieveAllPilotQBE(IObjectContainer db)
//{
//    Pilot proto = new Pilot(null, 0);
//    IObjectSet result = db.QueryByExample(proto);
//    ListResult(result);
//}     

//public static void RetrievePilotByName(IObjectContainer db)
//{
//    Pilot proto = new Pilot("Michael Schumacher", 0);
//    IObjectSet result = db.QueryByExample(proto);
//    ListResult(result);
//}
//public static void RetrievePilotByExactPoints(IObjectContainer db)
//{
//    Pilot proto = new Pilot(null, 100);
//    IObjectSet result = db.QueryByExample(proto);
//    ListResult(result);
//}
//public static void DeleteFirstPilotByName(IObjectContainer db)
//{
//    IObjectSet result = db.QueryByExample(new Pilot("Michael Schumacher", 0));
//    Pilot found = (Pilot)result.Next();
//    db.Delete(found);
//    Console.WriteLine("Deleted {0}", found);
//    RetrieveAllPilots(db);
//}
//public static void DeleteSecondPilotByName(IObjectContainer db)
//{
//    IObjectSet result = db.QueryByExample(new Pilot("Rubens Barrichello", 0));
//    Pilot found = (Pilot)result.Next();
//    db.Delete(found);
//    Console.WriteLine("Deleted {0}", found);
//    RetrieveAllPilots(db);
//}

