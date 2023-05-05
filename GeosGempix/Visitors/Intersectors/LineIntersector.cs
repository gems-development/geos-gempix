using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Errors;

namespace GeosGempix.GeometryPrimitiveIntersectors
{
	public enum LineEquationsStatus
    {
        Intersects,
        Parallel,
        Coincide // СОВПАДАЮТ
    }
    public class LineIntersector : IModelsIntersector
    {
        private bool _result;
        private readonly Line _line;

        public LineIntersector(Line line) =>
            _line = line;

        public static bool Intersects(Line line, Point point)
        {
            if (point == null)
                throw new ArgumentNullException("Intersects: point = null");
            if (line == null)
                throw new ArgumentNullException("Intersects: line = null");
            return Math.Abs(PointDistanceCalculator.GetDistance(point, line.Point1) +
                PointDistanceCalculator.GetDistance(point, line.Point2) - line.GetLength()) < 0.00000001;
        }

        internal static bool Intersects(Line line1, Line line2)
        {
            Point[] points = GetPointOfIntersection(line1, line2);
            if (points == null)
                return false;
            return true;
        }

        internal static Point? GetPointOfIntersection(
            (double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            var (a1, b1, c1) = lineEq1;
            var (a2, b2, c2) = lineEq2;
            if (a1 == 0 && b1 == 0)
                throw new ArgumentNullException("Уравнение прямой lineEq1 задано неверно");
            if (a2 == 0 && b2 == 0)
                throw new ArgumentNullException("Уравнение прямой lineEq2 задано неверно");
            double x, y;
            if (a1 == 0)
            { // значит b1 != 0
                if (a2 == 0)
                {
                    // b2 != 0
                    if (c1 / b1 == c2 / b2)
                    {
                        // значит, уравнения по сути одинаковые и это одна и та же прямая
                        throw new LibraryException(
                            ErrorCode.InvalidArgument,
                            "Прямые совпадают, невозможно получить единственную точку пересечения");
                    }
                    // а иначе прямые параллельны (но не совпадают) и точки пересечения нет
                    return null;
                }

                y = -c1 / b1;
                x = (-c2 - b2 * y) / a2;
                return new Point(x, y);
            }
            if (a2 == 0)
            {
                y = -c2 / b2;
                x = (-c1 - b1 * y) / a1;
                return new Point(x, y);
            }
            if (b1 == 0 && b2 == 0)
            {
                if (c1 / a1 == c2 / a2)
                {
                    throw new LibraryException(
                        ErrorCode.InvalidArgument,
                        "Прямые совпадают, невозможно получить единственную точку пересечения");
                }
                // а иначе прямые параллельны (но не совпадают) и точки пересечения нет
                return null;
            }
            y = (-c2 + c1 * a2 / a1) / (b2 - b1 * a2 / a1);
            x = (-c1 - b1 * y) / a1;
            return new Point(x, y);
        }

        // null - нет точки пересечения
        // Массив из 1 элемента - одна точка пересечения
        // Массив из двух элементов - пересечение представляет собой отрезок
        // той же направленности, что и первый отрезок
        internal static Point[]? GetPointOfIntersection(Line line1, Line line2)
        {
            if (line1 == null)
                throw new ArgumentNullException("line1 == null");
            if (line2 == null)
                throw new ArgumentNullException("line2 == null");
            var lineEq1 = line1.GetEquationOfLine();
            var lineEq2 = line2.GetEquationOfLine();
            LineEquationsStatus status = GetLineEquationsStatus(lineEq1, lineEq2);
            switch (status)
            {
                case LineEquationsStatus.Parallel:
                    return null;
                case LineEquationsStatus.Intersects:
                {
                    Point point = GetPointOfIntersectionIfStatusIntersects(lineEq1, lineEq2)!; 
                    // в строке выше второй раз прогоняются проверки значений, но их гораздо меньше
                    // Но по итогу дублирование кода аж 3 раза, по сути
                    if (Intersects(line1, point) && Intersects(line2, point))
                        return new Point[] { point };
                    return null;
                }
                default:
                    // значит, отрезки лежат на одной прямой и все сложно
                    // Проверим расположение точек относительно друг друга
                    // Положительное направление буду определять
                    // с помощью всего одной координаты вектора A1B1
                    // A1B1 = (x,y) - если x = 0, значит смотрим на y, иначе на х
                    var (p1, p2, p3, p4) = (line1.Point1, line1.Point2, line2.Point1, line2.Point2);
                    var (x1, x2, x3, x4) = (p1.X, p2.X, p3.X, p4.X);
                    var (y1, y2, y3, y4) = (p1.Y, p2.Y, p3.Y, p4.Y);

                    // проверка на вертикальность отрезков (если первый вертикальный, то и второй тоже)
                    (double c1, double c2, double c3, double c4) cort = 
                        x1 == x2 ? (y1, y2, y3, y4) : (x1, x2, x3, x4);
                    var revLine1 = cort.c1 > cort.c2;
                    var revLine2 = cort.c3 > cort.c4;

                    if (revLine1)  // допустим, было x1 x2 x3 x4
                        cort = (cort.c2, cort.c1, cort.c3, cort.c4);  // теперь x2 x1 x3 x4 - x2 x1 по возраст.
                    if (revLine2) 
                        cort = (cort.c1, cort.c2, cort.c4, cort.c3); // x2 x1 x4 x3 
                    Point? pr1 = null;
                    
                    if (cort.c1 <= cort.c3)// c1 c3
                    { 
                        if (cort.c3 <= cort.c2)  // c1 c3 c2
                            pr1 = revLine2 ? p4 : p3;  // первая c3 -> pr1 = p4 либо p3
                        else // c1 c2 c3 c4, pr1 = null, pr2 = null
                            return null;
                    }
                    else // c3 c1 c2 
                    { 
                        if (cort.c1 <= cort.c4) // c3 c1 ?c4? c2 ?c4? 
                            pr1 = revLine1 ? p2 : p1; // первая c1 -> pr1 = p1 либо p2
                        else // c3 c4 c1 c2
                            return null;
                    }
                    // pr1 осталось null

                    Point? pr2 = null;
                    if (cort.c2 <= cort.c4) // c1 c2 c4
                    {
                        if (cort.c3 <= cort.c2) // ?c3? c1 ?c3? c2 c4
                            pr2 = revLine1 ? p1 : p2; // вторая с2 -> pr2 = p2 либо p1
                        else // c1 c2 c3 c4
                            return null;
                    }
                    else // ?c4? c1 ?c4? c2
                    {
                        if (cort.c1 <= cort.c4) // ?c3? c1 ?c3? c4 c2 
                            pr2 = revLine2 ? p4 : p3; // вторая c4 -> pr2 = p4 либо p3
                        else // c3 c4 c1 c2
                            return null;
                    }

                    if (pr1!= null)
                    {
                        if (p2 != null)
                            if (pr1 != pr2)
                                return new[] { pr1!, pr2! }; // а направление совпадает с первым отрезком?
                        return new[] { pr1! };
                    }
                    if (pr2 != null)
                        return new[] { pr2! };
                    return null; // по идее мы даже не дойдём досюда никогда
            }
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = Intersects(_line, point);

        public void Visit(Line line) =>
            _result = Intersects(_line, line);

        public void Visit(Polygon polygon) =>
            _result = PolygonIntersector.Intersects(polygon, _line);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _line);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _line);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _line);

