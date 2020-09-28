using System;

namespace TicTacToe
{
    public class ConsoleOutput : IOutput
    {
        public void OutputText(string text)
        {
            Console.Write(text);
        }
        public void OutputTextWithNewLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}