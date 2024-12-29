namespace cs_console_game.Exceptions;

public class PlayerCantMoveException : Exception
{
    public PlayerCantMoveException(string message) : base(message) {}
}