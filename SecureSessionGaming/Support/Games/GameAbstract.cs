using System.Collections.Generic;

namespace SecureSessionGaming.Support.Games
{
    public abstract class GameAbstract : Game
    {
        public string name;

        protected string port;

        protected int protocol;

        public GameAbstract()
        {
        }

        public string GetName()
        {
            return name;
        }

        public string GetPort()
        {
            return port;
        }

        public int GetProtocol()
        {
            return protocol;
        }

        // 
        public static Game FromString(string gameName)
        {
            Game game;
            switch (gameName)
            {
                case GrandTheftAuto5.NAME:
                    game = new GrandTheftAuto5();
                    break;
                case RedDeadRedemption2.NAME:
                    game = new RedDeadRedemption2();
                    break;
                default:
                    game = new NoGame();
                    break;
            }
            return game;
        }

        // For UI
        public static List<string> GetAll()
        {
            List<string> games = new List<string>();
            games.Add(GrandTheftAuto5.NAME);
            games.Add(RedDeadRedemption2.NAME);
            return games;
        }

        // On close app
        public static List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            games.Add(new GrandTheftAuto5());
            games.Add(new RedDeadRedemption2());
            return games;
        }
    }
}