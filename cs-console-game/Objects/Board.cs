using cs_console_game.Enums;
using cs_console_game.Interfaces;

namespace cs_console_game.Objects;

public class Board : IBoard
{
    private ICell[,] _boardData;
    private ICell _playerCell;
    private int _treasureCount = 0;
    public void CreateBoard(IBoardBuilder builder)
    {
        _boardData = builder.GetBoardData();
        _playerCell = builder.GetPlayerCell();
        _treasureCount = builder.GetTreasuresCount();
    }

    public ICell GetPlayerCell()
    {
        return _playerCell;
    }
    public string DrawBoard()
    {
        string board = "";

        for (int i = 0; i < _boardData.GetLength(0); i++)
        {
            for (int j = 0; j < _boardData.GetLength(1); j++)
            {
                ICell cell = _boardData[i, j];
                board += DrawCell(cell);
            }
            board += "\n";
        }
        
        return board;
    }

    public string DrawCell(ICell cell)
    {
        switch (cell.GetState())
        {
            case CellState.Empty:
                return ".";
            case CellState.Treasure:
                return "T";
            case CellState.Player:
                return "P";
            case CellState.Wall:
                return "#";
        }

        return ".";
    }

    public int GetHeight()
    {
        return _boardData.GetLength(0);
    }

    public int GetWidth()
    {
        return _boardData.GetLength(1);
    }

    public ICell[,] GetBoardData()
    {
        return _boardData;
    }

    public void SetCell(int x, int y, ICell cell)
    {
        if (cell.GetState() == CellState.Treasure) _treasureCount++;
        _boardData[x, y] = cell;
    }

    public ICell GetCell(int x, int y)
    {
        return _boardData[x, y];
    }

    public int GetTreasuresCount()
    {
        return _treasureCount;
    }

    public void DecrementTreasures()
    {
        _treasureCount--;
    }
}