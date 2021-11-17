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

            IEnumerable<int> numbers = Enumerable.Range(1, N); // generate set of numbers from 1 to N

            var numSquares =    //from generated set we take numbers that pass the given requirements
                from num in numbers
                where num != 5 && num != 9 && (num % 2 != 0 || num % 7 == 0) 
                select num * num; // and multiple by themself to get their power 

            Console.WriteLine(numSquares.Sum());//Sum of every element in collection
            Console.WriteLine(numSquares.Count());//Liczba wszystkich elementów w kolekcji/liczba elementów kolekcji
            Console.WriteLine(numSquares.First());//First elem
            Console.WriteLine(numSquares.Last());//Last elem
            Console.WriteLine(numSquares.ElementAt(3));//Third elem
        }

        public static void task4_2()
        {
            int N, M;
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());

            Random rand = new Random();

            var numbers = Enumerable.Range(0, N).Select(x => // create s et of N numbers 
                Enumerable.Range(0, M).Select(y => rand.Next(100)).ToArray()) //then for each created set we create another one of M numbers
            .ToArray();                                                       //and change the numbers to random ones

            var sum = numbers.SelectMany(num => num).Sum(); //sum of all numbers from every sub-group

            Console.WriteLine(sum);

        }

        public static void task4_3()
        {
            List<string> cities = new List<string>();

            string input = Console.ReadLine();

            while (input != "X")// inputting cities until "X"
            {
                cities.Add(input);
                input = Console.ReadLine();
            }

            var citiesGrouped = from city in cities //creates set of cities grouped by their first letter
                                orderby city ascending
                                group city by city[0] into startsWith
                                orderby startsWith.Key ascending
                                select startsWith;
            
            input = Console.ReadLine();

            while(input != "END")
            {

                var citiesOnLetter = from city in citiesGrouped //takes group of given letter from citiesGrouped
                                     where city.Key == input[0]
                                     from city2 in city //and takes each city from that group
                                     select city2;


                if (citiesOnLetter.Any())   // if there was any city starting with given letter
                    foreach (var city in citiesOnLetter)
                    {
                        Console.Write(city);    // we print it
                        if (city != citiesOnLetter.Last())
                        {
                            Console.Write(", ");
                        }
                    }
                else Console.Write("PUSTE"); // if there wasn't any city starting with given letter we print "PUSTE"

                Console.WriteLine();

                input = Console.ReadLine(); // next letter or "END" to quit
            }

        }

        static void Main(string[] args)
        {
            //task4_1(); //Uncomment to run task 4_1
            //task4_2(); //Uncomment to run task 4_2
            //task4_3(); //Uncomment to run task 4_3
        }
    }
}
