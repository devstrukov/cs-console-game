using cs_console_game.Enums;
using cs_console_game.Exceptions;
using cs_console_game.Interfaces;

namespace cs_console_game.Objects;

public class Player : IPlayer
{
    IBoard _board;
    ICell _cell;
    private int _steps;
    private int _treasures;
    public void SetBoard(IBoard board)
    {
        _board = board;
    }

    public ICell GetCurrentCell()
    {
        return _cell;
    }

    public void IncrementSteps()
    {
        _steps++;
    }

    public void IncrementTreasures()
    {
        _treasures++;
    }

    public int GetTreasures()
    {
        return _treasures;
    }

    public int GetSteps()
    {
        return _steps;
    }

    public bool CanMove(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                return _cell.GetCoordinates().Item1 > 0;
            case Direction.Backward:
                return _cell.GetCoordinates().Item1 < _board.GetHeight();
            case Direction.Left:
                return _cell.GetCoordinates().Item2 > 0;
            case Direction.Right:
                return _cell.GetCoordinates().Item2 < _board.GetWidth();
            default:
                return false;
        }
    }

    public Tuple<int, int> GetNewCoordinates(ICell previousCell, Direction direction)
    {
        Tuple<int, int> coordinates = previousCell.GetCoordinates();
        
        switch (direction)
        {
            case Direction.Forward:
                return new Tuple<int, int>(coordinates.Item1 + 1, coordinates.Item2);
            case Direction.Backward:
                return new Tuple<int, int>(coordinates.Item1 - 1, coordinates.Item2);
            case Direction.Left:
                return new Tuple<int, int>(coordinates.Item1, coordinates.Item2 - 1);
            case Direction.Right:
                return new Tuple<int, int>(coordinates.Item1, coordinates.Item2 + 1);
        }
        
        return coordinates;
    }

    public void Move(Direction direction)
    {
        if (!CanMove(direction)) throw new PlayerCantMoveException("Can't move this direction");
        
        IncrementSteps();
        
        ICell cell = GetCurrentCell();
        Tuple<int, int> coordinates = cell.GetCoordinates();
        cell.SetState(CellState.Empty);
        _board.SetCell(coordinates.Item1, coordinates.Item2, cell);
        
        Tuple<int, int> newCoordinates = GetNewCoordinates(cell, direction);
        ICell playerCell = new Cell();
        playerCell.SetState(CellState.Player);
        _board.SetCell(newCoordinates.Item1, newCoordinates.Item2, playerCell);
    }
}