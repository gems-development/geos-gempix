using GeosGempix.GeometryPrimitiveIntersectors;
using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.Visitors.DistanceCalculators.ModelsDistanceCalculator;
using GeosGempix.MultiModels;
using GeosGempix.Visitors;

namespace GeosGempix.GeometryPrimitiveInsiders
{
    public class ContourInsider : IModelInsider
    {
        private bool _result;
        private Contour _contour;

        public ContourInsider(Contour contour) =>
            _contour = contour;

        internal static bool IsInside(Contour contour, Point point)
        {
            Line? closestLine = null;
            double distance = double.MaxValue;
            double curDistance;
            // нашли самую близкую сторону
            foreach (Line line in contour.GetLines())
            {
                curDistance = LineDistanceCalculator.GetDistance(line, point);
                if (distance > curDistance)
                {
                    distance = curDistance;
                    closestLine = line;
                }
            }
            Point vertex1 = closestLine!.Point1;
            Point vertex2 = closestLine.Point2;
            Point vertex3 = contour.GetNextPoint(vertex2);
            // уравнения этой стороны и соседней
            var equation1 = closestLine.GetEquationOfLine();
            var equation2 = new Line(vertex2, vertex3).GetEquationOfLine();
            // уравнение биссектрисы
            var bis = GetEquationOfBisector(equation1, equation2, vertex1, vertex3);
            Point pointFromBis1;
            Point pointFromBis2;
            double a = bis.a;
            double b = bis.b;
            double c = bis.c;
            double x, y;
            // надо понять, какой кусочек биссектрисы будет внешним для многоугольника
            if (b != 0)
            {
                x = vertex2.X + 1;
                y = (-c - a * x) / b;
                pointFromBis1 = new Point(x, y);
                x = x - 2;
                y = (-c - a * x) / b;
                pointFromBis2 = new Point(x, y);
            }
            else if (a != 0)
            {
                x = -c / a;
                y = vertex2.Y + 1;
                pointFromBis1 = new Point(x, y);
                y = y - 2;
                pointFromBis2 = new Point(x, y);
            }
            else
                throw new ArithmeticException("Line doesn't exist, coefs A and B are 0");
            // нашли две точки, принадлежащие биссектрисе, одна внешняя, другая внутренняя.
            // определим внешнюю с помощью обходов "по часовой" и "против часовой"
            // рассмотрим треугольники, состоящие из следующих точек:
            // vertex2, pointFromBis1, vertex3
            // vertex2, pointFromBis2, vertex3
            // у одного треугольника будет обход по часовой, у другого против
            // у исходного многоугольника тоже был свой обход
            // Нам нужен тот треугольник, обход которого совпадает с исходным
            // в нем находится нужная нам ВНЕШНЯЯ точка из биссектрисы
            bool bypass = contour.isClockwiseBypass();
            bool bypass1 = new Contour(new List<Point>() { vertex2, pointFromBis1, vertex3 }).isClockwiseBypass();
            Point pointFromBis;
            if (bypass == bypass1)
                pointFromBis = pointFromBis1;
            else
                pointFromBis = pointFromBis2;
            // будем смотреть на угол между нормалью, проходящей через point,
            // и биссектрисой (вектором внешнего ее продолжения)
            Point p = LineIntersector.GetPointOfIntersection(
                equation1,
                Line.GetEquationOfPerpendicularLine(equation1, point));
            // координаты вектора внешней части биссектрисы
            double x1 = pointFromBis.X - vertex2.X;
            double y1 = pointFromBis.Y - vertex2.Y;
            // координаты вектора нормали (неизвестно, внутренняя она или внешняя, в этом и смысл)
            double x2 = point.X - p.X;
            double y2 = point.Y - p.Y;
            // скалярное произведение разделить на произведение длин векторов
            double cos = (x1 * x2 + y1 * y2) / (Math.Sqrt(x1 * x1 + y1 * y1) + Math.Sqrt(x2 * x2 + y2 * y2));
            // если косинус больше нуля, то угол от 0 до 90 градусов, а значит, точка снаружи
            // иначе - внутри
            // косинус не может быть 0
            return cos < 0;
        }

        internal static (double a, double b, double c) GetEquationOfBisector((double a1, double b1, double c1) lineEq1, 
            (double a2, double b2, double c2) lineEq2, 
            Point first, 
            Point last)
        {
            double a1 = lineEq1.a1;
            double b1 = lineEq1.b1;
            double c1 = lineEq1.c1;
            double a2 = lineEq2.a2;
            double b2 = lineEq2.b2;
            double c2 = lineEq2.c2;
            double denum1 = Math.Sqrt(a1 * a1 + b1 * b1);
            double denum2 = Math.Sqrt(a2 * a2 + b2 * b2);
            // одна биссектриса для внешнего угла, другая для внутреннего
            // внешний угол = дополняющий до 180
            double[] bis1 = {
                a1 * denum2 - a2 * denum1,
                b1 * denum2 - b2 * denum1,
                c1 * denum2 - c2 * denum1 };
            double[] bis2 = {
                a1 * denum2 + a2 * denum1,
                b1 * denum2 + b2 * denum1,
                c1 * denum2 + c2 * denum1 };
            // если подставить координаты точек в уравнения,
            // то если результаты одного знака, то это бис-са внешнего угла, иначе - внутреннего
            double res1 = bis1[0] * first.X + bis1[1] * first.Y + bis1[2];
            double res2 = bis1[0] * last.X + bis1[1] * last.Y + bis1[2];
            if (res1 > 0 && res2 > 0 || res1 < 0 && res2 < 0)
                return (bis2[0], bis2[1], bis2[2]);
            return (bis1[0], bis1[1], bis1[2]);
        }
        internal static bool IsInside(Contour contour, Line line1)
        {
            if (IsInside(contour, line1.Point1) && !ContourIntersector.Intersects(contour, line1))
                return true;
            return false;
        }

