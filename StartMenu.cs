using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    class StartMenu : Menu
    {
        public override void DisplayMenu()
        {
            Console.WriteLine("Willkommen zur Buchhaltungs-Software!");
            Console.WriteLine();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1] Neues Profil erstellen");
            Console.WriteLine("[2] Profil laden");
            Console.WriteLine();
            InputOption();

        }
        private void InputOption()
        {
            string input;
            Menu NextMenu;

            while (true)
            {
                Console.Write("Eingabe: ");
                input = Console.ReadLine();

                bool correctInput = true;

                switch (input)
                {
                    case "1":
                        {
                            NextMenu = new CreateProfileMenu();
                            break;
                        }

                   case "2":
                        {
                            NextMenu = new LoadProfileMenu();
                            break;
                        }

                    default:
                        {
                            correctInput = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ungültige Eingabe");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                }
                if (correctInput == true)
                {
                    break;
                }
            }
        }

    }
}
