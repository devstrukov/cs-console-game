using cs_console_game.Enums;
using cs_console_game.Interfaces;

namespace cs_console_game.Objects;

public class Cell : ICell
{
    CellState _state = CellState.Default;
    Tuple<int, int> _coordinates;
    public void SetState(CellState state)
    {
        _state = state;
    }

    public CellState GetState()
    {
        return _state;
    }

    public void SetCoordinates(Tuple<int, int> coordinates)
    {
        _coordinates = coordinates;
    }

    public Tuple<int, int> GetCoordinates()
    {
        return _coordinates;
    }

    public bool CanBeOccupied()
    {
        return _state == CellState.Empty;
    }
}