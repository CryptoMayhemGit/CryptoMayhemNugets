namespace Mayhem.Common.Services.PathFindingService.Dtos
{
    public struct PathLand
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public PathLand(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(PathLand a, PathLand b) => a.X == b.X && a.Y == b.Y;

        public static bool operator !=(PathLand a, PathLand b) => !(a == b);

        public override bool Equals(object obj) => (this == (PathLand)obj);

        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();
    }
}
