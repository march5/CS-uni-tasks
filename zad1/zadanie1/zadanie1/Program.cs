using System;
using System.Collections.Generic;

namespace zadanie1
{
    class Program
    {

        public enum EHeroClass{barbazynca, paladyn, amazonka };

        public class Hero {
            public string name;
            public EHeroClass heroClass;
        }

        static bool CheckName(ref string name)
        {
            int i = 0;
            name.Trim(' ');
            if (name.Length < 2) return false;

            while(i < name.Length)
            {
                if (((int)name[i] < 65 && name[i] != ' ') || ((int)name[i] > 90 && (int)name[i] < 97) || (int)name[i] > 122)
                    return false;
                if (name[i] == ' ' && name[i + 1] == ' ')
                {
                    name = name.Remove(i + 1, 2);
                    Console.WriteLine("OK");
                }
                i++;
            }

            return true;
        }

        public static Hero HeroCreation()
        {
            Console.Clear();
            Hero hero = new Hero();
            Console.WriteLine("Proszę podać nazwę postaci: ");
            string charName = Console.ReadLine();

            while (CheckName(ref charName) == false)
            {
                Console.WriteLine("Błędna nazwa postaci! Spróbuj ponownie: ");
                charName = Console.ReadLine();
            }

            hero.name = charName;

            Console.WriteLine("Witaj " + hero.name + "! Wybierz klasę postaci: \n" + " 1 - barbarzyńca \n 2 - paladyn \n 3 - amazonka \n");
            bool properChoice = false;

            while (properChoice == false)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        hero.heroClass = EHeroClass.barbazynca;
                        Console.WriteLine("Wybrano klasę " + hero.heroClass.ToString());
                        properChoice = true;
                        break;
                    case ConsoleKey.D2:
                        hero.heroClass = EHeroClass.paladyn;
                        Console.WriteLine("Wybrano klasę " + hero.heroClass.ToString());
                        properChoice = true;
                        break;
                    case ConsoleKey.D3:
                        hero.heroClass = EHeroClass.amazonka;
                        Console.WriteLine("Wybrano klasę " + hero.heroClass.ToString());
                        properChoice = true;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór! Spróbuj ponownie: ");
                        break;
                }

            Console.Clear();

            Console.WriteLine(hero.heroClass.ToString() + " " + hero.name + " wyrusza do dungeonu.");

            Console.ReadKey();

            return hero;
        }

        public class NonPlayerCharacter
        {
            public string name;
            public NpcDialogPart npcDialog;
            public HeroDialogPart heroDialog;


            public NonPlayerCharacter(string a)
            {
                name = a;
            }

            public void addNpcDial(List<string> dial, List<int> p)
            {
                npcDialog = new NpcDialogPart(dial, p);
            }

            public void addHeroDial(List<string> dial, List<int> p)
            {
                heroDialog = new HeroDialogPart(dial, p);
            }

        }

        public interface IDialogPart {

            public List<string> dialogi { get; set; }
            public List<int> przejscia { get; set; }
        
        }


        public class NpcDialogPart : IDialogPart {

            public List<string> dialogi { get; set; }
            /*= new List<string> { "Witaj, czy możesz mi pomóc dostać się do innego miasta? ", 
                                                             "Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota",
                                                            "Niestety nie mam więcej.Jestem bardzo biedny." +
                                                            "Dziękuję."};*/

            public List<int> przejscia { get; set; }
            //= new List<int> { 0, 5, 1, 2, 3, 4, -1 , -1};

            public NpcDialogPart(List<string> d, List<int> p)
            {
                dialogi = d;
                przejscia = p;
            }

        }

        public class HeroDialogPart : IDialogPart
        {
            public List<string> dialogi { get; set; }
            //= new List<string> {" Tak, chętnie pomogę." , " Dam znać jak będę gotowy" , "100 sztuk złota to za mało!"
            //, "OK, może być 100 sztuk złota." , "W takim razie radź sobie sam." , "Nie, nie pomogę, żegnaj."};

            public List<int> przejscia { get; set; }
            //= new List<int> { 1, -1, 2, 3, -1, -1 };

            public HeroDialogPart(List<string> d, List<int> p)
            {
                dialogi = d;
                przejscia = p;
            }

        }
                    
        public class Location {

            public string name;
            public NonPlayerCharacter[] npcs;

