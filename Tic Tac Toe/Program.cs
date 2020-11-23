﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe! \nHere's the current board: ");
            string[,] board = new string[3,3] {{".",".","."},{".",".","."},{".",".","."}};
            PrintBoard(board); // prints initial new board
            
            Boolean gameEnd = false;
            Boolean player1TurnHandled = false;

            // while(!gameEnd){ // need to check the board state
            while (!player1TurnHandled)
            {
                 Console.Write("Player 1 enter a coord x,y to place your X or enter 'q' to give up: "); 
                 string player1Coord = Console.ReadLine();
                 player1TurnHandled = HandlePlayerCommand(player1Coord, board, "X");
            }

            Console.Write("Player 2 enter a coord x,y to place your O or enter 'q' to give up: ");
            string player2Coord = Console.ReadLine();
            HandlePlayerCommand(player2Coord, board, "O");
            
            player1TurnHandled = true;
            // gameEnd = true;

            // }

        }

        static bool HandlePlayerCommand(string coord, string[,] board, string player) {
            bool playHandled = false;
            bool invalidInput = IsInvalid(coord);
            if(invalidInput)
                return playHandled; // false
            
            int[] coordArray = coord.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            coordArray[0] = coordArray[0] - 1;
            coordArray[1] = coordArray[1] - 1;

            if (!IsBoardElementTaken(board, coordArray))
            {
                // assigning element on board
                board[coordArray[0],coordArray[1]] = player;
                
                if (!CheckBoardForWin(board, player)) {
                    Console.WriteLine("Move accepted, here's the current board: ");
                    PrintBoard(board);
                }
                else {
                    Console.WriteLine("Move accepted, well done you've won the game!");
                    PrintBoard(board);
                    System.Environment.Exit(1);
                }
            }
            else {
                return playHandled; // false
            }
            playHandled = true;
            return playHandled;
        }

        static void PrintBoard(string[,] board) {
            for(int i = 0; i < 3; i++){
                for(int j = 0; j<3; j++){
                    Console.Write(board[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }

        static Boolean IsInvalid(string input) {
            if (String.IsNullOrEmpty(input)) {
                Console.WriteLine("Please enter coordinates.");
                return true;
            }
            if (input == "q") {
                Console.WriteLine("You have quit the game.");
                System.Environment.Exit(1);
            }
            else if (!Regex.IsMatch(input, "^([1-3]),([1-3])$")) {
                Console.WriteLine("Please enter coordinates between 1 and 3 in the form x,y");
                return true;
            }
            return false;
        }

        static Boolean IsBoardElementTaken(string[,] board, int[] coordArray) {
            if (board[coordArray[0], coordArray[1]] != ".") {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                return true;
            }
            return false;
        }
        
        static Boolean CheckBoardForWin(string[,] board, string player) {
            for(int i = 0; i < 3; i++){
                for(int j = 0; j<3; j++){
                    
                }
            }
            return false;
        }
    }
}