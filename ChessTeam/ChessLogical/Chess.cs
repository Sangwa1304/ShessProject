using System;
using ChessTeam.ChessLogical.Types;
using ChessTeam.ChessMoving;

namespace ChessTeam.ChessLogical;

public class Chess : IEquatable<Chess>
{
    public int Id { get; } = IdChess.Id;
    public TypeChess Type { get; private set; }
    public ChessPosition Position { get; private set; }
    public static event EventHandler? PromotionAvailabled;
    public static event EventHandler<LastChessEventArgs>? PositionChanged;
    public TypeCamp Camp { get; private set; }
    public bool Enabled { get; private set; }
    private bool _Promotion  = true;
    public bool Promotion { get => _Promotion; private set
        {
            if(!_Promotion)
            {
                return;
            }
            _Promotion = value;
        }
    }
    public List<ChessPosition> NextPositions { get => Nexts(); }

    private List<ChessPosition> Nexts()
    {
        var p = Moving.GetNextPositions(Type, Camp, Position);
        var Alies = GetAnotherChessPositionsFromThisCamp();
        return [..from e in p where !Alies.Contains(e) select e];
    }

    private IEnumerable<> Cibles()
    {
        var p = Moving.GetNextPositions(Type, Camp, Position);
        var ennemy = GetAnotherChessPositionsFromEnnemyCamp();
        return [..from e in p where ennemy.Contains(e) select e];
    }
    public Chess(ChessPosition position, TypeChess type, TypeCamp camp)
    {
        Type = type;

        Position = position;

        Enabled = true;

        Camp = camp;
        if (type != TypeChess.Pion)
        {
            Promotion = false;
        }
    }

    public override string ToString()
    {
        return $"{Type} : {Position}";
        
    }
    public bool Promote(TypeChess type)
    {
        if (!Promotion)
            return false;
        if (Type == TypeChess.Pion && type != TypeChess.Pion && type != TypeChess.Roi)
        {
            Type = type;
            Promotion = false;
            return true;
            // The Chess is promoted
        }
        return false;
        // une avertissement Ici 
    }
    public void Move(ChessPosition newPosition)
    {
        var memory = new LastChessEventArgs(Camp,Type,Position);

        if(!NextPositions.Contains(newPosition))
        {
            throw new ArgumentException(nameof(newPosition));
        }
        //Position.Reposition(newPosition.X, newPosition.Y);
        Position = newPosition;
        if (AtEndToPromote())
        {
            Promotion = true;
            PromotionAvailabled?.Invoke(this,new());
        }
        PositionChanged?.Invoke(this,memory);
    }

    private IEnumerable<ChessPosition> GetAnotherChessPositionsFromThisCamp()
    {
        return [.. from e in Conservateur.Initialisateur.AllsPiecesForCamp(Camp) select e.Position];
    }

    private IEnumerable<ChessPosition> GetAnotherChessPositionsFromEnnemyCamp()
    {
        
        return [.. from e in Conservateur.Initialisateur.AllsPiecesForCamp(Camp == TypeCamp.W ? TypeCamp.B: TypeCamp.W) select e.Position];
    }

    private IEnumerable<ChessPosition> GetAllsAnotherChessPositions()
    {
        return [.. from e in Conservateur.Initialisateur.AllsPiecesAtCamps select e.Position];
    }

    private bool AtEndToPromote()
    {
        if (Type == TypeChess.Pion)
        {
            if (Camp == TypeCamp.W)
            {
                if (Position.Y == 8)
                {
                    return true;
                }
            }
            else
            {
                if (Position.Y == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void Denabled()
    {
        Enabled = false;
        GC.SuppressFinalize(this);  // Avec �a pas de retour en arriere � mettre � jour apres

    }

    public override bool Equals(object? obj)
    {
        return obj is Chess chess &&
               Type == chess.Type &&
               Position.Equals(chess.Position);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Position);
    }

    public bool Equals(Chess? other)
    {
        return  GetHashCode() == other?.GetHashCode();
    }
}

public record LastChessEventArgs(TypeCamp Camp, TypeChess Type,ChessPosition Position );

internal static class IdChess
{

    // Id Max = 8*4 = 32
    // Id Min = 1

    private static int ID { get; set; } = 0;
    public static int Id { get => ID++; }
}