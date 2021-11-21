using NUnit.Framework;
using SimpleCalculator;
using System.Diagnostics;
using System;

namespace SimpleCalculator.Test
{

    [TestFixture]
    public class MyUnitTest
    {
        [Test]
        public void TestRegularUseCaseWithSmallNumbers()
        {
            //Arrange:
            Program.SimpleCalculator simpleCalculator = new Program.SimpleCalculator();
            //Act:
            int result = simpleCalculator.Add(1, 2);
            //Assert:
            Assert.AreEqual(3, result);
        }
    }

    [TestFixture]
    public class TextMergerTests
    {
        [Test]
        public void TestRegularValues()
        {
            string res = Program.TextMerger.Merge("Ala ma", " kota");
            string res2 = Program.TextMerger.Merge("Ala ma kota", "");
            string res3 = Program.TextMerger.Merge("", "Ala ma kota");
            string res4 = Program.TextMerger.Merge("", "");

            Assert.AreEqual("Ala ma kota", res);
            Assert.AreEqual("Ala ma kota", res2);
            Assert.AreEqual("Ala ma kota", res3);
            Assert.AreEqual("", res4);
        }

        [Test]
        public void TestNullStrings()
        {
            string res = Program.TextMerger.Merge("Ala ma", null);
            string res2 = Program.TextMerger.Merge(null, " kota");
            string res3 = Program.TextMerger.Merge(null, null);

            Assert.AreEqual(null, res);
            Assert.AreEqual(null, res2);
            Assert.AreEqual(null, res3);
        }

        [Test]
        public void TestNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Program.TextMerger.MergeNotNull(null, "Ala"));
            Assert.Throws<ArgumentNullException>(() => Program.TextMerger.MergeNotNull("Ala", null));
            Assert.Throws<ArgumentNullException>(() => Program.TextMerger.MergeNotNull(null, null));
        }

        [TestFixture]
        public class AnagramCheckerTests
        {
            [Test]
            public void TestRegularStrings()
            {
                IAnagramChecker anagramChecker = new AnagramChecker();

                bool res = anagramChecker.isAnagram("ala", "ala");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("ala  ", "  ala");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("mars", "rams");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("pear", "reap");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("meats", "steam");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("pot", "spot");
                Assert.AreEqual(false, res);

                res = anagramChecker.isAnagram("pins", "spins");
                Assert.AreEqual(false, res);
            }

            [Test]
            public void TestNumbers()
            {
                IAnagramChecker anagramChecker = new AnagramChecker();

                bool res = anagramChecker.isAnagram("1234567890", "0987654321");
                Assert.AreEqual(true, res);
                res = anagramChecker.isAnagram("2222", "2222");
                Assert.AreEqual(true, res);
                res = anagramChecker.isAnagram("1 4 2 3", "1234   ");
                Assert.AreEqual(true, res);
            }

            [Test]
            public void TestAllChar()
            {
                IAnagramChecker anagramChecker = new AnagramChecker();

                bool res = anagramChecker.isAnagram("awd923?, ..", "., ?daw392.");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("AaaA99213", "aaaa21399");
                Assert.AreEqual(true, res);

                res = anagramChecker.isAnagram("A    AAAA", "A A A A A");
                Assert.AreEqual(true, res);
            }

            [Test]
            public void TestNullStrings()
            {
                IAnagramChecker anagramChecker = new AnagramChecker();

                Assert.Throws<ArgumentNullException>(() => anagramChecker.isAnagram(null, "oko"));

                Assert.Throws<ArgumentNullException>(() => anagramChecker.isAnagram("oko", null));

                Assert.Throws<ArgumentNullException>(() => anagramChecker.isAnagram(null, null));
            }

            [Test]
            public void TestEmptyStrings()
            {
                IAnagramChecker anagramChecker = new AnagramChecker();

                Assert.Throws<ArgumentException>(() => anagramChecker.isAnagram("", "oko"));
                Assert.Throws<ArgumentException>(() => anagramChecker.isAnagram("oko", ""));
                Assert.Throws<ArgumentException>(() => anagramChecker.isAnagram("", ""));
            }
        }
    }
}