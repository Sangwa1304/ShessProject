using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace ChessTeam.User
{
    public partial class IdentityPlayer
    {
        public IdentityPlayer( string? name = null)
        {
            string n;
            if (name != null)
                n = name;
            else
                n = HachNamePlayer;
            Name = n;
        }

        public string Name { get; private set; }
        public int Id { get; } = IdClass.Id;
        public static string HachNamePlayer { get => "Player_"+Haching.GetHach(); }
    }
}
