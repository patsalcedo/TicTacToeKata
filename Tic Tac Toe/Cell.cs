namespace Tic_Tac_Toe
{
    public class Cell
    {
        public int XCoord { get; }
        public int YCoord { get; }
        public Symbol Symbol { get; set; }

        public Cell()
        {
            Symbol = Symbol.Empty;
        }
        
        public Cell(int xCoord, int yCoord, Symbol symbol)
        {
            XCoord = xCoord;
            YCoord = yCoord;
            Symbol = symbol;
        }
    }
}