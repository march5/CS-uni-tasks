using System;

namespace Events
{
    class Program
    {

        public delegate void VoteStart();
        public delegate void VoteEnd();

        public class Parliament
        {
            public event VoteStart VotingStarted;
            public event VoteEnd VotingEnded;

            public string topic;
            public int votesYes = 0;
            public int votesNo = 0;

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

            public void EndVote(object sender, bool vote)
            {   
                Console.WriteLine("END");
                Console.WriteLine("Voting on " + this.topic + " ended with " + this.votesYes + " votes on yes and " + this.votesNo + " votes on NO ");
                
                OnVoteEnd();
            }

            protected virtual void OnVoteEnd()
            {
                VotingEnded?.Invoke();
            }

            public void TakeVote(object sender, bool vote)
            {
                if (vote == true) votesYes++;
                else votesNo++;
            }
        }

        public class Parlamentarian
        {
            public event EventHandler<bool> PVote;

            public void Vote()
            {
                Random rnd = new Random();
                if (rnd.Next(2) == 1) OnGiveVote(true);
                else OnGiveVote(false);
                //Console.WriteLine("Voted " + res);
            }

            protected virtual void OnGiveVote(bool vote)
            {
                  PVote?.Invoke(this, vote);
            }
        }

        static void Main(string[] args)
        {
            int i;

            Console.WriteLine("Amount of parlamentarians: ");
            int pAmount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vote topic: ");
            string topic = Console.ReadLine();

            Parliament parliament = new Parliament();
            Parlamentarian[] parlamentarians = new Parlamentarian[pAmount];

            for(i = 0; i < pAmount ; i++)
            {
                parlamentarians[i] = new Parlamentarian();
                parliament.VotingStarted += parlamentarians[i].Vote;
                parlamentarians[i].PVote += parliament.TakeVote;
            }

            parlamentarians[i - 1].PVote += parliament.EndVote;

            parliament.StartVote(topic);
        }
    }
}
