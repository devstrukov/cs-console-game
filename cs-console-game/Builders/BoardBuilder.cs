using cs_console_game.Enums;
using cs_console_game.Interfaces;
using cs_console_game.Objects;

namespace cs_console_game.Builders;

public class BoardBuilder : IBoardBuilder
{
    private int _width;
    private int _height;
    private ICell[,] _board;
    
    public void SetWidth(int width)
    {
        _width = width;
    }
    public void SetHeight(int height)
    {
        _height = height;
    }

    public void SetPlayer()
    {
        Tuple<int, int> freeCellCoordinates = GetFreeCellCoordinates();
        _board[freeCellCoordinates.Item1, freeCellCoordinates.Item2]
            .SetState(CellState.Player);
    }

    public void BuildBoard()
    {
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                ICell cell = new Cell();
                cell.SetState(CellState.Empty);
                cell.SetCoordinates(new Tuple<int, int>(i, j));
                _board[i, j] = cell;
            }
        }
    }

    public void SetRandomTreasures(int min, int max)
    {
        SetRandomItems(min, max, CellState.Treasure);
    }

    public void SetRandomWalls(int min, int max)
    {
        SetRandomItems(min, max, CellState.Wall);
    }

    private void SetRandomItems(int min, int max, CellState cellType)
    {
        Random rnd = new Random();
        int itemsToCreate = rnd.Next(min, max);
        int totalItems = 0;

        if (itemsToCreate > CanCreateSpecificCellsCount())
        {
            itemsToCreate = CanCreateSpecificCellsCount();
        }

        while (totalItems < itemsToCreate)
        {
            Tuple<int, int> randomCell = GetFreeCellCoordinates();
            ICell cell = _board[randomCell.Item1, randomCell.Item2];
            cell.SetState(cellType);
            totalItems++;
        }
    }

    private int GetTotalCells()
    {
        return _width * _height;
    }

    private int CanCreateSpecificCellsCount()
    {
        return GetTotalCells() / 3;
    }

    private Tuple<int, int> GetFreeCellCoordinates()
    {
        while (true)
        {
            Random rnd = new Random();
            int x = rnd.Next(0, _width);
            int y = rnd.Next(0, _height);
            
            ICell cell = _board[x, y];
            
            if (cell.CanBeOccupied()) return Tuple.Create(x, y);
        }
    }

    public ICell[,] GetBoardData()
    {
        return _board;
    }
}