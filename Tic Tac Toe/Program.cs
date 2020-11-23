using System;
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
            Boolean gameEnd = false;
            PrintBoard(board); // prints initial new board
            Boolean player1TurnHandled = false;

            // while(!gameEnd){ // need to check the board state
            while (!player1TurnHandled)
            {
                 Console.Write("Player 1 enter a coord x,y to place your X or enter 'q' to give up: "); 
                 string player1Coord = Console.ReadLine();
                 player1TurnHandled = HandlePlayerCommand(player1Coord, board, "X");
                 // check if player won
                 //player1TurnHandled = true;
            }
            Console.Write("Player 2 enter a coord x,y to place your O or enter 'q' to give up: ");
            string player2Coord = Console.ReadLine();
            HandlePlayerCommand(player2Coord, board, "O");
            // check if player won
            player1TurnHandled = true;

            // gameEnd = true;

            // }

        }

        static Boolean HandlePlayerCommand(string coord, string[,] board, string player)
        {
            Boolean playHandled = false;
            Boolean validInput = IsInvalid(coord);
            if(validInput)
            {
                playHandled = false;
                return playHandled;
            }
            int[] coordArray = coord.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            coordArray[0] = coordArray[0] - 1;
            coordArray[1] = coordArray[1] - 1;

            CheckBoardElementIsTaken(board, coordArray);
            
            // assigning element on board
            board[coordArray[0],coordArray[1]] = player;
            Console.WriteLine("Move accepted, here's the current board: ");
            PrintBoard(board);
            playHandled = true;
            return playHandled;
        }

        static void PrintBoard(string[,] board){
            for(int i = 0; i < 3; i++){
                for(int j = 0; j<3; j++){
                    Console.Write(board[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }

        static Boolean IsInvalid(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please enter coordinates.");
                return true;
            }
            if (input == "q")
            {
                Console.WriteLine("You have quit the game.");
                System.Environment.Exit(1);
            }
            else if (!Regex.IsMatch(input, "^([1-3]),([1-3])$"))
            {
                Console.WriteLine("Please enter coordinates between 1 and 3 in the form x,y");
                return true;
            }

            return false;
        }

        static void CheckBoardElementIsTaken(string[,] board, int[] coordArray)
        {
            if (board[coordArray[0], coordArray[1]] != ".")
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
            }
        }
    }
}