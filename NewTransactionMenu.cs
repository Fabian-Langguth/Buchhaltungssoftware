using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class NewTransactionMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Neue Transaktion");
            Console.WriteLine("---------------");
            string newTransactionName = InputTransactionName();
            decimal newTransactionsAmount = InputTransactionAmount();
            DateTime newTransactionDate = InputTransactionDate();

            Transaktion transaktion = new Transaktion(newTransactionName, newTransactionsAmount, newTransactionDate);
            ProfileManager.CurrentProfile.AddTransaction(transaktion);
            Console.WriteLine("Die folgende Transaktion wurde inzugefügt");

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
            Console.ReadKey();

            Menu nextMenu = new MainMenu();
        }

        private string InputTransactionName()
        {
            Console.Write("Transaktionsname: ");
            return Console.ReadLine();
        }
        private decimal InputTransactionAmount()
        {
            decimal input;
            while (true)
            {
                Console.Write("Euro-Betrag: ");
                bool correctInput = true;

                if(!decimal.TryParse(Console.ReadLine(), out input))
                {
                    correctInput = false;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiger Eurobetrag.");
                    Console.ForegroundColor = ConsoleColor.White;


                }
                if (correctInput)
                {
                    break;
                }
            }
            return input;
        }
        private DateTime InputTransactionDate()
        {
            DateTime input;

            while (true)
            {
                Console.Write("Datum (TT.MM.JJJJ): ");
                bool correcInput = true;

                if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out input))
                {
                    correcInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiges Datum.");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                if (correcInput)
                {
                    break;  
                }
            }
            return input; 
        }

            
    }
}
