using System;
using System.Threading;

namespace Water_on_Mars
{
    class Game
    {
        public static void Message(string say, ConsoleColor color)
        {
            Color.Text(color);
            foreach (char letter in say)
            {
                Console.Write(letter);
                Thread.Sleep(50);
            }
            Console.WriteLine();
            Color.Reset();
            Thread.Sleep(500);
        }

        public static void Choice(string question, string A, string B)
        {
            Message(question, Color.Cyan);
            Color.Text(Color.White);
            Console.WriteLine($"(A) {A}");
            Console.WriteLine($"(B) {B}");
        }

        public static void Water(int change)
        {
            if (change == 0)
            {
                Message("No water change.", Color.Yellow);
            } else
            {
                Data.Water += change;
                Message($"{change}L water: {Data.Water}L", Color.Yellow);
            }
        }
        public static void Water(string up, int change, string reason)
        {
            if (!(change == 0)) {
                if (up == "+")
                {
                    Data.Water += change;
                    Message($"+{change}L water ({reason}): {Data.Water}L", Color.Green);
                }
                else if (up == "-")
                {
                    Data.Water -= change;
                    Message($"-{change}L water ({reason}): {Data.Water}L", Color.Red);
                }
            }
        }

        public static int Rnd(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max);
        }

        public static void Exit()
        {
            Message($"Game Over! You survived for {Data.Day} days.", Color.Red);
            Message("Would you like to try again?", Color.Cyan);
            for (; ; )
            {
                Console.Write("> ");
                string input = Console.ReadLine().ToLower();

                if (input.Contains("yes") || input.Contains("y"))
                {
                    Program.Play();
                    break;
                }
                else if (input.Contains("no") || input.Contains("n"))
                {
                    Thread.Sleep(3000);
                    Color.Text(Color.Green);
                    Console.WriteLine("Exiting in 5...");
                    Thread.Sleep(1000);
                    Console.WriteLine("           4...");
                    Thread.Sleep(1000);
                    Console.WriteLine("           3...");
                    Thread.Sleep(1000);
                    Console.WriteLine("           2...");
                    Thread.Sleep(1000);
                    Console.WriteLine("           1...");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Message("Please answer 'yes' or 'no'.", Color.Red);
                }
            }
        }
    }
}