            public Location(string a)
            {
                name = a;
                npcs = new NonPlayerCharacter[2];
                npcs[0] = new NonPlayerCharacter("Adolin");
                npcs[1] = new NonPlayerCharacter("Kal");

                npcs[0].addNpcDial(new List<string> { "Witaj, czy możesz mi pomóc dostać się do innego miasta? ",
                                                             "Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota",
                                                            "Niestety nie mam więcej.Jestem bardzo biedny.", 
                                                            "Dziękuję."}, new List<int> { 0, 5, 1, 2, 3, 4, -1, -1 });
                npcs[0].addHeroDial(new List<string> {" Tak, chętnie pomogę." , " Dam znać jak będę gotowy" , "100 sztuk złota to za mało!"
            ,                                           "OK, może być 100 sztuk złota." , "W takim razie radź sobie sam." ,
                                                        "Nie, nie pomogę, żegnaj."}, new List<int> { 1, -1, 2, 3, -1, -1 });

                npcs[1].addNpcDial(new List<string> { "Hej, czy to ty jesteś tym słynnym #HERONAME# - pogromcą smoków?" , "WOW! Miło poznać!" }, 
                                                        new List<int> { 0, 1, -1, -1 });
                npcs[1].addHeroDial(new List<string> { "Tak, jestem #HERONAME# " , "Nie." } , new List<int> { 1, -1 });
            }
        }

        public static void ShowLocation(Location lokacja)
        {
            Console.WriteLine("Znajdujesz się w " + lokacja.name);
            for(int i = 0; i < lokacja.npcs.Length; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] Porozmawiaj z " + lokacja.npcs[i].name);
            }
            Console.WriteLine("[X] Zakmnij program");
        }

        public static void TalkTo(NonPlayerCharacter npc, Hero hero)
        {
            DialogParser parser = new DialogParser(hero);
            bool properChoice = false;
            int next, next2;
            //Console.WriteLine(npc.npcDialog.dialogi[0]);
            Console.WriteLine(parser.ParseDialog(npc.npcDialog, 0));
            next = npc.npcDialog.przejscia[0];
            next2 = npc.npcDialog.przejscia[1];

            while(next != -1)
            {
                //Console.WriteLine("1 - " + npc.heroDialog.dialogi[next]);
                //Console.WriteLine("2 - " + npc.heroDialog.dialogi[next2]);

                Console.WriteLine("1 - " + parser.ParseDialog(npc.heroDialog, next));
                Console.WriteLine("2 - " + parser.ParseDialog(npc.heroDialog, next2));


                var key = Console.ReadKey();
                

                while(properChoice == false)
                {
                    if(key.Key == ConsoleKey.D1)
                    {
                        next = npc.heroDialog.przejscia[next];
                            properChoice = true;
                        break;
                    }
                    else if(key.Key == ConsoleKey.D2)
                    {
                            properChoice = true;
                        next = npc.heroDialog.przejscia[next2];
                        break;
                    }
                    key = Console.ReadKey();
                }
                
                if(next >= 0)
                {
                    //Console.WriteLine(npc.npcDialog.dialogi[next]);
                    Console.WriteLine(parser.ParseDialog(npc.npcDialog, next));
                next2 = npc.npcDialog.przejscia[next*2 + 1];
                next = npc.npcDialog.przejscia[next*2];
                }
                
                properChoice = false;
            }
        }

        public class DialogParser
        {
            Hero hero;

            public DialogParser(Hero x)
            {
                hero = x;
            }

            public string ParseDialog(IDialogPart part, int i)
            {
                string outPart = "";
                int j = 0,k = 0;
                while(j < part.dialogi[i].Length)
                {
                    while (j < part.dialogi[i].Length && part.dialogi[i][j] != '#')
                        j++;

                    outPart += part.dialogi[i].Substring(k, j - k);

                    //Console.WriteLine(part.dialogi[i].Substring(j, 10) + "$");

                    if( j <= part.dialogi[i].Length - 10 && part.dialogi[i].Substring(j, 10) == "#HERONAME#")
                    {
                        outPart += hero.name;
                    }

                    j = j + 10;
                    k = j;
                }

                return outPart;
            }
        }

        static void Main(string[] args)
        {
            Hero hero;
            Location lokacja;

            Console.WriteLine("Witaj w grze Evil Dungeon");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[2] Zamknij program");

            ConsoleKeyInfo key;
            int properChoice = 0;

            while(properChoice == 0)
            { 
            key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    hero = HeroCreation();
                    lokacja = new Location("Kholinar");

                    bool exit = false;
                    while (exit == false)
                    {   
                        ShowLocation(lokacja);
                        key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.D1:
                                TalkTo(lokacja.npcs[0], hero);
                                break;
                            case ConsoleKey.D2:
                                TalkTo(lokacja.npcs[1], hero);
                                break;
                            case ConsoleKey.X:
                                exit = true;
                                properChoice = 1;
                                break;
                            default:
                                Console.WriteLine("Niepoprawny wybór!");
                                break;
                        }
                    }
                }
                else
                if (key.Key != ConsoleKey.D2)
                {
                    Console.WriteLine("Niepoprawny wybór!");
                }
                else properChoice = 1;
            }
        }
    }
}
