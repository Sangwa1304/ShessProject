using System;
using System.Collections.Generic;
using System.Text;
using ChessTeam.ChessLogical.Types;
using static ChessTeam.ChessLogical.Tableaux.Tableaux;

namespace ChessTeam.ChessLogical;

public static class Conservateur
{

    public static class Initialisateur
    {
        private static readonly Dictionary<TypeCamp,Func<IEnumerable<Chess>>> _AllsPiecesAtCamps = [];
        private static readonly Dictionary<Carreau, Func<CarreauElement>> _AllButtonCarreau = [];

        public static void Informechange(Carreau carreauOrigine,Carreau carreauDestination)
        {
            try
            {
                _AllButtonCarreau[carreauOrigine]()?.ChessObject ="";
                _AllButtonCarreau[carreauDestination]();
            }
            catch(Exception)
            { }
        }
        public  static void DisableButtons(IEnumerable<ChessPosition> excepts)
        {
            foreach(var car in _AllButtonCarreau)
            {
                if (excepts.Contains(Tableaux.Tableaux.GetPosition(carreau: car.Key)))
                {
                    _AllButtonCarreau[car.Key]()?.IsActived = true;
                    continue;
                }
                _AllButtonCarreau[car.Key]()?.IsActived = false;
            }
        }
        public static void EnablesButtons()
        {
            foreach (var car in _AllButtonCarreau)
            {
                if (_AllButtonCarreau[car.Key]().LinkChess == null)
                {
                    _AllButtonCarreau[car.Key]()?.IsActived = false;
                    continue;
                }
                _AllButtonCarreau[car.Key]()?.IsActived = true;
            }
        }
        public static IEnumerable<Chess> AllsPiecesAtCamps 
        {
            get
            {
                var f = new List<Chess>();
                foreach(var c in _AllsPiecesAtCamps.Values)
                {
                    try
                    {
                        f.AddRange(c()); 
                    }
                    catch(Exception)
                    {
                        continue;
                    }
                }
                return f.Count == 0? throw new Exception("Aucun Camp connecter") : f;
            }
        }

        public static IEnumerable<Chess> AllsPiecesForCamp(TypeCamp camp)
        {
           return _AllsPiecesAtCamps[camp]();
        }

        public static void Add(TypeCamp camp,Func<IEnumerable<Chess>> Linkcamp)
        {
            if (_AllsPiecesAtCamps.ContainsKey(camp)) return;
            _AllsPiecesAtCamps.Add(camp,Linkcamp);
        }

        /// <summary>
        /// retourner l'instance d'un chess blanc ou noir dans la liste global à une position donner
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Chess GetInstanceChess(ChessPosition position)
        {
            foreach(var chess in AllsPiecesAtCamps)
            {
                if(chess.Position == position)
                {
                    return chess;
                }
            }
            throw new ArgumentException(nameof(position));
        }

        public static void AddCarreau(Tableaux.Tableaux.Carreau carreau, Func<CarreauElement> carreauElementInstance)
        {
            _AllButtonCarreau.TryAdd(carreau, carreauElementInstance);
        }
    }
}
