using ChessTeam.User;
using ChessTeam.ChessLogical;
using ChessTeam.ChessMoving;

namespace ChessTeam;

internal class Program
{
    public delegate List<ChessPosition> Fonc(TypeCamp camp, ChessPosition position);
    private static void Main(String[]args )
    {

        for(int i = 0; i < 20; i++)
        {
            var t = new IdentityPlayer();
            Console.WriteLine($"  Name : {t.Name}   Id :{t.Id}");
        }
    }
}