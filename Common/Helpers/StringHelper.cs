
namespace Common.Helpers
{
    public static class StringHelper
    {
        public static string GetNameAfterCharacter(string sentence, char character)
        {
            return sentence.Substring(sentence.IndexOf(character) + 1).Trim();
        }
    }
}
