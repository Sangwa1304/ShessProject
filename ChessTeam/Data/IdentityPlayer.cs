using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace ChessTeam.Data
{
    public class IdentityPlayer
    {
        public IdentityPlayer( string? name = null)
        {
            string n;
            if (name != null)
                n = name;
            else
                n = HachNamePlayer;
            Name = n;
            Console.WriteLine(n);
        }

        public string Name { get; }
        public int Id { get; } = IdClass.Id;
        public static string HachNamePlayer { get => GetHachName(); }

        private static string GetHachName()
        {
            var t = new Random();
            ReadOnlySpan<char> m = [.. M()];
            return t.GetString(m,t.Next());
        }
        private static List<char> M()
        {
            var dt = "abcdefghijklmnopqrstuvwxyz123457896";
            var d = dt.ToCharArray();
            var t = dt.ToUpper().ToCharArray();
            List<char> all = [.. d];
            all = [.. t];
            return all;
        }
    }
}
