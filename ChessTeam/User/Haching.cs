namespace ChessTeam.User;

internal static class Haching
{
    public static string GetHach(bool nb = false)
    {

        var t = new Random();
        ReadOnlySpan<char> m = [.. M(nb)];
        return t.GetString(m, 5);
    }
    private static List<char> M(bool mode = false)
    {
        const string dt = "abcdefghijklmnopqrstuvwxyz";
        char[] chars = "123457896".ToCharArray();
        var nb = chars;
        if (mode)
            return [.. nb];
        var d = dt.ToCharArray();
        var t = dt.ToUpper().ToCharArray();
        List<char> all = [.. d];
        Add(t, ref all);
        if (!mode)
            Add(nb, ref all);
        return all;
    }

    private static void Add(char[] nb, ref List<char> all)
    {
        all.AddRange(nb);
    }
}
