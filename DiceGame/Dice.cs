using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame
{
    class Dice
    {
        private Die _die1;
        private Die _die2;

        private int diceScore;
        private Boolean pairCheck = false;

        public Dice()
        {
            _die1 = new Die(6);
            _die2 = new Die(6);
        }


        // tosses a pair of dice
        public int TossDice()
        {
            _die1.TossDie();
            _die2.TossDie();
            diceScore = _die1.Result + _die2.Result;

            if (_die1.Result == _die2.Result)
            {
                diceScore = (_die1.Result + _die2.Result) * 2;
                pairCheck = true;
            } else if (_die1.Result != _die2.Result)
            {
                pairCheck = false;
            }
            
            return diceScore;
        }

        public Boolean PairCheck
        {
            get => pairCheck;
        }
        public int DiceScore
        {
            get => diceScore;
        }

        public int _die1Score
        {
            get => _die1.Result;
        }

        public int _die2Score
        {
            get => _die2.Result;
        }
    }
}