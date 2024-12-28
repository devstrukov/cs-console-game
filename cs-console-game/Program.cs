using cs_console_game.Builders;
using cs_console_game.Objects;

namespace cs_console_game;

class Program
{
    static void Main(string[] args)
    {
        var builder = new BoardBuilder();
        builder.SetHeight(5);
        builder.SetWidth(10);
        builder.BuildBoard();
        builder.SetPlayer();
        builder.SetRandomTreasures(3,6);
        builder.SetRandomWalls(2,4);
        var board = new Board();
        board.CreateBoard(builder);
        
        
        Console.WriteLine(board.DrawBoard());
    }
}