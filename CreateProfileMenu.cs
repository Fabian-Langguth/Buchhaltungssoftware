using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class CreateProfileMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Profil erstellen");
            Console.WriteLine();

            string profileName = InputName();
            decimal profilStartBalance = InputStartBalance();

            ProfileManager.CreateProfile(profileName, profilStartBalance);
           Menu NextMenu = new MainMenu();
            
        }

        private string InputName()
        {
            while (true)
            {
                string input = "";
                Console.Write("Profilname: ");
                input = Console.ReadLine();

                if (ValidateName(input))
                {
                    return input;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler: Ungültiger Name");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private bool ValidateName(string name)
        {
            if(ProfileManager.CheckIfProfileExists(name))
            {
                return false;
            }
                
            foreach(char c in name)
            {
                if (!char.IsLetterOrDigit(c))
                    return false;
            }
                return true;

            
        }
        private decimal InputStartBalance()
        {
            while (true)
            {
                Console.Write("Startkontostand: ");
                decimal input;
                string strInput = Console.ReadLine();

                if(!decimal.TryParse(strInput, out input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Fehler Ungültiger Geldbetrag");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return input;
            }
        }
    }
}
