using System;
using ChessTeam.LogicalChess;

namespace ChessTeam;

public sealed class CampChess
{
    public readonly static Dictionary<TypeCamp,CampChess> Camps = new();
    private int NbreCamps = 0;
    private static bool IsWhite = true;
    public TypeCamp Camp {get;}

    public readonly List<Chess> AllsPieces;

    public CampChess(List<Chess> allsPieces)
    {
        if (NbreCamps >= 2)
            throw new Exception("Pas plus de 2 Camps permis");
        
        Camp = IsWhite? TypeCamp.W : TypeCamp.B;
        if(IsWhite)
            IsWhite = false;
        NbreCamps++;
        AllsPieces = [.. from Chess chess in allsPieces select new Chess(chess.Position,chess.Type,Camp)];
        Camps.Add(Camp,this);
    }

    internal static bool Initialization()
    {
        List<Chess> allsPieceW =
        [
            new Chess(new PositionChess(1,1),TypePiece.Tour),
            new Chess(new PositionChess(2,1),TypePiece.Cavalier),
            new Chess(new PositionChess(3,1),TypePiece.Fou),
            new Chess(new PositionChess(4,1),TypePiece.Reine),
            new Chess(new PositionChess(5,1),TypePiece.Roi),
            new Chess(new PositionChess(8,1),TypePiece.Tour),
            new Chess(new PositionChess(7,1),TypePiece.Cavalier),
            new Chess(new PositionChess(6,1),TypePiece.Fou),
            new Chess(new PositionChess(1,2),TypePiece.Pion),
            new Chess(new PositionChess(2,2),TypePiece.Pion),
            new Chess(new PositionChess(3,2),TypePiece.Pion),
            new Chess(new PositionChess(4,2),TypePiece.Pion),
            new Chess(new PositionChess(5,2),TypePiece.Pion),
            new Chess(new PositionChess(8,2),TypePiece.Pion),
            new Chess(new PositionChess(7,2),TypePiece.Pion),
            new Chess(new PositionChess(6,2),TypePiece.Pion),
        ];

        CampChess one = new(allsPieceW);

        List<Chess> allsPieceB = new();

        Chess n;

        foreach(var chess in allsPieceW)
        {
            if(chess.Position.Y == 1)
            {
                n = new(new (chess.Position.X,8),chess.Type);
            }
            else
                n = new(new (chess.Position.X,7),chess.Type);

            allsPieceB.Add(n);
        }
        
        CampChess two = new(allsPieceB);

        return true;
    }
}

