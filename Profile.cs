using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    [Serializable]
     class Profile
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public List<Transaktion> TransaktionList { get; set; }

        public Profile ( string name, decimal balance)
        {
            Name = name;
            Balance = balance;
            TransaktionList = new List<Transaktion> ();
        }

        public void AddTransaction(Transaktion transaktion)
        {
            TransaktionList.Add (transaktion);
            Balance += transaktion.Price;
            ProfileManager.SaveProfile(this);
        }
  
    }


}
