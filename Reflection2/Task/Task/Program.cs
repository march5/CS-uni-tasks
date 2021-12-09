using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            //beer - C:\\Users\\Admin\\Desktop\\Studia\\C#\\CS-uni-tasks\\Reflection2\\Task\\BeerProcessor\\bin\\Debug\\BeerProcessor.dll
            //sandwich - C:\\Users\\Admin\\Desktop\\Studia\\C#\\CS-uni-tasks\\Reflection2\\Task\\SandwichProcessor\\bin\\Debug\\SandwichProcessor.dll

            string filePath;
            string[] name;
            int X;

            filePath = Console.ReadLine();
            X = int.Parse(Console.ReadLine());
            name = new string[X];

            for(int i = 0; i < X; i++)
            {
                name[i] = Console.ReadLine();
            }

            FileInfo f = new FileInfo(filePath);
            Assembly assembly = Assembly.LoadFrom(f.FullName);
            Type t = null;

            if (assembly.GetName().Name[0] == 'B')
            {
                 t = assembly.GetType("BeerProcessor.zleceniePiwo");
            }
            else
            {
                t = assembly.GetType("SandwichProcessor.zlecenieKanapka");
            }

            MethodInfo setName = t.GetMethod("setName", new Type[] { typeof(string) });
            MethodInfo process = t.GetMethod("Process");

            object[] tab = new object[X];

            for(int i = 0; i < X; i++)
            {
                tab[i] = Activator.CreateInstance(t);
            }

            for(int i = 0; i < X; i++)
            {
                setName.Invoke(tab[i], new object[] { name[i] });
                process.Invoke(tab[i], null);
            }

            Console.ReadKey();

        }
    }
}
