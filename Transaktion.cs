using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchhaltungssoftware
{
    
    class Transaktion
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public Transaktion(string name, decimal price, DateTime date)
        {
            Name = name;
            Price = price;
            Date = date;
        }

        public override string ToString()
        {
            return  ($"Name  {Name} | Datum: {Date.ToShortDateString()} | Betrag: {Price} Euro.");
        }

    }
}
