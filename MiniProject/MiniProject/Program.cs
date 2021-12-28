using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace MiniProject
{
    class Program
    {
        public static int maxCrawlerNum = 100;
        public static int crawlersCompleted = 0;
        public static int globalCrawlersCount = 0;
        public static bool keyWordFound = false;
        public static List<int> pathLengthsFound = new List<int>();

        public class Crawler
        {
            string keyWord;
            WebClient web;
            int pathLength;
            string link;
            string pageText;

            public Crawler(int pathL, string link, string keyWord)
            {
                this.keyWord = keyWord;
                this.pathLength = pathL + 1;
                this.link = link;
                this.web = new WebClient();

                Task t = Task.Run(() => crawl());
            }
            
            string[] forbidden = { "jpg", "Plik:", "Kategoria:", "File:", "Category:", "Wikipedia:", "Simple", "<", ">", "Szablon:", "Pomoc:"
            , "wikimedia", "https", "Specjalna:", "Dyskusja:", "Help:", "Special:", "special"};

            bool checkLink(string link)
            {
                foreach(var s in forbidden)
                {
                    if (link.Contains(s)) return false;
                }
                return true;
            }

            public bool ReadPage()
            {
                Uri uriResult;
                bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if(result)
                {
                    System.IO.Stream stream = web.OpenRead(this.link);
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    {
                        this.pageText = reader.ReadToEnd();
                    }
                }
                return result;
            }

            public void crawl()
            {
                
                if (ReadPage())
                {
                    int index;
                    int endOfLink;
                    string linkFound;
                    string linkBeg = link.Substring(0, 24);

                    Console.WriteLine("Crawling " + link);

                    if (pageText.Contains(keyWord))
                    {
                        Console.WriteLine("Hitler key word found through path of length: " + pathLength);
                        keyWordFound = true;
                        pathLengthsFound.Add(pathLength);
                    }
                    else
                    {
                        while(pageText.Length > 0)
                        {
                            if(pageText.Contains("<a href="))
                            {
                                index = pageText.IndexOf("<a href=\"");
                                endOfLink = index + 8;

                                while(pageText[endOfLink] != ' ')
                                    endOfLink++;

                                linkFound = pageText.Substring(index + 9, endOfLink - (index + 10));

                                if(globalCrawlersCount < maxCrawlerNum && this.pathLength < 100 && linkFound.Contains("/wiki/") && checkLink(linkFound))
                                    {
                                        new Crawler(pathLength, linkBeg + linkFound, keyWord);
                                        globalCrawlersCount++;
                                    }
                                
                                pageText = pageText.Substring(endOfLink + 1);
                            }
                            else
                                pageText = "";

                            Thread.Yield();
                        }
                    }
                }
                crawlersCompleted++;
            }
        }

        static void Main(string[] args)
        {

            string randomInitPage = "http://en.wikipedia.org/wiki/Special:Random";
            string initLink = "https://pl.wikipedia.org/wiki/Toster";


            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine("Starting loop nr: " + i);
                keyWordFound = false;
                crawlersCompleted = 0;
                globalCrawlersCount = 0;
                new Crawler(0, randomInitPage, "Hitler");
                while (!keyWordFound && crawlersCompleted < maxCrawlerNum)
                {

                }
            }

            Console.WriteLine("Path lengths: ");
            foreach(var x in pathLengthsFound)
            {
                Console.WriteLine(x);
            }
            
        }
    }
}
