using System;

namespace SimpleCalculator
{
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
