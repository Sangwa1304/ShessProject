using ChessTeam.User;
using ChessTeam.ChessLogical;
using ChessTeam.ChessMoving;

namespace ChessTeam;

internal class Program
{
    public delegate List<ChessPosition> Fonc(TypeCamp camp, ChessPosition position);
    private static void Main(String[]args )
    {
        //test();


    }

    /*
    private static void test()
    {
        
        foreach (var position in Moving.RunFonc(TypeChess.Cavalier, TypeCamp.W, new(4, 4)))
        {
            Console.WriteLine(position);
        }
        
        if (ChessCamp.Initialization())
        {
            foreach (var camp in ChessCamp.AllsPiecesAtCamps)
            {
                Console.WriteLine($"{camp.Key} : ");
                foreach (var chess in camp.Value.AllsPiecesForThisCamp)
                {
                    Console.WriteLine(chess);
                }

            }
        }
    
        foreach (var position in Moving.RunFonc(TypeChess.Roi, TypeCamp.B, new(3, 5)))
        {
            Console.WriteLine(position);
        }
    */
}