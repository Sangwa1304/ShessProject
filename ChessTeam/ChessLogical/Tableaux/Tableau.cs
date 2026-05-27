namespace ChessTeam.ChessLogical.Tableaux;

internal class Tableau
{
    public enum Carreau
    {
        A1 = 1, A2, A3, A4, A5, A6, A7, A8,
        B1, B2, B3, B4, B5, B6, B7, B8,
        C1, C2, C3, C4, C5, C6, C7, C8,
        D1, D2, D3, D4, D5, D6, D7, D8,
        E1, E2, E3, E4, E5, E6, E7, E8,
        F1, F2, F3, F4, F5, F6, F7, F8,
        G1, G2, G3, G4, G5, G6, G7, G8,
        H1, H2, H3, H4, H5, H6, H7, H8
    }
    public static Dictionary<Carreau, ChessPosition> Carreaux { get; } = new()
    {
        // Carreau en A
        [Carreau.A1] = new(1,1),[Carreau.A2] = new(1, 2),[Carreau.A3] = new(1, 3),[Carreau.A4] = new(1, 4),[Carreau.A5] = new(1, 5),[Carreau.A6] = new(1, 6),[Carreau.A7] = new(1, 7),[Carreau.A8] = new(1, 8),
        
        // Carreau en B
        [Carreau.B1] = new(2,1),[Carreau.B2] = new(2, 2),[Carreau.B3] = new(2, 3),[Carreau.B4] = new(2, 4),[Carreau.B5] = new(2, 5),[Carreau.B6] = new(2, 6),[Carreau.B7] = new(2, 7),[Carreau.B8] = new(2, 8),
        
        // Carreau en C
        [Carreau.C1] = new(3,1),[Carreau.C2] = new(3, 2),[Carreau.C3] = new(3, 3),[Carreau.C4] = new(3, 4),[Carreau.C5] = new(3, 5),[Carreau.C6] = new(3, 6),[Carreau.C7] = new(3, 7),[Carreau.C8] = new(3, 8),
        
        // Carreau en D
        [Carreau.D1] = new(4,1),[Carreau.D2] = new(4, 2),[Carreau.D3] = new(4, 3),[Carreau.D4] = new(4, 4),[Carreau.D5] = new(4, 5),[Carreau.D6] = new(4, 6),[Carreau.D7] = new(4, 7),[Carreau.D8] = new(4, 8),
        
        // Carreau en E
        [Carreau.E1] = new(5,1),[Carreau.E2] = new(5, 2),[Carreau.E3] = new(5, 3),[Carreau.E4] = new(5, 4),[Carreau.E5] = new(5, 5),[Carreau.E6] = new(5, 6),[Carreau.E7] = new(5, 7),[Carreau.E8] = new(5, 8),
        
        // Carreau en F
        [Carreau.F1] = new(6,1),[Carreau.F2] = new(6, 2),[Carreau.F3] = new(6, 3),[Carreau.F4] = new(6, 4),[Carreau.F5] = new(6, 5),[Carreau.F6] = new(6, 6),[Carreau.F7] = new(6, 7),[Carreau.F8] = new(6, 8),

        // Carreau en G
        [Carreau.G1] = new(7,1),[Carreau.G2] = new(7, 2),[Carreau.G3] = new(7, 3),[Carreau.G4] = new(7, 4),[Carreau.G5] = new(7, 5),[Carreau.G6] = new(7, 6),[Carreau.G7] = new(7, 7),[Carreau.G8] = new(7, 8),
        
        // Carreau en H
        [Carreau.H1] = new(8,1),[Carreau.H2] = new(8, 2),[Carreau.H3] = new(8, 3),[Carreau.H4] = new(8, 4),[Carreau.H5] = new(8, 5),[Carreau.H6] = new(8, 6),[Carreau.H7] = new(8, 7),[Carreau.H8] = new(8, 8)
        
    };

    public static Carreau GetCarreau(ChessPosition position)
    {
        foreach(var car in Carreaux)
        {
            if (position.Equals(car.Value))
            {
                return car.Key;
            }
        }
        throw new ArgumentException("Pas de carreau pour cette position");
    }
    public static ChessPosition GetPosition(Carreau carreau)
    {
        return Carreaux[carreau];
    }
}