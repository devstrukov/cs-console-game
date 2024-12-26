using cs_console_game.Enums;

namespace cs_console_game.Interfaces;

public interface IPlayer
{
    public int GetSteps();
    public int GetTreasures();
    public void Move(Direction direction);
    public bool CanMove(Direction direction);
    public void IncrementSteps();
    public void IncrementTreasures();
    public ICell GetCurrentCell();
    public ICell GetPreviousCell();
}