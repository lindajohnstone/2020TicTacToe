using System;
using TicTacToe;

namespace tests.TicTacToe
{
    public class StubConsoleOutput : IOutput
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