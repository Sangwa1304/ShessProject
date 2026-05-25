using System;

namespace ChessTeam.ChessLogical;

public sealed class ChessCamp
{
    public readonly static Dictionary<TypeCamp,ChessCamp> Camps = new();
    private int NbreCamps = 0;
    private static bool IsWhite = true;
    public TypeCamp Camp {get;}

    public readonly List<Chess> AllsPieces;

    public ChessCamp(List<Chess> allsPieces)
    {
        if (NbreCamps >= 2)
            throw new Exception("Pas plus de 2 Camps permis");
        
        Camp = IsWhite? TypeCamp.W : TypeCamp.B;
        if(IsWhite)
            IsWhite = false;
        NbreCamps++;
        AllsPieces = [.. from Chess chess in allsPieces select new Chess(chess.Position,chess.Type)];
        Camps.Add(Camp,this);
    }

    internal static bool Initialization()
    {
        List<Chess> allsPieceW =
        [
            new Chess(new ChessPosition(1,1),TypeChess.Tour),
            new Chess(new ChessPosition(2,1),TypeChess.Cavalier),
            new Chess(new ChessPosition(3,1),TypeChess.Fou),
            new Chess(new ChessPosition(4,1),TypeChess.Reine),
            new Chess(new ChessPosition(5,1),TypeChess.Roi),
            new Chess(new ChessPosition(8,1),TypeChess.Tour),
            new Chess(new ChessPosition(7,1),TypeChess.Cavalier),
            new Chess(new ChessPosition(6,1),TypeChess.Fou),
            new Chess(new ChessPosition(1,2),TypeChess.Pion),
            new Chess(new ChessPosition(2,2),TypeChess.Pion),
            new Chess(new ChessPosition(3,2),TypeChess.Pion),
            new Chess(new ChessPosition(4,2),TypeChess.Pion),
            new Chess(new ChessPosition(5,2),TypeChess.Pion),
            new Chess(new ChessPosition(8,2),TypeChess.Pion),
            new Chess(new ChessPosition(7,2),TypeChess.Pion),
            new Chess(new ChessPosition(6,2),TypeChess.Pion),
        ];

        ChessCamp one = new(allsPieceW);

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
        
        ChessCamp two = new(allsPieceB);

        return true;
    }
}

