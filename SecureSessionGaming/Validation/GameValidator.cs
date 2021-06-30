using SecureSessionGaming.Exceptions;
using SecureSessionGaming.Support.Games;

namespace SecureSessionGaming.Validation
{
    public class GameValidator
    {
        public GameValidator()
        {
        }

        public static void Validate(Game game)
        {
            if (game == null)
            {
                throw new AppException(
                    AppException.EXCEPTION_GAME_INVALID,
                    ""
                );
            }

            if (game.GetPort() == "0")
            {
                throw new AppException(
                    AppException.EXCEPTION_GAME_INVALID_GAME,
                    game.GetName()
                );
            }
        }
    }
}
