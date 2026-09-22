using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace ChessTeam.User;

public partial class IdentityPlayer(string? name = null)
{
    public string Name { get; private set; }= name ?? HachNamePlayer;
    public int Id { get => Name.GetHashCode(); }
    private static string HachNamePlayer { get => "Player_" + Haching.GetHach(); }
}
