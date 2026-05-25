using ChessTeam.ChessLogical;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessTeam.ChessMoving
{
    public static class Moving
    {
        public delegate List<ChessPosition> Fonc(TypeCamp camp, ChessPosition position);
        public static readonly Dictionary<TypeChess, Fonc> Fonction = new()
            {
                
            };
        public static List<ChessPosition> Pion(TypeChess camp,ChessPosition pion)
        {
            List<ChessPosition> all = [];
            if(camp == TypeCamp.W)
            {

            }
            else
            {
               
            }
            return all;
            //mm
        }
        public static List<ChessPosition> Cavalier(TypeCamp camp,ChessPosition cavalier)
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

        private static void Ocure(int iteration, Tuple<int,int> value,ChessPosition p, ref List<ChessPosition> container)
        {
            for (int i = 0; i < iteration; i++)
            {
                Add(p.X + value.Item1, p.Y + value.Item2, ref container);
            }
        }

        public static List<ChessPosition> Reine(TypeCamp camp,ChessPosition reine)
        {
            List<ChessPosition> all = [];
            Transfert(Roi(camp, reine), ref all);
            Transfert(Fou(camp, reine), ref all);
            Transfert(Tour(camp, reine), ref all);
            return all;
            //mm code
        }

        public static List<ChessPosition> Roi(TypeCamp camp,ChessPosition roi)
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
        public static List<ChessPosition> Fou(TypeCamp camp,ChessPosition fou)
        {
            List<ChessPosition> all = [];

            Ocure(8, new( 1, 1), fou, ref all);
            Ocure(8, new(-1,-1), fou, ref all);
            Ocure(8, new( 1,-1), fou, ref all);
            Ocure(8, new(-1, 1), fou, ref all);

            return all;
            //mm code
        }
        public static List<ChessPosition> Tour(TypeCamp camp,ChessPosition tour)
        {
            List<ChessPosition> all = [];
            Ocure(8, new(-1, 0), tour, ref all);
            Ocure(8, new( 1, 0), tour, ref all);
            Ocure(8, new( 0, 1), tour, ref all);
            Ocure(8, new( 0,-1), tour, ref all);
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
