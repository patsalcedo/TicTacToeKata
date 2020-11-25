﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var playerUi = new ConsoleUI();

            RunGame(playerUi);
        }

        private static void RunGame(PlayerUI playerUi)
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board: ");
            string[,] board = {{".", ".", "."}, {".", ".", "."}, {".", ".", "."}};
            PrintBoard(board);

            var currentPlayer = "X";
            var gameStatus = GameStatus.InGame;

            while (gameStatus == GameStatus.InGame)
            {
                gameStatus = HandlePlayerTurn(currentPlayer, board, playerUi);

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

        private static GameStatus HandlePlayerTurn(string currentPlayer, string[,] board, PlayerUI playerUi)
        {
            GameStatus gameStatus;
            // ask for input

            string playerCoord = null;
            var hasPlayerMadeValidMove = false;
            while (!hasPlayerMadeValidMove)
            {
                var playerCommand = playerUi.GetPlayerCommand(currentPlayer);

                if (playerCommand is QuitApplication)
                {
                    return GameStatus.Aborted;
                }

                if (playerCommand is PlaceSymbolCommand placeSymbolCommand)
                {
                    var x = placeSymbolCommand.X;
                    var y = placeSymbolCommand.Y;
                    if (board[x, y] != ".")
                    {
                        Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                    }
                    else
                    {
                        board[x, y] = currentPlayer;
                        hasPlayerMadeValidMove = true;
                    }
                }
            }

            if ((board[0, 0] == currentPlayer && board[0, 1] == currentPlayer && board[0, 2] == currentPlayer))
            {
                gameStatus = GameStatus.Win;
            }
            else
            {
                if ((board[1, 0] == currentPlayer && board[1, 1] == currentPlayer && board[1, 2] == currentPlayer))
                {
                    gameStatus = GameStatus.Win;
                }
                else
                {
                    if ((board[2, 0] == currentPlayer && board[2, 1] == currentPlayer && board[2, 2] == currentPlayer))
                    {
                        gameStatus = GameStatus.Win;
                    }
                    else
                    {
                        if ((board[0, 0] == currentPlayer && board[1, 0] == currentPlayer && board[2, 0] == currentPlayer))
                        {
                            gameStatus = GameStatus.Win;
                        }
                        else
                        {
                            if ((board[0, 1] == currentPlayer && board[1, 1] == currentPlayer && board[2, 1] == currentPlayer))
                            {
                                gameStatus = GameStatus.Win;
                            }
                            else
                            {
                                if ((board[0, 2] == currentPlayer && board[1, 2] == currentPlayer && board[2, 2] == currentPlayer))
                                {
                                    gameStatus = GameStatus.Win;
                                }
                                else
                                {
                                    if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer))
                                    {
                                        gameStatus = GameStatus.Win;
                                    }
                                    else
                                    {
                                        if ((board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                                        {
                                            gameStatus = GameStatus.Win;
                                        }
                                        else
                                        {
                                            if (board[0, 0] != "." && board[0, 1] != "." && board[0, 2] != "." && board[1, 0] != "." &&
                                                board[1, 1] != "." && board[1, 2] != "." && board[2, 0] != "." && board[2, 1] != "." &&
                                                board[2, 2] != ".")
                                            {
                                                gameStatus = GameStatus.Draw;
                                            }
                                            else
                                            {
                                                gameStatus = GameStatus.InGame;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return gameStatus;
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
    }
}