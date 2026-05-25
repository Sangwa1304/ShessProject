using System;

namespace LogicalShess.DataShess;

public class Chess
{
    private static int ID { get => ID++;set;} = 0;
    public int Id { get;}
    public TypeCamp? Camp{get;}
    public TypePiece Type { get; private set; }

    public PositionChess Position { get; private set;}

    public Chess(PositionChess position, TypePiece type,TypeCamp? camp = null)
    {
        Type = type;
        Id = ID;
        Position = position;
        if(camp != null)
        {
            Camp = camp;
        }
    }
}
