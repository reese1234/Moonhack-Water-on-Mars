using System.Collections.Generic;

namespace Water_on_Mars
{
    class Data
    {
        public static int Water = 1000;
        public static int Day = 1;

        public static List<Event> events = new List<Event>
        {
           new Event {Question = "You are beginning to smell, do you take a shower?", Yes = Game.Rnd(-200, -100), No = 0 },
           new Event {Question = "You hear a hissing sound, do you investigate?", Yes = Game.Rnd(-100, -50), No = Game.Rnd(-600, -300) },
           new Event {Question = "A lump of ice has fallen from the sky nearby, do you retrieve it?", Yes = Game.Rnd(50, 150), No = Game.Rnd(-50, -25) },
           new Event {Question = "You watched a YouTube video about the best lawns in the solar system. Do you decide to try and grow a lawn in the desolate Martian soils?", Yes = Game.Rnd(-350, -200), No = 0 },
           new Event {Question = "Your cousin Harold has mysteriously appeared. Do you send him away?", Yes = Game.Rnd(-50, -25), No = Game.Rnd(-250, -100) },
           new Event {Question = "Mmm, salty food. Do you eat it?", Yes = Game.Rnd(-10, -3), No = 0 },
           new Event {Question = "You find a cave nearby. Investigate it?", Yes = Game.Rnd(50, 100), No = Game.Rnd(-50, 0) }
        };
    }
}
