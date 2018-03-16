using System;

namespace Nbd_Db4o
{
    static class Menu
    {
        public static void Draw()
        {
            Console.WriteLine("\t1.\tDodaj osobę");
            Console.WriteLine("\t2.\tDodaj\\modyfikuj adres");
            Console.WriteLine("\t3.\tDodaj telefon");

            Console.WriteLine("\t4.\tModyfikuj osobę");
            Console.WriteLine("\t5.\tModyfikuj adres");
            Console.WriteLine("\t6.\tModyfikuj telefon");

            Console.WriteLine("\t7.\tUsuń osobę");
            Console.WriteLine("\t8.\tUsuń adres");
            Console.WriteLine("\t9.\tUsuń telefon");

            Console.WriteLine("\tQ.\tWyświetl wszystko");
            Console.WriteLine("\tW.\tWyświetl konkretną osobę");
            Console.WriteLine("\tE.\tStatystyka");
        }

        public static void BottomLine()
        {
            Console.Write("\nNaciśnij dowolny klawisz aby przejść do menu...");
            Console.ReadKey();
            Console.Clear();
        }
}
}
