using cs_console_game.Enums;
using cs_console_game.Interfaces;

namespace cs_console_game.Objects;

public class Board : IBoard
{
    private ICell[,] _boardData;
    public void CreateBoard(IBoardBuilder builder)
    {
        _boardData = builder.GetBoardData();
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

    public void SetCell(int x, int y, ICell cell)
    {
        _boardData[x, y] = cell;
    }
}