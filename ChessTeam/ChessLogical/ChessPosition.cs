namespace ChessTeam.ChessLogical;

public struct ChessPosition
{
    public int X { get; private set; } 
    public int Y { get; private set; }
    public ChessPosition(int x, int y)
    {
        if (x <= 0 || y <= 0 || x >8 || y >8)
            throw new ArgumentException("la position X, Y doit etre superieur à 0 et inferieur à 9");
        X = x;
        Y = y;
    }
    public void Reposition(int x, int y)
    {
        X = x; Y = y;
    }
}