        public void Visit(Contour contour) =>
            _result = ContourIntersector.Intersects(contour, _line);

        private static Point GetPointOfIntersectionIfStatusIntersects(
            (double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            var (a1, b1, c1) = lineEq1;
            var (a2, b2, c2) = lineEq2;
            double x, y;
            if (a1 == 0)
            { 
                y = -c1 / b1;
                x = (-c2 - b2 * y) / a2;
                return new Point(x, y);
            }
            if (a2 == 0)
            {
                y = -c2 / b2;
                x = (-c1 - b1 * y) / a1;
                return new Point(x, y);
            }
            y = (-c2 + c1 * a2 / a1) / (b2 - b1 * a2 / a1);
            x = (-c1 - b1 * y) / a1;
            return new Point(x, y);
        }

        public static LineEquationsStatus GetLineEquationsStatus(
            (double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            var (a1, b1, c1) = lineEq1;
            var (a2, b2, c2) = lineEq2;
            if (a1 == 0 && b1 == 0)
                throw new ArgumentNullException("Уравнение прямой lineEq1 задано неверно");
            if (a2 == 0 && b2 == 0)
                throw new ArgumentNullException("Уравнение прямой lineEq2 задано неверно");
            if (a1 == 0)
            { 
                if (a2 == 0)
                {
                    if (c1 / b1 == c2 / b2)
                    {
                        return LineEquationsStatus.Coincide;
                    }
                    return LineEquationsStatus.Parallel;
                }
                return LineEquationsStatus.Intersects;
            }
            if (a2 == 0)
            {
                return LineEquationsStatus.Intersects;
            }
            if (b1 == 0 && b2 == 0)
            {
                if (c1 / a1 == c2 / a2)
                {
                    return LineEquationsStatus.Coincide;
                }
                return LineEquationsStatus.Parallel;
            }
            return LineEquationsStatus.Intersects;
        }
    }
}
