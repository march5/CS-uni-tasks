using System;

namespace zad02
{
    class Program
    {

        public delegate bool VoteStart();
        public delegate void VoteEnd();

        public delegate bool GiveVote();

        public class Parliament
        {
            public event VoteStart VotingStarted;
            public event VoteEnd VotingEnded;

            public string topic;

            public void StartVote(string t)
            {
                topic = t;
                Console.WriteLine("BEGGINING");

                OnVoteStart();
            }

            protected virtual void OnVoteStart()
            {
                VotingStarted?.Invoke();
            }

            public void EndVote()
            {
                Console.WriteLine("END");

                OnVoteEnd();
            }

            protected virtual void OnVoteEnd()
            {
                VotingEnded?.Invoke();
            }
        }

        public class Parlamentarian
        {
            public event GiveVote PVote;

            public static bool Vote()
            {
                bool res;
                Random rnd = new Random();
                if (rnd.Next(2) == 1) res = true;
                else res = false;
                Console.WriteLine("Voted " + res);
                return res;
            }            
        }

        static void Main(string[] args)
        {
            int pAmount = Convert.ToInt32(Console.ReadLine());

            Parliament parliament = new Parliament();
            Parlamentarian[] parlamentarians = new Parlamentarian[pAmount];

            for(int i = 0; i < pAmount; i++)
            parliament.VotingStarted += Parlamentarian.Vote;

            parliament.StartVote("temat");

        }
    }
}
