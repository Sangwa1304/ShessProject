using LogicalShess.DataShess;

namespace LogicalShess;

internal class Program
{
    private static void Main(String[]args )
    {
        bool CampsIsReady = CampChess.Initialization();
        Console.WriteLine("I am Ready");
    }
}