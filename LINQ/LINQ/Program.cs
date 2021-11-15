using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
namespace LINQ
{
    class Program
    {

        public static void task4_1()
        {
            int N;
            N = int.Parse(Console.ReadLine());

            IEnumerable<int> numbers = Enumerable.Range(1, N);

            var numSquares =
                from num in numbers
                where num != 5 && num != 9 && (num % 2 != 0 || num % 7 == 0)
                select num * num;

            Console.WriteLine(numSquares.Sum());//Suma wszystkich elementów w kolekcji
            Console.WriteLine(numSquares.Count());//Liczba wszystkich elementów w kolekcji/liczba elementów kolekcji
            Console.WriteLine(numSquares.First());//Pierwszy element w kolekcji
            Console.WriteLine(numSquares.Last());//Ostatni element w kolekcji
            Console.WriteLine(numSquares.ElementAt(3));//Trzeci element kolekcji
        }

        public static void task4_2()
        {
            int N, M;
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());

            Random rand = new Random();
            Random rand2 = new Random();


            var numbers = Enumerable.Range(0, N).Select(x => 
                Enumerable.Range(0, M).Select(y => rand.Next(100)).ToArray())
            .ToArray();

            /*foreach(var num in numbers)
            {
                foreach(var num2 in num)
                {
                    Console.Write(num2 + " ");
                }
                Console.WriteLine();
            }*/

            var sum = numbers.SelectMany(num => num).Sum();

            Console.WriteLine(sum);

        }

        static void Main(string[] args)
        {
            //task4_1(); //Uncomment to run task 4_1
            //task4_2(); //Uncomment to run task 4_2
        }
    }
}
