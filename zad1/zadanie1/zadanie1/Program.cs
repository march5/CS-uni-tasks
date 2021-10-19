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

        public static void HeroCreation()
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
        }

        public class NonPlayerCharacter
        {
            public string name;


            public NonPlayerCharacter(string a)
            {
                name = a;
            }

            public static void StartTalking() { }
        }

        public static class NpcDialogPart {
            public static List<string> dialogi = new List<string> { "Witaj, czy możesz mi pomóc dostać się do innego miasta? ", 
                                                             "Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota",
                                                            "Niestety nie mam więcej.Jestem bardzo biedny." +
                                                            "Dziękuję."};
            public static List<int> przejscia = new List<int> { 0, 5, 1, 2, 3, 4, -1 , -1};

        }

        public static class HeroDialogPart
        {
            public static List<string> dialogi = new List<string> {" Tak, chętnie pomogę." , " Dam znać jak będę gotowy" , "100 sztuk złota to za mało!"
            , "OK, może być 100 sztuk złota." , "W takim razie radź sobie sam." , "Nie, nie pomogę, żegnaj."};

            public static List<int> przejscia = new List<int> { 1, -1, 2, 3, -1, -1 };
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

        public static void TalkTo(NonPlayerCharacter npc)
        {
            bool properChoice = false;
            int next, next2;
            Console.WriteLine(NpcDialogPart.dialogi[0]);
            next = NpcDialogPart.przejscia[0];
            next2 = NpcDialogPart.przejscia[1];

            while(next != -1)
            {
                //Console.WriteLine(HeroDialogPart.dialogi[next]);

                Console.WriteLine("1 - " + HeroDialogPart.dialogi[next]);
                Console.WriteLine("2 - " + HeroDialogPart.dialogi[next2]);

                var key = Console.ReadKey();
                

                while(properChoice == false)
                {
                    if(key.Key == ConsoleKey.D1)
                    {
                        next = HeroDialogPart.przejscia[next];
                            properChoice = true;
                        break;
                    }
                    else if(key.Key == ConsoleKey.D2)
                    {
                            properChoice = true;
                        next = HeroDialogPart.przejscia[next2];
                        break;
                    }
                    key = Console.ReadKey();
                }
                
                if(next >= 0)
                {
                Console.WriteLine(NpcDialogPart.dialogi[next]);
                next2 = NpcDialogPart.przejscia[next*2 + 1];
                next = NpcDialogPart.przejscia[next*2];
                }
                
                properChoice = false;
            }
        }

        static void Main(string[] args)
        {

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
                    HeroCreation();
                    lokacja = new Location("Kholinar");

                    bool exit = false;
                    while (exit == false)
                    {   
                        ShowLocation(lokacja);
                        key = Console.ReadKey();
                        switch (key.Key)
                        {
                            case ConsoleKey.D1:
                                TalkTo(lokacja.npcs[0]);
                                break;
                            case ConsoleKey.D2:
                                TalkTo(lokacja.npcs[1]);
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
