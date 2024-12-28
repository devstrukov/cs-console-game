namespace cs_console_game.Interfaces;

public interface IBoardBuilder
{
    public void SetWidth(int width);
    public void SetHeight(int height);
    public void SetRandomTreasures(int min, int max);
    public void SetRandomWalls(int min, int max);
    public void SetPlayer();
    public void BuildBoard();
    public ICell[,] GetBoardData();
    public ICell GetPlayerCell();
}