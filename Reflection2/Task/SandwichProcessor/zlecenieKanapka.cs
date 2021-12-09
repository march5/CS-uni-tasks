using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichProcessor
{
    public class zlecenieKanapka : Common.IZlecenie
    {
        string Tytul;

        public zlecenieKanapka() { }

        public void setName(string name)
        {
            this.Tytul = name;
        }

        public void Process()
        {
            Console.WriteLine(this.Tytul);
            Console.WriteLine("Smarowanie kromki masłem...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Wyciąganie salami z lodówki...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Układanie plasterków salami na kromce chleba...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Kanapka gotowa...");
            System.Threading.Thread.Sleep(1000);
        }
    }
}
