using System;
using System.Threading;
using System.Linq;

namespace Water_on_Mars
{
    class Program
    {
        public static string DailyEvent;
        public static string input;

        static void Main()
        {
            for (; ; )
            {
                try
                {
                    Play();
                }

                catch (Exception e)
                {
                    Game.Message("Oh no! An error occured!", Color.Red);
                    Color.Text(Color.Red);
                    Console.WriteLine(e);
                }

                finally
                {
                    Game.Message("Restarting...", Color.Green);
                    Thread.Sleep(2000);
                }
            }
        }

        public static void Play()
        {
            Data.Water = 1000;
            Data.Day = 1;
            while (Data.Water > 0)
            {
                Game.Message($"Day {Data.Day}", Color.Green);
                Game.Water("-", Game.Rnd(1, 15), "A Day passed");
                if (Game.Rnd(1, 6) < 5)
                {
                    var randNumber = Game.Rnd(0, Data.events.Count);
                    DailyEvent = Data.events[randNumber].Question;
                    Game.Choice(DailyEvent, "Yes", "No");
                    for (; ; )
                    {
                        Color.Text(Color.White);
                        Console.Write("> ");
                        Color.Text(Color.Green);
                        input = Console.ReadLine().ToLower();

                        if (choice("a"))
                        {
                            Game.Water(Data.events.SingleOrDefault(e => e.Question == DailyEvent).Yes);
                            break;
                        }
                        else if (choice("b"))
                        {
                            Game.Water(Data.events.SingleOrDefault(e => e.Question == DailyEvent).No);
                            break;
                        }
                        else
                        {
                            Game.Message("A: Yes, B: No", Color.Red);
                        }
                        Color.Reset();
                    }
                } else
                {
                    Game.Message("Today there were no unusual events nearby.", Color.Yellow);
                }
                Data.Day++;
                Console.WriteLine();
            }
            Game.Exit();
        }

        public static bool choice(string answer)
        {
            answer = answer.ToLower();
            if (input.Contains(answer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
