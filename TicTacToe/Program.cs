﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var determinators = new IWinningBoard[] 
            {
                new RowDeterminator(),
                new ColumnDeterminator(),
                new LeftRightDiagonalDeterminator(),
            };
            var board = new GameBoard(determinators);
            board.Print();
            board.PlayGame();
        }
    }
}