        internal static bool IsInside(Contour contour, Polygon polygon)
        {
            if (IsInside(contour, polygon.GetPoints()[0]) && !PolygonIntersector.Intersects(polygon, contour))
                return true;
            return false;
        }

        internal static bool IsInside(Contour contour, MultiPoint multiPoint)
        {
            foreach (Point point in multiPoint.GetPoints())
                if (!IsInside(contour, point))
                    return false;
            return true;
        }

        internal static bool IsInside(Contour contour, MultiLine multiLine)
        {
            foreach (Line line in multiLine.GetLines())
                if (!IsInside(contour, line))
                    return false;
            return true;
        }

        internal static bool IsInside(Contour contour, MultiPolygon multiPolygon)
        {
            foreach (Polygon polygon in multiPolygon.GetPolygons())
                if (!IsInside(contour, polygon))
                    return false;
            return true;
        }

        internal static bool IsInside(Contour contour1, Contour contour2)
        {
            if (IsInside(contour1, contour2.GetPoints()[0]) && !ContourIntersector.Intersects(contour1, contour2))
                return true;
            return false;
        }

        internal static bool IsSctrictlyInside(Contour contour, Point point)
        {
            return IsInside(contour, point) && !ContourIntersector.IntersectsBorders(contour, point);
        }
        internal static bool IsSctrictlyInside(Contour contour, Line line1)
        {
            return IsInside(contour, line1) && !ContourIntersector.IntersectsBorders(contour, line1);
        }
        internal static bool IsSctrictlyInside(Contour contour, Polygon polygone)
        {
            return IsInside(contour, polygone) && !PolygonIntersector.IntersectsBorders(polygone, contour);
        }
        internal static bool IsSctrictlyInside(Contour contour, MultiPoint multiPoint)
        {
            return IsInside(contour, multiPoint) && !MultiPointIntersector.Intersects(multiPoint, contour);
        }
        internal static bool IsSctrictlyInside(Contour contour, MultiLine multiLine)
        {
            return IsInside(contour, multiLine) && !MultiLineIntersector.Intersects(multiLine, contour);
        }
        internal static bool IsSctrictlyInside(Contour contour, MultiPolygon multiPolygon)
        {
            return IsInside(contour, multiPolygon) && !MultiPolygonIntersector.IntersectsBorders(multiPolygon, contour);
        }
        internal static bool IsSctrictlyInside(Contour contour1, Contour contour2)
        {
            return IsInside(contour1, contour2) && !ContourIntersector.IntersectsBorders(contour1, contour2);
        }
        internal static bool IsInsideWithTouching(Contour contour, Point point)
        {
            return IsInside(contour, point) && ContourIntersector.IntersectsBorders(contour, point);
        }
        internal static bool IsInsideWithTouching(Contour contour, Line line1)
        {
            return IsInside(contour, line1) && ContourIntersector.IntersectsBorders(contour, line1);
        }
        internal static bool IsInsideWithTouching(Contour contour, Polygon polygone)
        {
            return IsInside(contour, polygone) && PolygonIntersector.IntersectsBorders(polygone, contour);
        }
        internal static bool IsInsideWithTouching(Contour contour, MultiPoint multiPoint)
        {
            return IsInside(contour, multiPoint) && MultiPointIntersector.Intersects(multiPoint, contour);
        }
        internal static bool IsInsideWithTouching(Contour contour, MultiLine multiLine)
        {
            return IsInside(contour, multiLine) && MultiLineIntersector.Intersects(multiLine, contour);
        }
        internal static bool IsInsideWithTouching(Contour contour, MultiPolygon multiPolygon)
        {
            return IsInside(contour, multiPolygon) && MultiPolygonIntersector.IntersectsBorders(multiPolygon, contour);
        }
        internal static bool IsInsideWithTouching(Contour contour1, Contour contour2)
        {
            return IsInside(contour1, contour2) && ContourIntersector.IntersectsBorders(contour1, contour2);
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = IsInside(_contour, point);

        public void Visit(Line line) =>
            _result = IsInside(_contour, line);

        public void Visit(Polygon polygon) =>
            _result = IsInside(_contour, polygon);

        public void Visit(MultiPoint multiPoint) =>
            _result = IsInside(_contour, multiPoint);

        public void Visit(MultiLine multiLine) =>
            _result = IsInside(_contour, multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = IsInside(_contour, multiPolygon);

        public void Visit(Contour contour) =>
            _result = IsInside(_contour, contour);
    }
}