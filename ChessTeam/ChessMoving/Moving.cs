using System;
using System.Collections.Generic;
using System.Text;
using ChessTeam.ChessLogical;
using ChessTeam.ChessLogical.Types;

namespace ChessTeam.ChessMoving;

/// <summary>
/// Containers de methodes 
/// </summary>
public static class Moving
{
    
    /// <summary>
    /// Container des fonctions dependament de leur Type
    /// </summary>
    private static readonly Dictionary<TypeChess, Func<TypeCamp?, ChessPosition, IEnumerable<ChessPosition>>> Fonctions = new()
    {
        [TypeChess.Pion] = Pion,
        [TypeChess.Roi] = Roi,
        [TypeChess.Reine] = Reine,
        [TypeChess.Cavalier] = Cavalier,
        [TypeChess.Tour] = Tour,
        [TypeChess.Fou] = Fou
    };

    /// <summary>
    /// Retourne les prochaines positions d'une Shess en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="type"></param>
    /// <param name="camp"></param>
    /// <param name="position"></param>
    /// <returns></returns>
    public static IEnumerable<ChessPosition> GetNextPositions(TypeChess type, TypeCamp? camp, ChessPosition position)
    {
        try
        {
            return ChessPosition.Sorts(Fonctions[type](camp, position)); 
        }
        catch(Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Retourne les prochaines positions d'un pion en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="pion"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static IEnumerable<ChessPosition> Pion(TypeCamp? camp, ChessPosition pion)
    {

        List<ChessPosition> all = [];
        if (camp == null)
            throw new ArgumentException("La valeur null non permis pour les pions");
        if (camp == TypeCamp.W)
        {

            // the roque 
            TryAdd(pion.X + 1, pion.Y + 1, ref all);
            TryAdd(pion.X - 1, pion.Y + 1, ref all);

            TryAdd(pion.X, pion.Y + 2, ref all);
            TryAdd(pion.X, pion.Y + 1, ref all);
        }
        else
        {
            // the roque 
            TryAdd(pion.X - 1, pion.Y - 1, ref all);
            TryAdd(pion.X + 1, pion.Y - 1, ref all);

            TryAdd(pion.X, pion.Y - 2, ref all);
            TryAdd(pion.X, pion.Y + 1, ref all);
        }
        return all;
        //mm
    }

    /// <summary>
    /// Retourne les prochaines positions d'un cavalier en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="cavalier"></param>
    /// <returns></returns>
    private static IEnumerable<ChessPosition> Cavalier(TypeCamp? camp, ChessPosition cavalier)
    {
        List<ChessPosition> all = [];

        // en X :
        TryAdd(cavalier.X + 2, cavalier.Y + 1, ref all);
        TryAdd(cavalier.X + 2, cavalier.Y - 1, ref all);
        // en Y :
        TryAdd(cavalier.X + 1, cavalier.Y + 2, ref all);
        TryAdd(cavalier.X - 1, cavalier.Y + 2, ref all);
        // en X Y up:
        TryAdd(cavalier.X - 2, cavalier.Y + 1, ref all);
        TryAdd(cavalier.X - 2, cavalier.Y - 1, ref all);
        // en X Y Inverse:
        TryAdd(cavalier.X - 1, cavalier.Y - 2, ref all);
        TryAdd(cavalier.X + 1, cavalier.Y - 2, ref all);

        return all;
        //mm code
    }

    /// <summary>
    /// retourne en reference une suite des prochaines positions en fonction d'une position de base et
    ///  un parametre d'ajout (Tuple<>)
    /// </summary>
    /// <param name="iteration"></param>
    /// <param name="value"></param>
    /// <param name="position"></param>
    /// <param name="container"></param>
    private static void Iterate(int iteration, Tuple<int, int> value, ChessPosition position, ref List<ChessPosition> container)
    {
        ChessPosition p = position;
        for (int i = 0; i < iteration; i++)
        {
            if (TryAdd(p.X + value.Item1, p.Y + value.Item2, ref container))
            {
                p = new(p.X + value.Item1, p.Y + value.Item2);
            }
        }
    }

    /// <summary>
    /// Retourne les prochaines positions d'une reine en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="reine"></param>
    /// <returns></returns>
    private static IEnumerable<ChessPosition> Reine(TypeCamp? camp, ChessPosition reine)
    {
        List<ChessPosition> all = [];
        Transfert(Roi(camp, reine), ref all);
        Transfert(Fou(camp, reine), ref all);
        Transfert(Tour(camp, reine), ref all);
        return all;
        //mm code
    }

    /// <summary>
    /// Retourne les prochaines positions d'un roi en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="roi"></param>
    /// <returns></returns>
    private static IEnumerable<ChessPosition> Roi(TypeCamp? camp, ChessPosition roi)
    {
        List<ChessPosition> all = [];
        // en X :
        TryAdd(roi.X + 1, roi.Y, ref all);
        TryAdd(roi.X - 1, roi.Y, ref all);
        // en Y :
        TryAdd(roi.X, roi.Y + 1, ref all);
        TryAdd(roi.X, roi.Y - 1, ref all);
        // en X Y up :
        TryAdd(roi.X + 1, roi.Y + 1, ref all);
        TryAdd(roi.X - 1, roi.Y - 1, ref all);
        // en X Y Inverse :
        TryAdd(roi.X - 1, roi.Y + 1, ref all);
        TryAdd(roi.X + 1, roi.Y - 1, ref all);

        // permutation sous condition 
        TryAdd(roi.X - 2, roi.Y, ref all);
        TryAdd(roi.X + 2, roi.Y, ref all);
        return all;
        //mm code
    }

    /// <summary>
    /// Retourne les prochaines positions d'un fou en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="fou"></param>
    /// <returns></returns>
    private static IEnumerable<ChessPosition> Fou(TypeCamp? camp, ChessPosition fou)
    {
        List<ChessPosition> all = [];

        Iterate(8, new(1, 1), fou, ref all);
        Iterate(8, new(-1, -1), fou, ref all);
        Iterate(8, new(1, -1), fou, ref all);
        Iterate(8, new(-1, 1), fou, ref all);

        return all;
        //mm code
    }

    /// <summary>
    /// Retourne les prochaines positions d'un tour en fonction de son camp et sa postion de depart
    /// </summary>
    /// <param name="camp"></param>
    /// <param name="tour"></param>
    /// <returns></returns>
    private static IEnumerable<ChessPosition> Tour(TypeCamp? camp, ChessPosition tour)
    {
        List<ChessPosition> all = [];
        Iterate(8, new(-1, 0), tour, ref all);
        Iterate(8, new(1, 0), tour, ref all);
        Iterate(8, new(0, 1), tour, ref all);
        Iterate(8, new(0, -1), tour, ref all);
        return all;
        //mm code
    }

    /// <summary>
    /// methode de soutien pour tenter l'ajout d'une position dans une liste
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="container"></param>
    /// <returns></returns>
    private static bool TryAdd(int x, int y, ref List<ChessPosition> container)
    {
        try
        {
            container.Add(new(x, y));
            return true;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    /// <summary>
    /// methode de soutien pour fusionner deux list
    /// </summary>
    /// <param name="ancien"></param>
    /// <param name="container"></param>
    private static void Transfert(IEnumerable<ChessPosition> ancien, ref List<ChessPosition> container)
    {
        container.AddRange(ancien);
    }
}
