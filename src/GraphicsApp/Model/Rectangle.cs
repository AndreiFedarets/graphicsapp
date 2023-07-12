namespace GraphicsApp.Model
{
    public class Rectangle : Shape
    {
        public Rectangle(Point p1, Point p2, IEnumerable<Shape> children = null)
            : base(children)
        {
            // check that points are correct and were passed
            // in the correct order, if not - correct them
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                BottomLeft = p1;
                TopRight = p2;
            }
            else
            {
                int minX = Math.Min(p1.X, p2.X);
                int minY = Math.Min(p1.Y, p2.Y);
                BottomLeft = new Point(minX, minY);

                int maxX = Math.Max(p1.X, p2.X);
                int maxY = Math.Max(p1.Y, p2.Y);
                TopRight = new Point(maxX, maxY);
            }
        }

        public Point BottomLeft { get; }

        public Point TopRight { get; }

        public int Height
        {
            get { return TopRight.Y - BottomLeft.Y; }
        }

        public int Width
        {
            get { return TopRight.X - BottomLeft.X; }
        }

        public override bool ContainsPoint(Point point)
        {
            return point.X >= BottomLeft.X && point.X <= TopRight.X && 
                   point.Y >= BottomLeft.Y && point.Y <= TopRight.Y;
        }

        public override double GetArea()
        {
            int height = TopRight.Y - BottomLeft.Y;
            int width = TopRight.X - BottomLeft.X;
            return height * width;
        }

        public override Rectangle GetBounds()
        {
            return this;
        }

        public override Shape AssignChildren(IEnumerable<Shape> children)
        {
            return new Rectangle(BottomLeft, TopRight, children)
            {
                Tag = Tag
            };
        }
    }
}
