namespace TicTacToe
{
    public class Result
    {
        public bool Success {get; set;}
        public string ErrorMessage {get; set;}
        public Result(bool isSuccessful, string error)
        {
            Success = isSuccessful;
            ErrorMessage = error;
        }
    }
}