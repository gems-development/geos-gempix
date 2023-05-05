using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator
{
	public class LineDistanceCalculator : IModelDistanceCalculator
    {
        private Line _line;
        private double _result;

        public LineDistanceCalculator(Point point1, Point point2) =>
            _line = new Line(point1, point2);

        public LineDistanceCalculator(Line line) =>
            _line = line;

        public double GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = GetDistance(_line, point);

        public void Visit(Line line) =>
            _result = GetDistance(_line, line);

        public void Visit(Polygon polygon) =>
            _result = PolygonDistanceCalculator.GetDistance(polygon, _line);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _line);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineDistanceCalculator.GetDistance(multiLine, _line);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _line);

        public void Visit(Contour contour) =>
            _result = ContourDistanceCalculator.GetDistance(contour, _line);

        internal static double GetDistance(Line line, Point point)
        {
            double[] distances = new double[3];
            distances[2] = double.MaxValue;
            distances[0] = PointDistanceCalculator.GetDistance(line.Point1, point);
            distances[1] = PointDistanceCalculator.GetDistance(line.Point2, point);
            var eq1 = line.GetEquationOfLine();
            var eq2 = Line.GetEquationOfPerpendicularLine(eq1, point);
            // point1 = null конкретно здесь быть не может
            Point? point1 = LineIntersector.GetPointOfIntersection(eq1, eq2);
            if (LineIntersector.Intersects(line, point1))
                distances[2] = PointDistanceCalculator.GetDistance(point1, point);
            return distances.Min();
        }

        internal static double GetDistance(Line line1, Line line2)
        {
            double[] distances = new double[4];
            if (LineIntersector.Intersects(line1, line2))
                return 0;
            distances[0] = LineDistanceCalculator.GetSquareDistance(line1, line2.Point1);
            distances[1] = LineDistanceCalculator.GetSquareDistance(line1, line2.Point2);
            distances[2] = LineDistanceCalculator.GetSquareDistance(line2, line1.Point1);
            distances[3] = LineDistanceCalculator.GetSquareDistance(line2, line1.Point2);
            return Math.Sqrt(distances.Min());
        }

        private static double GetSquareDistance(Line line, Point point)
        {
            double[] distances = new double[3];
            distances[2] = double.MaxValue;
            distances[0] = PointDistanceCalculator.GetSquareDistance(line.Point1, point);
            distances[1] = PointDistanceCalculator.GetSquareDistance(line.Point2, point);
            var eq1 = line.GetEquationOfLine();
            var eq2 = Line.GetEquationOfPerpendicularLine(eq1, point);
            Point? point1 = LineIntersector.GetPointOfIntersection(eq1, eq2);
            if (LineIntersector.Intersects(line, point1))
                distances[2] = PointDistanceCalculator.GetSquareDistance(point1, point);
            return distances.Min();
        }

        public static decimal GetSquareDistanceDecimal(Line line, Point point)
        {
            decimal[] distances = new decimal[3];
            distances[2] = decimal.MaxValue;
            distances[0] = PointDistanceCalculator.GetSquareDistanceDecimal(line.Point1, point);
            distances[1] = PointDistanceCalculator.GetSquareDistanceDecimal(line.Point2, point);
            var eq1 = line.GetEquationOfLine();
            var eq2 = Line.GetEquationOfPerpendicularLine(eq1, point);
            Point? point1 = LineIntersector.GetPointOfIntersection(eq1, eq2);
            if (LineIntersector.Intersects(line, point1))
                distances[2] = PointDistanceCalculator.GetSquareDistanceDecimal(point1, point);
            return distances.Min();
        }

        internal static double GetDistance(Line line, Polygon polygon) =>
            PolygonDistanceCalculator.GetDistance(polygon, line);

        internal static double GetDistance(Line line, MultiLine multiLine) =>
            MultiLineDistanceCalculator.GetDistance(multiLine, line);

        internal static double GetDistance(Line line, MultiPoint multiPoint) =>
            MultiPointDistanceCalculator.GetDistance(multiPoint, line);

        internal static double GetDistance(Line line, MultiPolygon multiPolygon) =>
            MultiPolygonDistanceCalculator.GetDistance(multiPolygon, line);

        internal static double GetDistance(Line line, Contour contour) =>
            ContourDistanceCalculator.GetDistance(contour, line);
        
        internal static double GetDistanceInside(Line line, Contour contour) =>
            ContourDistanceCalculator.GetDistanceInside(contour, line);
    }
}