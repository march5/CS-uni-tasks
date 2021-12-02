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

        public static void task1()
        {
            FieldInfo[] fieldInfo;
            PropertyInfo[] propertyInfos;
            Type type = typeof(Customer);

            fieldInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Fields: ");
            //lista pól w klasie Pogrupowane względem dostępu
            Console.WriteLine("-- Public: ");
            //publiczne
            foreach (var x in fieldInfo)
            {
                Console.WriteLine(x.Attributes + " " + x.Name);
            }
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                Console.WriteLine(propertyInfos[i].DeclaringType + "; " + propertyInfos[i].Name);
            }
            Console.WriteLine("\n-- Non Public: ");
            //niepubliczne
            //Przykład:
            //Type: “string”; name: “_name”
            fieldInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic );
            foreach (var x in fieldInfo)
            {
                Console.WriteLine(x.Attributes + " " + x.Name);
            }

            Console.WriteLine("\nMethods: ");
            //Lista metod
            MethodInfo[] methods = type.GetMethods();
            foreach(var x in methods)
            {
                Console.WriteLine(x.Name);
            }
            foreach(var con in type.GetConstructors())
            Console.WriteLine(con.Name);

            Console.WriteLine("\nNested types: ");
            //typy zagnieżdżone
            Type[] nested = type.GetNestedTypes();
            foreach (var nest in nested)
                Console.WriteLine(nest.Name);

            Console.WriteLine("\nProperties: ");
            //propercje

            foreach (var property in type.GetProperties())
                Console.WriteLine(property.Name);

            Console.WriteLine("\nMembers: ");
            //Członkowie

            foreach (var member in type.GetMembers())
                Console.WriteLine(member.Name);
        }

        public static void task2()
        {
            Customer customer = new Customer("Dominik");
            Type type = customer.GetType();

            type.GetProperty("Address").SetValue(customer, "Cracov");
            type.GetProperty("SomeValue").SetValue(customer, 1234);

            foreach (var prop in type.GetProperties()) Console.WriteLine(prop.GetValue(customer));
        }

        static void Main(string[] args)
        {
            task1(); //uncomment for task1
            task2(); //uncomment for task2
        }
    }
}
