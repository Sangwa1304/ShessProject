using ChessTeam.ChessLogical.Types;

namespace ChessTeam.ChessLogical;

public sealed class ChessCamp
{

    private static int NbreCamps = 0;
    public TypeCamp Camp { get; }
    private static bool _InitW = false;
    private static bool InitW
    {
        get
            {

            if (_InitW) return true;
            _InitW = true;
            return false;
        }
    }

    private static bool _InitB = false;
    private static bool InitB { get { if (_InitB) return true; _InitB = true; return false; } }
    private static bool Init{get => _InitB && _InitW;}
    public List<Chess> AllsPiecesForThisCamp;

    public ChessCamp()
    {
        if (NbreCamps >= 2)
            throw new Exception("Pas plus de 2 Camps permis");
        
        Camp = !_InitW && !_InitB ? TypeCamp.W : _InitW && !_InitB ? TypeCamp.B : throw new Exception("le camp est non determiner veuillez reinitialiser");

        NbreCamps++;
        AllsPiecesForThisCamp = new();
        if(Initialization())
            Conservateur.Initialisateur.Add(Camp,GetChess);
    }
    
    public IEnumerable<Chess> GetChess()
    {
        return AllsPiecesForThisCamp;
    }
    private bool Initialization()
    {
        if (Init) return true;
        List<Chess> allsPieceW =
        [
            new Chess(new ChessPosition(1,1),TypeChess.Tour,TypeCamp.W),
            new Chess(new ChessPosition(2,1),TypeChess.Cavalier,TypeCamp.W),
            new Chess(new ChessPosition(3,1),TypeChess.Fou,TypeCamp.W),
            new Chess(new ChessPosition(4,1),TypeChess.Reine,TypeCamp.W),
            new Chess(new ChessPosition(5,1),TypeChess.Roi,TypeCamp.W),
            new Chess(new ChessPosition(8,1),TypeChess.Tour,TypeCamp.W),
            new Chess(new ChessPosition(7,1),TypeChess.Cavalier,TypeCamp.W),
            new Chess(new ChessPosition(6,1),TypeChess.Fou,TypeCamp.W),
            new Chess(new ChessPosition(1,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(2,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(3,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(4,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(5,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(8,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(7,2),TypeChess.Pion,TypeCamp.W),
            new Chess(new ChessPosition(6,2),TypeChess.Pion,TypeCamp.W),
        ];
        if(!InitW)
        {
            AllsPiecesForThisCamp = allsPieceW;
            return true;
        }
        List<Chess> allsPieceB = new();

        Chess n;

        foreach (var chess in allsPieceW)
        {
            if (chess.Position.Y == 1)
            {
                n = new(new(chess.Position.X, 8), chess.Type,TypeCamp.B);
            }
            else
            {
                n = new(new(chess.Position.X, 7), chess.Type, TypeCamp.B);
            }

            allsPieceB.Add(n);
        }
        if (!InitB)
        {
            AllsPiecesForThisCamp = allsPieceW;
            return true;
        }
        return false;
    }
}

