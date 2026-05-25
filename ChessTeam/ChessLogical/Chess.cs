using System;

namespace ChessTeam.ChessLogical;

public class Chess
{
    public int Id { get; } = IdChess.Id;
    public TypeChess Type { get; private set; }
    public ChessPosition Position { get;}
    public TypeCamp? Camp{ get; private set; }
    public bool Enabled { get; private set; }
    public bool Promotion { get; private set; } = false;

    public Chess(ChessPosition position, TypeChess type)
    {
        Type = type;
        Position = position;
        Enabled = true;
    }
    private void promote(TypeChess type)
    {
        if (!Promotion)
            return;
        if (Type == TypeChess.Pion && type != TypeChess.Pion && type != TypeChess.Roi)
        {
            Type = type;
            Promotion = false;
            // The Chess is promoted
        }

        // une avertissement Ici 
    }
    public void Move(ChessPosition newPosition)
    {
        Position.Reposition(newPosition.X,newPosition.Y);
        if (AtEndToPromote())
        {
            Promotion = true;
        }

        // Conderons que les verifications se font avant cette methode
    }

    private bool AtEndToPromote()
    {
        if(Camp != null && Type == TypeChess.Pion)
        {
            if(Camp ==TypeCamp.W)
            {
                if(Position.Y == 8)
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

    public void Desabled()
    {
        Enabled = false;
        GC.SuppressFinalize(this);  // Avec ça pas de retour en arriere à mettre à jour apres

    }

    public void ThereCamp(TypeCamp camp)
    {
        if (Camp != null)
            Camp = camp;

        // une avertissement Ici 

    }
}

internal class IdChess
{

    // Id Max = 8*4 = 32
    // Id Min = 1

    private static int ID { get; set; } = 0;
    public static int Id { get => ID++; }
}