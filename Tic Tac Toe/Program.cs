using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board: ");
            string[,] board = {{".", ".", "."}, {".", ".", "."}, {".", ".", "."}};
            PrintBoard(board); // prints initial new board

            var currentPlayer = "X";
            var playerTurnHandled = false;
            
            while (true)
            {
                while (!playerTurnHandled)
                {
                    var player = currentPlayer == "X" ? "1" : "2";
                    Console.Write("Player " + player + " enter a coord x,y to place your " + currentPlayer + " or enter 'q' to give up: ");
                    var playerCoord = Console.ReadLine();
                    playerTurnHandled = HasPlayerMadeMove(playerCoord, board, currentPlayer);
                }
                if (!CheckBoardForWin(board, currentPlayer))
                {
                    Console.WriteLine("Move accepted, here's the current board: ");
                    PrintBoard(board);
                }
                else
                {
                    Console.WriteLine("Move accepted, well done you've won the game!");
                    PrintBoard(board);
                    Environment.Exit(1);
                }
                currentPlayer = currentPlayer == "X" ? "O" : "X";
                playerTurnHandled = false;
            }
        }

        private static bool HasPlayerMadeMove(string coord, string[,] board, string player)
        {
            var invalidInput = IsInvalid(coord);
            if (invalidInput)
                return false;

            int[] coordArray = coord.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            coordArray[0] = coordArray[0] - 1;
            coordArray[1] = coordArray[1] - 1;

            if (!IsBoardElementTaken(board, coordArray))
                board[coordArray[0], coordArray[1]] = player;
            else
                return false;
            return true;
        }

        private static void PrintBoard(string[,] board)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsInvalid(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter coordinates.");
                return true;
            }
            if (input == "q")
            {
                Console.WriteLine("You have quit the game.");
                Environment.Exit(1);
            }
            else if (!Regex.IsMatch(input, "^([1-3]),([1-3])$"))
            {
                Console.WriteLine("Please enter coordinates between 1 and 3 in the form x,y");
                return true;
            }
            return false;
        }

        private static bool IsBoardElementTaken(string[,] board, int[] coordArray)
        {
            if (board[coordArray[0], coordArray[1]] != ".")
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                return true;
            }
            return false;
        }

        private static bool CheckBoardForWin(string[,] board, string player)
        {
            CheckBoardForDraw(board);

            if ((board[0, 0] == player && board[0, 1] == player && board[0, 2] == player))
                return true;

            if ((board[1, 0] == player && board[1, 1] == player && board[1, 2] == player))
                return true;

            if ((board[2, 0] == player && board[2, 1] == player && board[2, 2] == player))
                return true;

            if ((board[0, 0] == player && board[1, 0] == player && board[2, 0] == player))
                return true;

            if ((board[0, 1] == player && board[1, 1] == player && board[2, 1] == player))
                return true;

            if ((board[0, 2] == player && board[1, 2] == player && board[2, 2] == player))
                return true;

            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player))
                return true;

            if ((board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
                return true;

            return false;
        }

        private static void CheckBoardForDraw(string[,] board)
        {
            if (board[0, 0] != "." && board[0, 1] != "." && board[0, 2] != "." && board[1, 0] != "." &&
                board[1, 1] != "." && board[1, 2] != "." && board[2, 0] != "." && board[2, 1] != "." &&
                board[2, 2] != ".")
            {
                Console.WriteLine("Game has a draw.");
                PrintBoard(board);
                Environment.Exit(1);
            }
        }
    }
}