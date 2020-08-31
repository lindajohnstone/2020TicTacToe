using System;
using System.Collections.Generic;

namespace tests.TicTacToe
{
    public class PlayerPosition
    {
        public PlayerPosition(string value)
        {
            string[] userInput = value.Split(",");
            X = Convert.ToInt32(userInput[0]); 
            Y = Convert.ToInt32(userInput[1]); 
        }

        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}