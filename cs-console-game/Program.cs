using cs_console_game.Builders;
using cs_console_game.Enums;
using cs_console_game.Interfaces;
using cs_console_game.Objects;

namespace cs_console_game;

class Program
{
    private static IBoard _board;
    private static IPlayer _player;
    static void Main(string[] args)
    {
        var builder = new BoardBuilder();
        builder.SetHeight(5);
        builder.SetWidth(10);
        builder.BuildBoard();
        builder.SetPlayer();
        builder.SetRandomTreasures(3,6);
        builder.SetRandomWalls(2,4);
        _board = new Board();
        _board.CreateBoard(builder);
        _player = new Player();
        _player.SetBoard(_board);
        Console.WriteLine(_board.DrawBoard());
        ShowStats();
        bool exit = false;

        while (!exit)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    exit = true;
                    break;
                case ConsoleKey.W:
                    MakeStep(Direction.Forward);
                    break;
                case ConsoleKey.S:
                    MakeStep(Direction.Backward);
                    break;
                case ConsoleKey.A:
                    MakeStep(Direction.Left);
                    break;
                case ConsoleKey.D:
                    MakeStep(Direction.Right);
                    break;
            }

            if (_board.GetTreasuresCount() == 0)
            {
                exit = true;
                Console.WriteLine("Поздравляем с победой!");
            }
        }
    }

    private static void MakeStep(Direction direction)
    {
        Console.Clear();
        
        try
        {
            _player.Move(direction);
            ShowBoard();
        }
        catch (Exception e)
        {
            ShowBoard();
            Console.WriteLine(e.Message);
        }
        
        ShowStats();
    }

    private static void ShowBoard()
    {
        Console.WriteLine(_board.DrawBoard());
    }

    private static void ShowStats()
    {
        Console.WriteLine("Сделано шагов: " + _player.GetSteps());
        Console.WriteLine("Собрано сокровищ: " + _player.GetTreasures());
        Console.WriteLine("Осталось собрать: " + _board.GetTreasuresCount());
    }
}