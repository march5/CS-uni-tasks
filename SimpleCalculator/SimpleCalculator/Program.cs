using System;
using System.Collections.Generic;

namespace SimpleCalculator
{

    public interface IDiscountFromPeselComputer
    {
        bool HasDiscount(String pesel);
    }

    public class InvalidPeselException : Exception
    {
        public InvalidPeselException(string message) : base(message) { }
        public InvalidPeselException() : base() { }
        public InvalidPeselException(string message, Exception e) : base(message, e) { }

    }

    public class DiscountFromPeselComputer : IDiscountFromPeselComputer
    {
        public bool HasDiscount(string pesel)
        {
            if (pesel == null) throw new InvalidPeselException("Null input string");
            if (pesel.Length != 11) throw new InvalidPeselException("Invalid Pesel length");
            foreach(char c in pesel)
            {
                if (c < '0' || c > '9') throw new InvalidPeselException("Invalid character in pesel");
            }

            int day = Int32.Parse(pesel.Substring(4, 2));
            int month = Int32.Parse(pesel.Substring(2, 2));
            int year = Int32.Parse(pesel.Substring(0, 2));

            if(month > 80)
            {
                year += 1800;
                month -= 80;
            }
            else if(month > 60)
            {
                year += 2200;
                month -= 60;
            }
            else if(month > 40)
            {
                year += 2100;
                month -= 40;
            }
            else if(month > 20)
            {
                year += 2000;
                month -= 20;
            }
            else
            {
                year += 1900;
            }

            DateTime now = DateTime.Now;
            DateTime birthDate = new DateTime(year, month, day, now.Hour, now.Minute, now.Second);
            TimeSpan diff = now.Subtract(birthDate);

            TimeSpan yearSpanBelow = now.AddYears(18) - now;
            TimeSpan yearSpanAbove = now.AddYears(65) - now;

            Console.WriteLine(diff + " " + yearSpanBelow + " " + yearSpanAbove);

            if (diff < yearSpanBelow || diff > yearSpanAbove) return true;

            return false;
        }
    }

    /*public class DiscountFromPeselComputer : IDiscountFromPeselComputer //Cw05_Przykład.cs
    {

        public bool HasDiscount(string pesel)
        {
            try
            {
                int year = Int32.Parse(pesel.Substring(0, 2));
                int Month = Int32.Parse(pesel.Substring(2, 2));
                int day = Int32.Parse(pesel.Substring(4, 2));
                DateTime birthDate = new DateTime(DateTime.Now.Year - year > 2000 ? 2000 + year : 1900 + year, Month, day);

                if (!Math.Floor(DateTime.Now.Subtract(birthDate).TotalDays / 365.2425).IsBetween(18, 65))
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new InvalidPeselException(e.Message);
            }
        }
    }

    public static class ExtensionsNumeric
    {
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0 && Comparer<T>.Default.Compare(item, end) <= 0;
        }
    }*/


    public interface IAnagramChecker
    {
        bool isAnagram(string word1, string word2);
    }

    public class AnagramChecker : IAnagramChecker
    {
        public bool isAnagram(string word1, string word2)
        {

            if (word1 == null || word2 == null) throw new ArgumentNullException();
            else if (word1 == "" || word2 == "") throw new ArgumentException();
            else
            {
                if (word1.Length != word2.Length) return false;

                var word1Array = word1.ToLower().ToCharArray();
                var word2Array = word2.ToLower().ToCharArray();

                Array.Sort(word1Array);
                Array.Sort(word2Array);

                for (int i = 0; i < word1Array.Length; i++)
                    if (word1Array[i] != word2Array[i]) return false;
            }

            return true;
        }
    }

    public class Program
    {

        public class TextMerger
        {
            public static string Merge(string a, string b)
            {

                if (a == null || b == null) return null;
                return a + b;
            }

            public static string MergeNotNull(string a, string b)
            {
                if (a == null || b == null) throw new ArgumentNullException();
                else return a + b;
            }
        }

        public class SimpleCalculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
