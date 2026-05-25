namespace ChessTeam.Data
{
    internal static class IdClass
    {
        public static int _id = 0;
        public static int Id { get => _id = +1; set => _id = 0; }
    }
}
