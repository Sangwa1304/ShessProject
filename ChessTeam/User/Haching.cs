namespace ChessTeam.User
{
    
    internal class Haching
    {
        public static string GetHach(bool nb = false)
        {
                
            var t = new Random();
            if(nb)
                return t.Next(4).ToString();
           
            ReadOnlySpan<char> m = [.. M()];
            return t.GetString(m, 5);
        }
        private static List<char> M(bool mode = false)
        {
            var dt = "abcdefghijklmnopqrstuvwxyz";
            var nb = "123457896".ToCharArray();
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
            foreach (var l in nb)
            {
                all.Add(l);
            }
        }
    }
}
