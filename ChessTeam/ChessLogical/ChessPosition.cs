using ChessTeam.ChessLogical.Tableaux;
using System.Collections.Generic;

namespace ChessTeam.ChessLogical;

public struct ChessPosition : IEquatable<ChessPosition>
{
    public int X { get; private set; }
    public int Y { get; private set; }

    /// <summary>
    /// Retour une instance Carreau En 2D (A1, H5,...)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <exception cref="ArgumentException"></exception>
    public ChessPosition(int x, int y)
    {
        if (x < 1 || y < 1 || x > 8 || y > 8)
            throw new ArgumentException("la position X, Y doit etre superieur à 0 et inferieur à 9");
        X = x;
        Y = y;
    }

    /// <summary>
    /// Tries les positions par ordre de X (Horizontal) ou Y(vertical)
    /// </summary>
    /// <param name="source"></param>
    /// <param name="TrieAtY"></param>
    /// <returns></returns>
    public static IEnumerable<ChessPosition> Sorts(IEnumerable<ChessPosition> source, bool TrieAtY = false)
    {
        List<ChessPosition> sortie = [];
        if (TrieAtY)
            SortY(source, ref sortie);
        else
            SortX(source, ref sortie);

        return sortie;
    }

    /// <summary>
    /// Trie par X en horizontal
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sortie"></param>
    private static void SortX(IEnumerable<ChessPosition> source, ref List<ChessPosition> sortie)
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

    /// <summary>
    /// Trie en Y en Vertical
    /// </summary>
    /// <param name="source"></param>
    /// <param name="sortie"></param>
    private static void SortY(IEnumerable<ChessPosition> source, ref List<ChessPosition> sortie)
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

    /// <summary>
    /// Ceci retour un Format { position X : Position Y: la carreau reprensant la position sur le tableau }
    /// </summary>
    /// <returns></returns>
    public override readonly string ToString()
    {
        return $" X :{X} Y : {Y} : {Tableau.GetCarreau(this)}";
    }

    /// <summary>
    /// Methode Utiliser pour les tests, elle est temporaire pour test un deplacement
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
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

    public override readonly int GetHashCode()
    {
        return HashCode.Combine(X,Y);
    }

    readonly bool IEquatable<ChessPosition>.Equals(ChessPosition other)
    {
        return Equals(other);
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
