namespace cs_console_game.Interfaces;

public interface IBoard
{
    public void CreateBoard(IBoardBuilder builder);
    public string DrawBoard();
    public string ShowStatistics(IPlayer player);
    public void RedrawBoard(IPlayer player);
}