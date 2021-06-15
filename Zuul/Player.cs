using System;

namespace Zuul
{
    public class Player
    {
        public Room CurrentRoom { get; set; }

        public Player()
        {
            CurrentRoom = null;
        }
    }
}