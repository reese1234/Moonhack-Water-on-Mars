using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Water_on_Mars
{

    //Pull request test
    //try accepting this somehow
    class Program
    {
        public static int water = 1000;
        public static int day = 1;

        public static string Event;
        public static string input;

        public static List<Daily> events = new List<Daily>
        {
           new Daily {Event = "You are beginning to smell, do you take a shower?", Yes = Rnd(-200, -100), No = 0 },
           new Daily {Event = "You hear a hissing sound, do you investigate?", Yes = Rnd(-100, -50), No = Rnd(-600, -300) },
           new Daily {Event = "A lump of ice has fallen from the sky nearby, do you retrieve it?", Yes = Rnd(50, 150), No = Rnd(-50, -25) },
           new Daily {Event = "You watched a YouTube video about the best lawns in the solar system. Do you decide to try and grow a lawn in the desolate Martian soils?", Yes = Rnd(-350, -200), No = 0 },
           new Daily {Event = "Your cousin Harold has mysteriously appeared. Do you send him away?", Yes = Rnd(-50, -25), No = Rnd(-250, -100) },
           new Daily {Event = "Mmm, salty food. Do you eat it?", Yes = Rnd(-10, -3), No = 0 },
        };

        static void Main(string[] args)
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
            water = 1000;
            day = 1;
            while (water > 0)
            {
                Game.Message($"Day {day}!", Color.Green);
                Game.Water("-", Rnd(1, 15), "A day passed");
                if (Rnd(1, 6) < 5)
                {
                    var randNumber = Rnd(0, events.Count);
                    Event = events[randNumber].Event;
                    Game.Message(Event, Color.Cyan);
                    for (; ; )
                    {
                        Console.Write("> ");
                        input = Console.ReadLine().ToLower();

                        if (choice("yes", "y"))
                        {
                            Game.Water(events.SingleOrDefault(e => e.Event == Event).Yes);
                            break;
                        }
                        else if (choice("no", "n"))
                        {
                            Game.Water(events.SingleOrDefault(e => e.Event == Event).No);
                            break;
                        }
                        else
                        {
                            Game.Message("Please answer 'yes' or 'no'.", Color.Red);
                        }
                    }
                } else
                {
                    Game.Message("Today there were no unusual events nearby.", Color.Yellow);
                }
                day++;
                Console.WriteLine();
            }
            Game.Exit();
        }

        public static int Rnd(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public static bool choice(string answer1, string answer2)
        {
            answer1 = answer1.ToLower();
            answer2 = answer2.ToLower();
            if (input.Contains(answer1) || input.Contains(answer2))
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
