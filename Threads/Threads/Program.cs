using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Threads
{
    class Program
    {

        static void PingAddress(string[] input, int start)
        {   
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            string[] texts;

            PingReply reply;
            int i = start;

            while(i < start + input.Length/4 + 1 && i < input.Length)
            {
                texts = input[i].Split(';');
                Console.WriteLine(Thread.CurrentThread.Name + " " + i);
                reply = pingSender.Send(texts[1], timeout, buffer, options);
                if (reply.Status == IPStatus.Success) Console.WriteLine("Succesfully pinged " + texts[0] + "by thread" + Thread.CurrentThread.Name);
                i++;
            }
        }

        public static long Threads1()
        {
            string loc = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ping.txt");

            string[] text = File.ReadAllLines(loc);
            Console.WriteLine(text.Length);

            int lengthForOne = text.Length / 4;

            Stopwatch sw1 = new Stopwatch();
            
            Thread[] t = new Thread[4];
            sw1.Start();

            t[0] = new Thread(() => PingAddress(text, 0));
            t[0].Name = "0";
            t[1] = new Thread(() => PingAddress(text, lengthForOne));
            t[1].Name = "1";
            t[2] = new Thread(() => PingAddress(text, lengthForOne * 2));
            t[2].Name = "2";
            t[3] = new Thread(() => PingAddress(text, lengthForOne * 3));
            t[3].Name = "3";

            t[0].Start();
            t[1].Start();
            t[2].Start();
            t[3].Start();

            t[0].Join();
            t[1].Join();
            t[2].Join();
            t[3].Join();

            sw1.Stop();
            return sw1.ElapsedMilliseconds;
        }

        public static async Task PingAddressTask(string input)
        {
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();

                options.DontFragment = true;

                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 120;

                string[] texts = input.Split(';');

                Console.WriteLine("Tryign to ping " + texts[0]);
                pingSender.Send(texts[1], timeout, buffer, options);
        }

        public static async void TaskPing()
        {
            
            string loc = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ping.txt");

            string[] text = File.ReadAllLines(loc);
            Console.WriteLine(text.Length);
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            await Task.WhenAll(text.Select(x => PingAddressTask(x)));

            sw1.Stop();
            Console.WriteLine(sw1.ElapsedMilliseconds); 
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Threads1());
            //TaskPing();
        }
    }
}
