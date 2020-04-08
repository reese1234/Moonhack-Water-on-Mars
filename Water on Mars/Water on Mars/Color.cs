using System;

namespace Water_on_Mars
{
    class Color
    {
        public static void Text(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void Reset()
        {
            Console.ForegroundColor = Gray;
        }

        public static ConsoleColor Gray = ConsoleColor.Gray;
        public static ConsoleColor Red = ConsoleColor.Red;
        public static ConsoleColor Green = ConsoleColor.Green;
        public static ConsoleColor Cyan = ConsoleColor.Cyan;
        public static ConsoleColor Yellow = ConsoleColor.Yellow;
    }
}
