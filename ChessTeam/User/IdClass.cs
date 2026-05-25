namespace ChessTeam.User
{
    internal static class IdClass
    {
        private static int _id = 0;
        public static int Id { get
                {
                if (int.TryParse(Haching.GetHach(true), out _id))
                {
                    int id = _id;
                    Console.WriteLine(_id);
                    _id = 0;
                    return id;
                }
                else
                    Console.WriteLine("pas de id propre "); 
                return 1;
                 } 
        }
        private readonly static List<int> Ids = [];
        public static void IdPosible(int id)
        {
            try
            {
                Ids.Remove(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
