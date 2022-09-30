namespace GeometryModels
{
    public class Point : IGeometryPrimitive
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Point(double x, double y) 
        {
            X = x;
            Y = y;
        }
        public bool Equals(Point point)
        {
            return X == point.X && Y == point.Y; 
        }
        public void Equal(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        public void Accept(IGeometryPrimitiveVisitor v)
        {
            v.Visit(this);
        }
    }
}