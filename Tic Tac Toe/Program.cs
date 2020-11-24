﻿using System;
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
            PrintBoard(board);

            var currentPlayer = "X";
            var gameStatus = GameStatus.InGame;

            while (gameStatus == GameStatus.InGame)
            {
                gameStatus = HandlePlayerTurn(currentPlayer, board);
                if (gameStatus == GameStatus.Aborted)
                {
                    break;
                }
                switch (gameStatus)
                {
                    case GameStatus.InGame:
                        Console.WriteLine("Move accepted, here's the current board: ");
                        break;
                    case GameStatus.Win:
                        Console.WriteLine("Move accepted, well done you've won the game!");
                        break;
                    case GameStatus.Draw:
                        Console.WriteLine("Game has a draw.");
                        break;
                    default:
                        Console.WriteLine("You quit the game.");
                        break;
                }
                PrintBoard(board);
                currentPlayer = currentPlayer == "X" ? "O" : "X";
            }
        }

        private static GameStatus HandlePlayerTurn(string currentPlayer, string[,] board)
        {
            var hasPlayerMadeValidMove = false;
            while (!hasPlayerMadeValidMove)
            {
                var player = currentPlayer == "X" ? "1" : "2";
                Console.Write("Player " + player + " enter a coord x,y to place your " + currentPlayer +
                              " or enter 'q' to give up: ");
                var playerCoord = Console.ReadLine();
                if (playerCoord == "q")
                {
                    return GameStatus.Aborted;
                }
                hasPlayerMadeValidMove = HasPlayerMadeMove(playerCoord, board, currentPlayer);
            }
            return CheckBoardForWin(board, currentPlayer);
        }

        private static bool HasPlayerMadeMove(string coord, string[,] board, string player)
        {
            if (String.IsNullOrEmpty(coord))
            {
                Console.WriteLine("Please enter coordinates.");
                return false;
            }
            if (!Regex.IsMatch(coord, "^([1-3]),([1-3])$"))
            {
                Console.WriteLine("Please enter coordinates between 1 and 3 in the form x,y");
                return false;
            }
            
            int[] coordArray = coord.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            coordArray[0] = coordArray[0] - 1;
            coordArray[1] = coordArray[1] - 1;

            if (!IsBoardElementTaken(board, coordArray))
            {
                board[coordArray[0], coordArray[1]] = player;
            }
            else
            {
                return false;
            }
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

        private static bool IsBoardElementTaken(string[,] board, int[] coordArray)
        {
            if (board[coordArray[0], coordArray[1]] != ".")
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                return true;
            }
            return false;
        }

        private static GameStatus CheckBoardForWin(string[,] board, string player)
        {
            if ((board[0, 0] == player && board[0, 1] == player && board[0, 2] == player))
            {
                return GameStatus.Win;
            }
            if ((board[1, 0] == player && board[1, 1] == player && board[1, 2] == player))
            {
                return GameStatus.Win;
            }
            if ((board[2, 0] == player && board[2, 1] == player && board[2, 2] == player))
            {
                return GameStatus.Win;
            }
            if ((board[0, 0] == player && board[1, 0] == player && board[2, 0] == player))
            {
                return GameStatus.Win;
            }
            if ((board[0, 1] == player && board[1, 1] == player && board[2, 1] == player))
            {
                return GameStatus.Win;
            }
            if ((board[0, 2] == player && board[1, 2] == player && board[2, 2] == player))
            {
                return GameStatus.Win;
            }
            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player))
            {
                return GameStatus.Win;
            }
            if ((board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
            {
                return GameStatus.Win;
            }
            if (board[0, 0] != "." && board[0, 1] != "." && board[0, 2] != "." && board[1, 0] != "." &&
                board[1, 1] != "." && board[1, 2] != "." && board[2, 0] != "." && board[2, 1] != "." &&
                board[2, 2] != ".")
            {
                return GameStatus.Draw;
            }
            return GameStatus.InGame;
        }
    }
}