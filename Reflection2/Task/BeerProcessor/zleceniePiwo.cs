using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BeerProcessor
{
    public class zleceniePiwo : Common.IZlecenie
    {
        string Tytul;

        public zleceniePiwo() { }

        public void setName(string name)
        {
            this.Tytul = name;
        }

        public void Process()
        {
            Console.WriteLine(this.Tytul);
            Console.WriteLine("Mieszanie słodów...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Zacieranie...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Dodawanie drożdży...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Fermentacja...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
