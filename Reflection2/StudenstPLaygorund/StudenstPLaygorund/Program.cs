using System;
using System.IO;
using System.Reflection;

namespace StudenstPLaygorund
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            FileInfo f = new FileInfo("C:\\Users\\micha\\source\\repos\\StudenstPLaygorund\\MyAssembly\\bin\\Debug\\net5.0\\MyAssembly.dll"); //plik z assembly
            Assembly assembly = Assembly.LoadFrom(f.FullName); // Wczytywanie assembly. 

            //Nastepnie musimy pobrac typ klasu jaki chemy wiciągnąc z assemlby. 
            Type t = assembly.GetType("MyAssembly.ClasWithMetods");
            
            MethodInfo method = t.GetMethod("hello"); //pobieranie adresu delagaty do metody hello
            MethodInfo method2 = t.GetMethod("TellMeYourName", new Type[] {typeof(string) }); //pobieranie adresu delagaty do metody TellMeYourName
            object o = Activator.CreateInstance(t);
            method.Invoke(o,null); //wywoływanie hello
            method2.Invoke(o, new object[] { "Michał" }); //wywoływanie TellMeYourName

            Console.ReadLine();
        }
    }
}
