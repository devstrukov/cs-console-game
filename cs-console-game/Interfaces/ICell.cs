using cs_console_game.Enums;

namespace cs_console_game.Interfaces;

public interface ICell
{
    public CellState GetState();
    public void SetState(CellState state);
    public void SetCoordinates(Tuple<int, int> coordinates);
    public Tuple<int, int> GetCoordinates();
    public bool CanBeOccupied();
}