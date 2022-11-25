using GeometryModels.GeometryPrimitiveIntersectors;
using GeometryModels.Interfaces.IModels;
using GeometryModels.Models;

namespace GeometryModels.Visitors.DistanceCalculators.ModelsDistanceCalculator
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
            ContourDistanceCalculator.GetDistance(contour, _line);

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
            double[] distances = new double[5];
            distances[4] = double.MaxValue;
            if (LineIntersector.Intersects(line1, line2))
                return 0;
            distances[0] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point1);
            distances[1] = PointDistanceCalculator.GetDistance(line1.Point1, line2.Point2);
            distances[2] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point1);
            distances[3] = PointDistanceCalculator.GetDistance(line1.Point2, line2.Point2);
            var eq1 = line1.GetEquationOfLine();
            var eq2 = line2.GetEquationOfLine();
            // найдем уравнения перпендикуляров к отрезку в точках p1 и p2
            var eq3 = Line.GetEquationOfPerpendicularLine(eq1, line1.Point1);
            var eq4 = Line.GetEquationOfPerpendicularLine(eq1, line1.Point2);
            // точка пересечения перпенд. к 1 отрезку и второго отрезка
            Point? point3 = LineIntersector.GetPointOfIntersection(eq3, eq2);
            // можно этот метод удобно переписать под линию кратчайшего расстояния
            // вместо distances будут Line
            if (LineIntersector.Intersects(line2, point3))
                distances[4] = PointDistanceCalculator.GetDistance(line1.Point1, point3);
            else
            {
                Point? point4 = LineIntersector.GetPointOfIntersection(eq4, eq2);
                if (LineIntersector.Intersects(line2, point4))
                    distances[4] = PointDistanceCalculator.GetDistance(line1.Point1, point3);
            }
            return distances.Min();
        }

        internal static double GetDistanceWithSquaresOfDistances(Line line1, Line line2)
        {
            double[] distances = new double[5];
            distances[4] = double.MaxValue;
            if (LineIntersector.Intersects(line1, line2))
                return 0;
            distances[0] = PointDistanceCalculator.GetSquareDistance(line1.Point1, line2.Point1);
            distances[1] = PointDistanceCalculator.GetSquareDistance(line1.Point1, line2.Point2);
            distances[2] = PointDistanceCalculator.GetSquareDistance(line1.Point2, line2.Point1);
            distances[3] = PointDistanceCalculator.GetSquareDistance(line1.Point2, line2.Point2);
            var eq1 = line1.GetEquationOfLine();
            var eq2 = line2.GetEquationOfLine();
            // если прямые параллельны
            if (LineIntersector.GetPointOfIntersection(eq1, eq2) == null)
            {
                // найдем уравнения перпендикуляров к отрезку в точках p1 и p2
                var eq3 = Line.GetEquationOfPerpendicularLine(eq1, line1.Point1);
                var eq4 = Line.GetEquationOfPerpendicularLine(eq1, line1.Point2);
                // точка пересечения перпенд. к 1 отрезку и второго отрезка
                Point? point3 = LineIntersector.GetPointOfIntersection(eq3, eq2);
                // можно этот метод удобно переписать под линию кратчайшего расстояния
                // вместо distances будут Line
                if (LineIntersector.Intersects(line2, point3))
                    distances[4] = PointDistanceCalculator.GetSquareDistance(line1.Point1, point3);
                else
                {
                    Point? point4 = LineIntersector.GetPointOfIntersection(eq4, eq2);
                    if (LineIntersector.Intersects(line2, point4))
                        distances[4] = PointDistanceCalculator.GetSquareDistance(line1.Point1, point3);
                }
            }
            return Math.Sqrt(distances.Min());
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
    }
}