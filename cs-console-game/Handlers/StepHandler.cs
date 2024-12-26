using cs_console_game.Enums;
using cs_console_game.Exceptions;
using cs_console_game.Interfaces;

namespace cs_console_game.Handlers;

public class StepHandler
{
    public static void HandleStep(IPlayer player, ICell cell, IBoard board)
    {
        if (!cell.CanBeOccupied())
        {
            throw new PlayerCantMoveException("Can't move to the cell");
        }
        
        player.IncrementSteps();

        if (cell.GetState() == CellState.Treasure)
        {
            player.IncrementTreasures();
            cell.SetState(CellState.Empty);
        }
        
        board.RedrawBoard(player);
    }
}