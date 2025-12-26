using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq.Expressions;

namespace Buchhaltungssoftware
{
    
    static class ProfileManager
    {
        public static Profile CurrentProfile { get; private set; } = null!;

        public static void CreateProfile(string name, decimal price)
        {
            CurrentProfile = new Profile(name, price);
            SaveProfile(CurrentProfile);
        }

        public static void SaveProfile(Profile profile) 
        {
            string filePath = AppContext.BaseDirectory + profile.Name + ".prof";
            

            try
            {
                using(FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void LoadProfile(string profilePath) 
        {
           

            try
            {
                using(FileStream stream = new FileStream(profilePath, FileMode.Open))
                {
                    
                }
            }
            catch (Exception ex) 
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        

        public static bool CheckIfProfileExists(string profileName)
        {
            string fullPath = AppContext.BaseDirectory + profileName + ".prof";
            return File.Exists(fullPath);
        }
    }

}
