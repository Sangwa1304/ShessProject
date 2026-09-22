using System;
using System.Collections.Generic;
using System.Text;
using ChessTeam.ChessLogical.Types;

namespace ChessTeam.ChessLogical;

public static class Conservateur
{

    public static class Initialisateur
    {
        private static readonly Dictionary<TypeCamp,Func<IEnumerable<Chess>>> _AllsPiecesAtCamps = [];
        
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
    }
}
