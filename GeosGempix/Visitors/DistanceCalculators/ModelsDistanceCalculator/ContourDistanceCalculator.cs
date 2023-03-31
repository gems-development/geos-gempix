using GeosGempix.GeometryPrimitiveInsiders;
using GeosGempix.Interfaces.IModels;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using System.Drawing;

namespace GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator
{
    internal class ContourDistanceCalculator : IModelDistanceCalculator
    {
        private Contour _contour;
        private double _result;

        public ContourDistanceCalculator(Contour contour)
        {
            _contour = contour;
            _result = 0;
        }

        public double GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = GetDistance(_contour, point);

        public void Visit(Line line) =>
            _result = GetDistance(_contour, line);

        public void Visit(Polygon polygon) =>
            _result = PolygonDistanceCalculator.GetDistance(polygon, _contour);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointDistanceCalculator.GetDistance(multiPoint, _contour);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineDistanceCalculator.GetDistance(multiLine, _contour);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonDistanceCalculator.GetDistance(multiPolygon, _contour);

        public void Visit(Contour contour) =>
            _result = GetDistance(_contour, contour);

        internal static double GetDistance(Contour contour, Point point)
        {
            if (ContourInsider.IsInside(contour, point))
                return 0;
            double result = Double.MaxValue;
            double distance = 0;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));
            
            foreach (Line line in lines)
            {
                distance = LineDistanceCalculator.GetDistance(line, point);
                if (distance < result)
                    result = distance;
            }

            return result;
        }

        //Issue 1
        internal static double GetDistanceToInnerPoint(Contour contour, Point point)
        {
            double result = double.MaxValue;
            double distance = 0;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));

            foreach (Line line in lines)
            {
                distance = LineDistanceCalculator.GetDistance(line, point);
                if (distance < result)
                    result = distance;
            }

            return result;
        }



        internal static double GetDistance(Contour contour, Line line)
        {
            if (ContourInsider.IsInside(contour, line))
                return 0;
            double result = double.MaxValue;
            double distance = 0;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));
            
            foreach (Line line1 in lines)
            {
                distance = LineDistanceCalculator.GetDistance(line1, line);
                if (distance < result)
                    result = distance;
            }

            return result;
        }

        internal static double GetDistanceWithSquares(Contour contour, Line line)
        {
            if (ContourInsider.IsInside(contour, line))
                return 0;
            double result = double.MaxValue;
            double distance = 0;
            List<Point> points = contour.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));
            
            foreach (Line line1 in lines)
            {
                distance = LineDistanceCalculator.GetDistanceWithSquaresOfDistances(line1, line);
                if (distance < result)
                    result = distance;
            }

            return Math.Sqrt(result);
        }

        internal static double GetDistance(Contour contour1, Contour contour2)
        {
            double result = double.MaxValue;
            double distance;
            // проверка если полигон ВНУТРИ полигона... какой внутри какого?)))
            List<Point> points = contour2.GetPoints();
            List<Line> lines = new List<Line>();
            for (int i = 0; i < points.Count - 1; i++)
                lines.Add(new Line(points[i], points[i + 1]));
            
            foreach (Line line in lines)
            {
                distance = GetDistance(contour1, line);
                if (distance < result)
                    result = distance;
            }

            return result;
        }
       
        internal static double GetDistance(Contour contour, MultiLine multiLine) =>
            MultiLineDistanceCalculator.GetDistance(multiLine, contour);

        internal static double GetDistance(Contour contour, MultiPoint multiPoint) =>
            MultiPointDistanceCalculator.GetDistance(multiPoint, contour);

        internal static double GetDistance(Contour contour, MultiPolygon multiPolygon) =>
            MultiPolygonDistanceCalculator.GetDistance(multiPolygon, contour);
    }
}
