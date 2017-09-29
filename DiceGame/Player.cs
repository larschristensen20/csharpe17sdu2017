using System;
using System.Collections.Generic;
using System.Text;

namespace DiceGame
{
    class Player
    {
        private String _name;
        private int totalScore;

        public Player(string name)
        {
            this._name = name;
            totalScore = 0;
        }

        public String Name
        {
            get { return _name; }
        }

        public int TotalScore
        {
            get =>totalScore;
            set => totalScore =+ value;
        }

    }
}
