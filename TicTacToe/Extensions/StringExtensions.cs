using System.Text.RegularExpressions;

namespace TicTacToe
{
    public static class StringExtensions
    {
        public static bool UserInputIsValid(this string value)
        {
            var regex = new Regex(@"\d,\d");
            return regex.IsMatch(value);
        }
    }
}