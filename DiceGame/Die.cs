using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame
{
    class Die
    {
        private int _sides;
        private int result;
        Random rng;

        public Die(int sides)
        {
            this._sides = sides;
            rng = new Random();
        }

        // tosses the die
        public void TossDie()
        {
            result = rng.Next(_sides) + 1;
        }

        public int Result
        {
            get => result;
        }
        
    }
}
