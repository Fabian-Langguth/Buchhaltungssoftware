using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    internal class ShowTransactionMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Gebe den Zeitraum ein");
            Console.WriteLine("--------------------");

            DateTime startDate = InputStartDate();
            DateTime endDate = InputEndDate(startDate);
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            PrintTransactionsFromto(startDate, endDate);
            Console.WriteLine("--------------------------");
            Console.WriteLine("Drücke um eine Taste um zum Hauptmenü zurückzukehren");
            Console.ReadKey();
            Menu nextMenu = new MainMenu();
        }
        private DateTime InputStartDate()
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.WriteLine("Startdatum (TT.MM.JJJJ): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiges Startdatum.");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (correctInput) { break; }
            }
            return input;
        }
        private DateTime InputEndDate(DateTime startDate)
        {
            DateTime input;

            while (true)
            {
                bool correctInput = true;
                Console.WriteLine("Enddatum (TT.MM.JJJJ): ");

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input) || input < startDate)
                {
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiges Enddatum.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (correctInput) { break; }
            }
            return input;
        }

        private void PrintTransactionsFromto(DateTime startDate, DateTime endDate)
        {
            foreach (Transaktion transaktion in ProfileManager.CurrentProfile.TransaktionList)
            {
                if(transaktion.Date >= startDate && transaktion.Date < endDate)
                {
                    if(transaktion.Price < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine(transaktion.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
