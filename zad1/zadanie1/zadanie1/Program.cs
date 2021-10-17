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

        public class NpcDialogPart {
            public List<string> dialogi = new List<string> { "Witaj, czy możesz mi pomóc dostać się do innego miasta? ", 
                                                             "Dziękuję! W nagrodę otrzymasz ode mnie 100 sztuk złota",
                                                            "Niestety nie mam więcej.Jestem bardzo biedny." +
                                                            "Dziękuję."};
            public List<int> przejscia = new List<int> { };

        }

        public class HeroDialogPart
        {
            public List<string> dialogi = new List<string> {" Tak, chętnie pomogę." + " Dam znać jak będę gotowy" + "100 sztuk złota to za mało!"
            + "OK, może być 100 sztuk złota." + "W takim razie radź sobie sam." + "Nie, nie pomogę, żegnaj."};

            public List<int> przejscia = new List<int> { };
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

        }

        static void Main(string[] args)
        {

            Location lokacja;

            Console.WriteLine("Witaj w grze Evil Dungeon");
            Console.WriteLine("[1] Zacznij nową grę");
            Console.WriteLine("[2] Zamknij program");

            var key = Console.ReadKey();
            int properChoice = 0;

            while(properChoice == 0)
            if (key.Key == ConsoleKey.D1)
            {
                    HeroCreation();
                    lokacja = new Location("Kholinar");

                    ShowLocation(lokacja);

                    key = Console.ReadKey();
                    bool exit = false;
                    while(exit == false)
                    {
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
                                break;
                            default:
                                Console.WriteLine("Niepoprawny wybór!");
                                break;
                        }
                    }

                
            }
            else
            if(key.Key != ConsoleKey.D2)
            {
                Console.WriteLine("Niepoprawny wybór!");
            }
                
        }
    }
}
