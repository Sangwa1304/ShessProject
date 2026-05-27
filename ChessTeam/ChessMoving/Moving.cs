using ChessTeam.ChessLogical;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessTeam.ChessMoving
{
    public static class Moving
    {
        private static readonly Dictionary<TypeChess, Func<TypeCamp?,ChessPosition,List<ChessPosition>>> Foncs= new()
            {
            [TypeChess.Pion]=Pion,
            [TypeChess.Roi] = Roi,
            [TypeChess.Reine] = Reine,
            [TypeChess.Cavalier] = Cavalier,
            [TypeChess.Tour] = Tour,
            [TypeChess.Fou] = Fou
            };
        public static  List<ChessPosition> RunFonc(TypeChess type, TypeCamp? camp, ChessPosition position) 
        {
            
           
            return ChessPosition.Sorts(Foncs[type](camp, position));
        }
        private static List<ChessPosition> Pion(TypeCamp? camp,ChessPosition pion)
        {
            
            List<ChessPosition> all = [];
            if (camp == null)
                throw new ArgumentException("La valeur null non per,is pour les pions");
            if(camp == TypeCamp.W)
            {
               
                Add(pion.X +1, pion.Y + 1, ref all);
                Add(pion.X -1, pion.Y + 1, ref all);
                Add(pion.X   , pion.Y + 2, ref all);
                Add(pion.X, pion.Y + 1, ref all);
            }
            else
            {
                Add(pion.X -1, pion.Y - 1, ref all);
                Add(pion.X +1, pion.Y - 1, ref all);
                Add(pion.X   , pion.Y - 2, ref all);
                Add(pion.X, pion.Y + 1, ref all);
            }
            return all;
            //mm
        }
        private static List<ChessPosition> Cavalier(TypeCamp? camp,ChessPosition cavalier)
        {
            List<ChessPosition> all = [];

            // en X :
            Add(cavalier.X + 2, cavalier.Y + 1, ref all);
            Add(cavalier.X + 2, cavalier.Y - 1, ref all);
            // en Y :
            Add(cavalier.X + 1, cavalier.Y + 2, ref all);
            Add(cavalier.X - 1, cavalier.Y + 2, ref all);
            // en X Y up:
            Add(cavalier.X - 2, cavalier.Y + 1, ref all);
            Add(cavalier.X - 2, cavalier.Y - 1, ref all);
            // en X Y Inverse:
            Add(cavalier.X - 1, cavalier.Y - 2, ref all);
            Add(cavalier.X + 1, cavalier.Y - 2, ref all);

            return all;
            //mm code
        }

        private static void Iterate(int iteration, Tuple<int,int> value,ChessPosition position, ref List<ChessPosition> container)
        {
            var p = position;
            for (int i = 0; i < iteration; i++)
            {
                if(Add(p.X + value.Item1, p.Y + value.Item2, ref container))
                {
                    p = new(p.X + value.Item1, p.Y + value.Item2);
                }
            }
        }

        private static List<ChessPosition> Reine(TypeCamp? camp,ChessPosition reine)
        {
            List<ChessPosition> all = [];
            Transfert(Roi(camp, reine), ref all);
            Transfert(Fou(camp, reine), ref all);
            Transfert(Tour(camp, reine), ref all);
            return all;
            //mm code
        }

        private static List<ChessPosition> Roi(TypeCamp? camp,ChessPosition roi)
        {
            List<ChessPosition> all = [];
            // en X :
            Add(roi.X + 1, roi.Y, ref all);
            Add(roi.X - 1, roi.Y ,ref all);
            // en Y :
            Add(roi.X , roi.Y + 1,ref all);
            Add(roi.X , roi.Y - 1,ref all);
            // en X Y up :
            Add(roi.X + 1, roi.Y + 1,ref all);
            Add(roi.X - 1, roi.Y - 1,ref all);
            // en X Y Inverse :
            Add(roi.X - 1, roi.Y + 1,ref all);
            Add(roi.X + 1, roi.Y - 1,ref all);

            return all;
            //mm code
        }
        private static List<ChessPosition> Fou(TypeCamp? camp,ChessPosition fou)
        {
            List<ChessPosition> all = [];

            Iterate(8, new( 1, 1), fou, ref all);
            Iterate(8, new(-1,-1), fou, ref all);
            Iterate(8, new( 1,-1), fou, ref all);
            Iterate(8, new(-1, 1), fou, ref all);

            return all;
            //mm code
        }
        private static List<ChessPosition> Tour(TypeCamp? camp,ChessPosition tour)
        {
            List<ChessPosition> all = [];
            Iterate(8, new(-1, 0), tour, ref all);
            Iterate(8, new( 1, 0), tour, ref all);
            Iterate(8, new( 0, 1), tour, ref all);
            Iterate(8, new( 0,-1), tour, ref all);
            return all;
            //mm code
        }
        private static bool Add(int x, int y, ref List<ChessPosition> container)
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
        private static void Transfert(List<ChessPosition> ancien, ref List<ChessPosition> container)
        {
            foreach(var p in ancien)
            {
                container.Add(p);
            }
        }
    }
}
