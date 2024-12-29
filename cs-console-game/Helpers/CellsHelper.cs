using cs_console_game.Interfaces;

namespace cs_console_game.Helpers;

public class CellsHelper
{
    public static Tuple<int, int> GetFreeCellCoordinates(ICell[,] board)
    {
        while (true)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, board.GetLength(0));
            int y = rnd.Next(0, board.GetLength(1));
            ICell cell = board[x, y];
            
            if (cell.CanBeOccupied()) return Tuple.Create(x, y);
        }
    }
}