using System;

namespace MyAssembly
{
    public class ClasWithMetods
    {
        public string hello()
        {
            string s = "hello ";
            Console.WriteLine(s);
            return s;
        }

        public string TellMeYourName(string name)
        {
            string s = "It is nice to meet you "+name;
            Console.WriteLine(s);
            return s;
        }
    }
}
