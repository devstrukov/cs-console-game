using cs_console_game.Enums;

namespace cs_console_game.Interfaces;

public interface IPlayer
{
    public void SetBoard(IBoard board);
    public int GetSteps();
    public int GetTreasures();
    public void Move(Direction direction);
    public bool CanMove(Direction direction, Tuple<int, int> coordinates);
    public void IncrementSteps();
    public void IncrementTreasures();
    public ICell GetCurrentCell();
}