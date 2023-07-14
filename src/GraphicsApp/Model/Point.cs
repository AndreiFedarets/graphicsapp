namespace GraphicsApp.Model
{
    public readonly struct Point
    {
        public static readonly Point Zero = new Point(0, 0);

        private readonly int _x;
        private readonly int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X => _x;

        public int Y => _y;

        public override bool Equals(object obj)
        {
            if (!(obj is Point other))
            {
                return false;
            }
            return other._x == _x && other._y == _y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_x, _y);
        }
    }
}
