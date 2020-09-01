using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class PlayerPosition
    {
        public PlayerPosition(string value)
        {
            var userInput = value.Split(",");
            int.TryParse(userInput[0], out var x);
            X = x; 
            int.TryParse(userInput[1], out var y); 
            Y = y;
            // logic : receive X & Y; SetArray = array.SetValue(1, 0, 0); print board
            
        }

        public int X { get; internal set; }
        public int Y { get; internal set; }
        
    }
}