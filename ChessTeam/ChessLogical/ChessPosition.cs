using ChessTeam.ChessLogical.Tableaux;
using System.Collections.Generic;

namespace ChessTeam.ChessLogical;

public struct ChessPosition
{
    public int X { get; private set; } 
    public int Y { get; private set; }
    public ChessPosition(int x, int y)
    {
        if (x < 1 || y < 1 || x >8 || y >8)
            throw new ArgumentException("la position X, Y doit etre superieur � 0 et inferieur � 9");
        X = x;
        Y = y;
    }
    public static List<ChessPosition> Sorts(List<ChessPosition> source, bool XorY = false)
    {
        List<ChessPosition> sortie = [];
        if(XorY)
            SortY(source,ref  sortie);
        else
            SortX(source, ref sortie);
        
        return sortie;
    }

    private static void SortX(List<ChessPosition> source, ref List<ChessPosition> sortie)
    {
        for (int i = 1; i < 9; i++)
        {
            foreach (ChessPosition c in source)
            {
                if (c.X == i)
                    sortie.Add(c);
            }
        }
    }
    private static void SortY(List<ChessPosition> source, ref List<ChessPosition> sortie)
    {
        for (int i = 1; i < 9; i++)
        {
            foreach (ChessPosition c in source)
            {
                if (c.Y == i)
                    sortie.Add(c);
            }
        }
    }

    public override readonly string ToString()
    {
        return $" X :{X} Y : {Y} : {Tableau.GetCarreau(this)}";
    }
    public void Reposition(int x, int y)
    {
        X = x; Y = y;
    }

    public override readonly bool Equals(object? obj)
    {
        return obj is ChessPosition position &&
               X == position.X &&
               Y == position.Y;
    }

    public static bool operator ==(ChessPosition left, ChessPosition right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ChessPosition left, ChessPosition right)
    {
        return !(left == right);
    }
}
