namespace MovieApi.Extensions;

public static class InputValidationExtension
{
    public static bool HasInvalidCharacters(this string input)
    {
        string[] invalidCharacters = { ";", "--", "/*", "*/", "@@", "'", "\"", "exec", "sp_", "xp_", "sysobjects", "syscolumns" };

        foreach (var character in invalidCharacters)
        {
            if (input.Contains(character))
                return true;
        }

        return false;
    }
}