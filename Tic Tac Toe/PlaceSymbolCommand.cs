namespace Tic_Tac_Toe
{
    public class PlaceSymbolCommand : PlayerCommand
    {
        public int X { get; }
        public int Y { get; }

        public PlaceSymbolCommand(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}