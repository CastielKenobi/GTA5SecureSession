namespace SecureSessionGaming.Support.Games
{
    public interface Game
    {
        string GetName();

        string GetPort();
        
        int GetProtocol();
    }
}
