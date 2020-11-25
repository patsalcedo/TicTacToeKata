using System;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public double NumOfCells;
        public Cell[,] ABoard; // the problem is that this is null
        
        public Board(int numOfCells)
        {
            NumOfCells = Math.Sqrt(numOfCells);
            var boardLength = Math.Sqrt(numOfCells);
            for (int row = 0; row < boardLength; row++)
            {
                for (int col = 0; col < boardLength; col++)
                {
                    ABoard[row, col] = new Cell(); // pretty sure it's my syntax here
                }
            }
        }

        public void PrintBoard()
        {
            for (var i = 0; i < NumOfCells; i++)
            {
                for (var j = 0; j < NumOfCells; j++)
                {
                    Console.Write(ABoard[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}