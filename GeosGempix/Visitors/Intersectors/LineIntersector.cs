using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;
using GeosGempix.Errors;
using System.Drawing;

namespace GeosGempix.GeometryPrimitiveIntersectors
{
    public enum LineEquationsStatus
    {
        INTERSECTS,
        PARALLEL,
        COINCIDE // СОВПАДАЮТ
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
                throw new LibraryException(ErrorCode.NULL_ARGUMENT, "Intersects: point = null");
            if (line == null)
                throw new LibraryException(ErrorCode.NULL_ARGUMENT, "Intersects: line = null");
            return Math.Abs(PointDistanceCalculator.GetDistance(point, line.Point1) +
                PointDistanceCalculator.GetDistance(point, line.Point2) - line.GetLength()) < 0.00000001;
        }

        internal static bool IntersectsStraightLines(Line line1, Line line2)
        {
            if (GetPointOfIntersection(line1.GetEquationOfLine(), line2.GetEquationOfLine()) != null)
                return true;
            return false;
        }

        internal static bool Intersects(Line line1, Line line2)
        {
            Point? point = GetPointOfIntersection(line1.GetEquationOfLine(), line2.GetEquationOfLine());
            if (point == null)
                return false;
            if (Intersects(line1, point) && Intersects(line2, point))
                return true;
            return false;
        }

