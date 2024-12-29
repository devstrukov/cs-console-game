using cs_console_game.Enums;
using cs_console_game.Exceptions;
using cs_console_game.Helpers;
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
        _cell = board.GetPlayerCell();
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

    public bool CanMove(Direction direction, Tuple<int, int> coordinates)
    {
        switch (direction)
        {
            case Direction.Forward:
                return coordinates.Item1 >= 0;
            case Direction.Backward:
                return coordinates.Item1 < _board.GetHeight();
            case Direction.Left:
                return coordinates.Item2 >= 0;
            case Direction.Right:
                return coordinates.Item2 < _board.GetWidth();
            default:
                return false;
        }
    }

    public Tuple<int, int> GetNewCoordinates(ICell previousCell, Direction direction)
    {
        Tuple<int, int> coordinates = previousCell.GetCoordinates();
        
        switch (direction)
        {
            case Direction.Backward:
                return new Tuple<int, int>(coordinates.Item1 + 1, coordinates.Item2);
            case Direction.Forward:
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
        IncrementSteps();
        
        ICell cell = GetCurrentCell();
        Tuple<int, int> newCoordinates = GetNewCoordinates(cell, direction);
        if (!CanMove(direction, newCoordinates)) ShowBlockError();
        
        ICell nextCell = _board.GetCell(newCoordinates.Item1, newCoordinates.Item2);
        
        if (nextCell.GetState() == CellState.Wall) ShowBlockError();
        
        Tuple<int, int> coordinates = cell.GetCoordinates();
        cell.SetState(CellState.Empty);
        _board.SetCell(coordinates.Item1, coordinates.Item2, cell);
        ICell playerCell = new Cell();
        playerCell.SetState(CellState.Player);
        _board.SetCell(newCoordinates.Item1, newCoordinates.Item2, playerCell);
        _cell.SetCoordinates(newCoordinates);

        if (nextCell.GetState() == CellState.Treasure)
        {
            IncrementTreasures();
            _board.DecrementTreasures();
        }

        if (_steps % 5 == 0)
        {
            ICell treasureCell = new Cell();
            treasureCell.SetState(CellState.Treasure);
            Tuple<int, int> randomCoordinates = CellsHelper.GetFreeCellCoordinates(_board.GetBoardData());
            _board.SetCell(randomCoordinates.Item1, randomCoordinates.Item2, treasureCell);
        }
    }

    private void ShowBlockError()
    {
        throw new PlayerCantMoveException("Игрок не может двигаться в этом направлении");
    }
}