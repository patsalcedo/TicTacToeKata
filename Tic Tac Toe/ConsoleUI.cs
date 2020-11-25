using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tic_Tac_Toe
{
    public class ConsoleUI : PlayerUI
    {
        public PlayerCommand GetPlayerCommand(string currentPlayer)
        {
            while (true)
            {
                var player = currentPlayer == "X" ? "1" : "2";
                Console.Write("Player " + player + " enter a coord x,y to place your " + currentPlayer + " or enter 'q' to give up: ");
                var playerCoord = Console.ReadLine();

                if (playerCoord == "q")
                {
                    return new QuitApplication();
                }

                if (string.IsNullOrEmpty(playerCoord))
                {
                    Console.WriteLine("Please enter coordinates.");
                    continue;
                }

                if (!Regex.IsMatch(playerCoord, "^([1-3]),([1-3])$"))
                {
                    Console.WriteLine("Please enter coordinates between 1 and 3 in the form x,y");
                    continue;
                }

                var coordArray = playerCoord.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                return new PlaceSymbolCommand(coordArray[0] - 1, coordArray[1] - 1);
            }
        }
    }
}