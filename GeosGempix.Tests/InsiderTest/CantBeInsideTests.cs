using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.Tests.InsiderTest
{

    public class CantBeInsideTests
    {
        public Point _point;
        public Line _line;
        public MultiPoint _multiPoint;
        public MultiLine _multiLine;
        public CantBeInsideTests()
        {
            List<Point> points = new List<Point>();
            Point point1 = new Point(0, 0);
            Point point2 = new Point(9, 0);
            Point point3 = new Point(9, 9);
            Point point4 = new Point(0, 9);
            points.Add(point1);
            points.Add(point2);
            points.Add(point3);
            points.Add(point4);
            _point = point1;
            _line = new Line(point1, point2);
            _multiPoint = new MultiPoint(points);
            Line line1 = new Line(point1, point2);
            Line line2 = new Line(point3, point4);
        }
    }
}
