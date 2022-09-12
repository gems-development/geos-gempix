namespace GeometryModels
{
    public class Point : IMeasurable
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public bool Equals(Point point)
        {
            return X == point.X && Y == point.Y && Z == point.Z;
        }
        public void Equal(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
            this.Z = point.Z;
        }
        public double GetDistance(IMeasurable B)
        {
            double distance = 0;
            // PointDistanceCalculator(this, B);
            return distance;
        }
    }
}