        internal static Point? GetPointOfIntersection(
            (double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            double a1 = lineEq1.a1, b1 = lineEq1.b1, c1 = lineEq1.c1,
               a2 = lineEq2.a2, b2 = lineEq2.b2, c2 = lineEq2.c2;
            if (a1 == 0 && b1 == 0)
                throw new LibraryException(
                    ErrorCode.ILLEGAL_ARGUMENT,
                    "Уравнение прямой lineEq1 задано неверно");
            if (a2 == 0 && b2 == 0)
                throw new LibraryException(
                    ErrorCode.ILLEGAL_ARGUMENT,
                    "Уравнение прямой lineEq2 задано неверно");
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
                            ErrorCode.ILLEGAL_ARGUMENT,
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
                        ErrorCode.ILLEGAL_ARGUMENT,
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
                throw new LibraryException(ErrorCode.NULL_ARGUMENT, "line1 == null");
            if (line2 == null)
                throw new LibraryException(ErrorCode.NULL_ARGUMENT, "line2 == null");
            (double, double, double) lineEq1 = line1.GetEquationOfLine();
            (double, double, double) lineEq2 = line2.GetEquationOfLine();
            LineEquationsStatus status = GetLineEquationsStatus(lineEq1, lineEq2);
            switch (status)
            {
                case LineEquationsStatus.PARALLEL:
                    return null;
                case LineEquationsStatus.INTERSECTS:
                {
                    Point point = GetPointOfIntersection(lineEq1, lineEq2)!; 
                    // в строке выше второй раз прогоняются проверки значений a1 a2 и т д
                    if (Intersects(line1, point) && Intersects(line2, point))
                        return new Point[] { point };
                    return null;
                }
                default:
                    // значит, отрезки лежат на одной прямой и все сложно
                    // Проверим расположение точек относительно друг друга
                    // Буду играть с векторами и их направлениями.
                    // Положительное направление буду определять
                    // с помощью всего одной координаты вектора A1B1
                    // A1B1 = (x,y) - если x = 0, значит смотрим на y, иначе на х
                    Point A1 = line1.Point1;
                    Point B1 = line1.Point2;
                    Point A2 = line2.Point1;
                    Point B2 = line2.Point2;
                    double d1 = B1.X - A1.X; // d - direction
                    double d2;
                    if (d1 == 0)
                    {
                        d1 = B1.Y - A1.Y;
                        d2 = B2.Y - A2.Y;
                    }
                    else
                        d2 = B2.X - A2.X;
                    bool co_directional = (d1 > 0 && d2 > 0) || (d1 < 0 && d2 < 0);
                    // сонаправлены - true, нет - false
                    // можно через d1*d2>0, но, думаю, проверки жрут меньше, тем более тут double
                    // Для начала проверим ситуации, когда нужно вернуть только одну точку.
                    if (co_directional) // если сонаправлены
                    {
                        if (B1.Equals(A2)) // начало второго совпадает с концом первого
                            return new Point[] { B1 };
                        if (B2.Equals(A1)) // начало первого совпадает с концом второго
                            return new Point[] { A1 };
                    }
                    else // направлены в противоположные стороны
                    {
                        if (A1.Equals(A2)) // начало второго совпадает с началом первого
                            return new Point[] { A1 };
                        if (B2.Equals(B1)) // конец первого совпадает с концом второго
                            return new Point[] { B1 };
                    }
                    // Далее будем проверять ситуации, когда нужно вернуть null или две точки
                    // олицетворяющие отрезок.
                    // Понятие "внутри" включает в себя возможное совпадение каких-то точек
                    if (Intersects(line1, A2)) // A2 содержится "внутри" отрезка?
                    {
                        if (Intersects(line1, B2)) // B2 тоже "внутри"?
                        {
                            // пример того, как вернуть именно сонаправленный line1 отрезок 
                            if (co_directional)
                                return new Point[] { A2, B2 };
                            return new Point[] { B2, A2 };
                        }
                        else // B2 "снаружи" - но с какой стороны?
                        {
                            if (co_directional)
                                return new Point[] { A2, B1 }; // B2 идет позже чем B1
                            return new Point[] { A1, A2 }; // а иначе B2 вылетает в сторону A1
                        }
                    }
                    else // A2 "снаружи"
                    {
                        if (Intersects(line1, B2)) // B2 "внутри"?
                        {
                            if (co_directional)
                                return new Point[] { A1, B2 }; // A2 вылетело за A1
                            return new Point[] { B2, B1 }; // иначе A2 вылетело за B1 
                        }
                        else // A2 и B2 снаружи. 
                        {
                            // Но отрезок A1B1 может сам являться пересечением, это надо проверить
                            if (Intersects(line2, A1))
                                return new Point[] { A1, B1 }; // вторая точка автоматом внутри
                            return null; //Пересечений нет вообще
                        }

                    }
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

        /*
        Убрать исключения и catch
        Использовать его Внутри метода для отрезков
        и ПЕРЕД вызовом метода для прямых */
        public static LineEquationsStatus GetLineEquationsStatus(
            (double a1, double b1, double c1) lineEq1,
            (double a2, double b2, double c2) lineEq2)
        {
            double a1 = lineEq1.a1, b1 = lineEq1.b1, c1 = lineEq1.c1,
               a2 = lineEq2.a2, b2 = lineEq2.b2, c2 = lineEq2.c2;
            if (a1 == 0 && b1 == 0)
                throw new LibraryException(
                    ErrorCode.ILLEGAL_ARGUMENT,
                    "Уравнение прямой lineEq1 задано неверно");
            if (a2 == 0 && b2 == 0)
                throw new LibraryException(
                    ErrorCode.ILLEGAL_ARGUMENT,
                    "Уравнение прямой lineEq2 задано неверно");
            if (a1 == 0)
            { 
                if (a2 == 0)
                {
                    if (c1 / b1 == c2 / b2)
                    {
                        return LineEquationsStatus.COINCIDE;
                    }
                    return LineEquationsStatus.PARALLEL;
                }
                return LineEquationsStatus.INTERSECTS;
            }
            if (a2 == 0)
            {
                return LineEquationsStatus.INTERSECTS;
            }
            if (b1 == 0 && b2 == 0)
            {
                if (c1 / a1 == c2 / a2)
                {
                    return LineEquationsStatus.COINCIDE;
                }
                return LineEquationsStatus.PARALLEL;
            }
            return LineEquationsStatus.INTERSECTS;
        }
    }
}
