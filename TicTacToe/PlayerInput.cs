using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class PlayerInput
    {
        public int X { get; internal set; }

        public int Y { get; internal set; }
        
        public PlayerInput(string value)
        {
            var userInput = value.Split(",");
            int.TryParse(userInput[0], out var x);
            X = x - 1; 
            int.TryParse(userInput[1], out var y); 
            Y = y - 1;
        } 
    }
}