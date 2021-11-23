using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {

        public class Customer
        {
            private string _name;
            protected int _age;
            public bool isPreferred;
            public Customer(string name)
            {
                if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Customer name!");
                _name = name;
            }
            public string Name
            {
                get
                {
                    return _name;
                }
            }
            public string Address { get; set; }
            public int SomeValue { get; set; }
            public int ImportantCalculation()
            {
                return 1000;
            }
            public void ImportantVoidMethod()
            {
            }
            public enum SomeEnumeration
            {
                ValueOne = 1
            , ValueTwo = 2
            }
            public class SomeNestedClass
            {
                private string _someString;
            }
        }

        static void Main(string[] args)
        {
            PropertyInfo[] fieldInfo;
            Type type = typeof(Customer);

            fieldInfo = type.GetProperties(BindingFlags.Public | BindingFlags.Instance );
            Console.WriteLine("Fields: ");
            //lista pól w klasie Pogrupowane względem dostępu
            Console.WriteLine("-- Public: ");
            //publiczne
            for(int i =0; i < fieldInfo.Length; i++)
            {
                Console.WriteLine(fieldInfo[i].DeclaringType + "; " + fieldInfo[i].Name);
            }
            Console.WriteLine("-- Non Public: ");
            //niepubliczne
            //Przykład:
            //Type: “string”; name: “_name”
            /*fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                Console.WriteLine(fieldInfo[i].FieldType.Name + "; " + fieldInfo[i].Name);
            }*/

            Console.WriteLine("Methods: ");
            //Lista metod

            Console.WriteLine("Nested types: ");
            //typy zagnieżdżone

            Console.WriteLine("Properties: ");
            //propercje

            Console.WriteLine("Members: ");
            //Członkowie

        }
    }
}
