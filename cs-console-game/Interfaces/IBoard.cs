namespace cs_console_game.Interfaces;

public interface IBoard
{
    public void CreateBoard(IBoardBuilder builder);
    public string DrawBoard();
    public string DrawCell(ICell cell);
    public int GetHeight();
    public int GetWidth();
    public ICell GetPlayerCell();
    public void SetCell(int x, int y, ICell cell);
    public ICell GetCell(int x, int y);
}