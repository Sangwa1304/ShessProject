using System;
using ChessTeam.ChessLogical.Types;
using ChessTeam.ChessMoving;
using static ChessTeam.ChessLogical.Tableaux.Tableaux;

namespace ChessTeam.ChessLogical;

public class Chess : IEquatable<Chess>
{
    public bool SpecialPropertyRoque { get; private set; } = false;
    private static Chess? LastMoveChess;
    private ChessPosition? LastPosition;
    private bool _isMove = false; // property for roi et tour 
    public bool IsMove { get => _isMove; }
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
        var p = Moving.GetNextPositions(Type, Camp, Position).ToList();
        var Alies = GetAnotherChessPositionsFromThisCamp();
        if(Type== TypeChess.Pion) VerifieRoqueForPion(ref p);
        if (Type == TypeChess.Roi) VerifieSpecialPermutation(ref p);
        return [..from e in p where !Alies.Contains(e) select e];
    }

    private void VerifieSpecialPermutation(ref List<ChessPosition> p)
    {
        if (!IsMove)
        {
            return; 
        }

    }

    private void VerifieRoqueForPion(ref List<ChessPosition> p)
    {
        List<ChessPosition> pos = new(),
            direct = new();
        int v = Camp == TypeCamp.W ? 1 : -1;
        try
        {
            pos.Add(new(Position.X - 1, Position.Y + v));
        }
        catch(Exception)
        { }
        try
        { 
            pos.Add(new(Position.X + 1, Position.Y + v)); 
        }
        catch (Exception) { }
        try
        {
            direct.Add(new(Position.X - 1, Position.Y));
        }
        catch (Exception) { }
        try
        {
            direct.Add(new(Position.X + 1, Position.Y));
        }
        catch (Exception) { }

        if (LastMoveChess == null || LastMoveChess.LastPosition== null) 
        {
            DeleteRoque(pos, ref p);
             return;
        }
        else
        {
            if (LastMoveChess.Type == TypeChess.Pion && IsEnnemy(LastMoveChess) &&
                (LastMoveChess.LastPosition?.Y == LastMoveChess.Position.Y + 2 ||
                    LastMoveChess.LastPosition?.Y == LastMoveChess.Position.Y - 2))
            {
                foreach(var ps in direct)
                {
                    if(LastMoveChess.Position == ps)
                    {
                        DeleteRoque(pos, ref p,ps);
                        return;
                    }
                }
            }
            DeleteRoque(pos, ref p);
            return;
            
        }
    }

    private void DeleteRoque(List<ChessPosition> direct, ref List<ChessPosition> p, 
        ChessPosition? except = null)
    {
        foreach(var po in direct)
        {
            try
            {
                if (except != null && po == except) continue;
                p.Remove(po);
            }
            catch(Exception)
            {

            }
        }
    }

    private bool IsEnnemy(Chess lastMoveChess)
    {
        return lastMoveChess.Camp == Camp;
    }

    private IEnumerable<ChessPosition> Cibles()
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
    public void Move(ChessPosition? position = null, Carreau? carreau =null)
    {
        ChessPosition newPosition;
        if (position == null && carreau == null) return;
        if(carreau != null)
        {
            newPosition = Tableaux.Tableaux.GetPosition(carreau:carreau);
        }
        else
        {
            newPosition = position?? throw new ArgumentNullException(nameof(position));
        }
        var memory = new LastChessEventArgs(Camp,Type,Position);

        if(!NextPositions.Contains(newPosition))
        {
            return;
        }
        //Position.Reposition(newPosition.X, newPosition.Y);
        Position = newPosition;
        if (AtEndToPromote())
        {
            Promotion = true;
            PromotionAvailabled?.Invoke(this,new());
        }

        LastPosition = memory.Position;
        LastMoveChess = this;
        _isMove = true;

        var task = Task.Run(() => 
        {
            Conservateur.Initialisateur.Informechange(Tableaux.Tableaux.GetCarreau(Position), Tableaux.Tableaux.GetCarreau(memory.Position));
            PositionChanged?.Invoke(this, memory); 
        });
    }

    public IEnumerable<ChessPosition> GetAnotherChessPositionsFromThisCamp()
    {
        return [.. from e in Conservateur.Initialisateur.AllsPiecesForCamp(Camp) select e.Position];
    }

    public IEnumerable<ChessPosition> GetAnotherChessPositionsFromEnnemyCamp()
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