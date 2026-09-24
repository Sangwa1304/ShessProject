using System;
using System.Diagnostics;
using ChessTeam.ChessLogical;
using Xunit;

namespace ChessTeam.ChessLogical.Tests;

public class ChessTests
{
    [Fact]
    public void Chess_Pion_Verified_Promotion()
    {
        Chess.PromotionAvailabled += Chess_PromotionAvailabled;
        // Arrange
        var chess = new Chess(new(1, 7), Types.TypeChess.Pion, Types.TypeCamp.W);

        Assert.True(chess.Enabled);

        chess.Move(new(1, 8));

        Assert.True(chess.Type == Types.TypeChess.Fou);

    }

    [Fact]
    public void Chess_Update_AllsShesss_AfterMoving()
    {
        ChessCamp Camp1 = new();
        Chess.PositionChanged += Chess_PositionChanged;
        Chess.PromotionAvailabled += Chess_PromotionAvailabled;
        // Arrange
        Chess chess = new (new(1, 7), Types.TypeChess.Pion, Types.TypeCamp.W);

        Assert.True(chess.Enabled);

        chess.Move(new(1, 8));

        Assert.True(chess.Type == Types.TypeChess.Fou);

    }

    private void Chess_PositionChanged(object? sender, LastChessEventArgs e)
    {
        var newChess = sender as Chess;

        Assert.True(newChess.Position != e.Position && newChess.Camp == e.Camp);

    }

    [Fact]
    public void Chess_Reposition_Methode()
    {
        var pos = new ChessPosition(1, 1);
        var c1 = pos.ToString();

        pos.Reposition(1, 3);

        var c2 = pos.ToString();

        Assert.True(c1 != c2);
    }

    private void Chess_PromotionAvailabled(object? sender, EventArgs e)
    {
        if((sender as Chess).Promote(Types.TypeChess.Fou)) // to Fou
        {
            Debug.WriteLine($"Pion Promouvus {(sender as Chess)}");
        }
    }

    [Fact]
    public void Initialise()
    {
        ChessCamp Camp1 = new(),
            Camp2 = new();

        List<Chess> enumerables = new();
        IEnumerable<Chess> es = Conservateur.Initialisateur.AllsPiecesAtCamps;
        enumerables.AddRange(Camp1.GetChess());
        enumerables.AddRange(Camp2.GetChess());

        foreach (Chess c in enumerables)
        {
            Assert.True(es.Contains(c));
        }
    }
}