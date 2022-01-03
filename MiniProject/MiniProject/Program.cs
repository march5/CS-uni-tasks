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
        public static int maxCrawlerNum = 200;//crawlers amount limit
        public static int crawlersCompleted = 0;
        public static int globalCrawlersCount = 0;
        public static bool keyWordFound = false;
        public static List<int> pathLengthsFound = new List<int>();//list to store path lengs found to keyword

        public class Crawler
        {
            string keyWord;
            WebClient web;
            int pathLength;
            string link;
            string pageText;

            public Crawler(int pathL, string link, string keyWord)//new Crawler is being created with given link, path length already checked and keyword
            {
                this.keyWord = keyWord;
                this.pathLength = pathL + 1;
                this.link = link;
                this.web = new WebClient();

                Task t = Task.Run(() => crawl());
            }
            
            string[] forbidden = { "jpg", "Plik:", "Kategoria:", "File:", "Category:", "Wikipedia:", "Simple", "<", ">", "Szablon:", "Pomoc:"
            , "wikimedia", "https", "Specjalna:", "Dyskusja:", "Help:", "Special:", "special", "Portal:", "Talk:", "Template:"};
            //excluded words from links, to avoid checking links we dont want to

            bool checkLink(string link)//check wherher the link contains any of the forbidden words
            {
                foreach(var s in forbidden)
                {
                    if (link.Contains(s)) return false;//if it does it's not valid to crawl
                }
                return true;
            }

            public bool ReadPage()//read page text into a string
            {
                Uri uriResult;
                bool result = Uri.TryCreate(link, UriKind.Absolute, out uriResult)//first we try to open the link to check if its valid
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if(result)//if it is we create a stream and read all of page content to pageText
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

                if (ReadPage() && keyWordFound == false)//if the page was read properly
                {
                    int index;
                    int endOfLink;
                    string linkFound;
                    string linkBeg = link.Substring(0, 24);

                    Console.WriteLine("Crawling " + link + " at depth: " + pathLength);

                    if (pageText.Contains(keyWord))//we check whether the page contains the wanted keyword
                    {
                        Console.WriteLine(keyWord + " key word found through path of length: " + pathLength + " in " + link);
                        keyWordFound = true;
                        pathLengthsFound.Add(pathLength);//we store the path length found in list to display later
                    }
                    else//if there wasnt a keyword found we go through the page looking for links
                    {
                        while(pageText.Length > 0 && keyWordFound == false)
                        {
                            if(pageText.Contains("<a href="))
                            {
                                index = pageText.IndexOf("<a href=\"");
                                endOfLink = index + 8;

                                while(pageText[endOfLink] != ' ')
                                    endOfLink++;

                                linkFound = pageText.Substring(index + 9, endOfLink - (index + 10));//we separate the link found and check if its valid

                                if(globalCrawlersCount < maxCrawlerNum && this.pathLength < 100 && linkFound.Contains("/wiki/") && checkLink(linkFound))
                                    {
                                        new Crawler(pathLength, linkBeg + linkFound, keyWord);//if it is we create new crawler for the link's page
                                        globalCrawlersCount++;
                                    }
                                
                                pageText = pageText.Substring(endOfLink + 1);//then we go through the rest of the page looking for more links
                            }
                            else
                                pageText = "";//if there aren't anymore links we set the pageText length to 0 to end the loop

                            //Thread.Yield();
                        }
                    }
                }
                crawlersCompleted++;
            }
        }

        static void Main(string[] args)
        {
            string randomInitPage = "http://en.wikipedia.org/wiki/Special:Random";
            //string initLink = "https://pl.wikipedia.org/wiki/Toster";

            int loops;
            loops = int.Parse(Console.ReadLine());

            for(int i = 0; i < loops; i++)
            {
                Console.WriteLine("Starting loop nr: " + i);
                keyWordFound = false;
                crawlersCompleted = 0;
                globalCrawlersCount = 0;
                new Crawler(-1, randomInitPage, "Matrix");
                while (!keyWordFound && crawlersCompleted < maxCrawlerNum)
                {

                }
                Thread.Sleep(1234);
            }

            Thread.Sleep(1000);

            Console.WriteLine("Path lengths: ");
            foreach(var x in pathLengthsFound)
            {
                Console.WriteLine(x);
            }
        }
    }
}
