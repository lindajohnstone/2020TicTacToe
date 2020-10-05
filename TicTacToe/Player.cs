namespace TicTacToe
{
    public class Player
    {
        public int PlayerId {get; private set;}
        public string Marker {get; private set;}
        public Player(int playerId, string marker)
        {
            PlayerId = playerId;
            Marker = marker;
        }
    }
}