using System;

namespace tests.TicTacToe
{
    public class PlayerPosition
    {
        public string SetPosition(string value)
        {
            // receives "1","1"
            string[] userInput = value.Split(",");
            int first = Convert.ToInt32(userInput[0]); // 1
            int second = Convert.ToInt32(userInput[1]); // 1
            first = first - 1; // 0
            second = second - 1; // 0
            var firstValue = Convert.ToString(first); // "0"
            var secondValue = Convert.ToString(second); // "0"
            string arrayInput = String.Concat(firstValue, ",", secondValue); // "0,0"
            return arrayInput; // "0,0" - fails; passes if both expected and actual are "0,0"
        }
    }
}