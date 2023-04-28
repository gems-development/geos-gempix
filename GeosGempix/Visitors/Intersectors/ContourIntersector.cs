﻿using GeosGempix.Interfaces.IVisitors;
using GeosGempix.Models;
using GeosGempix.MultiModels;

namespace GeosGempix.GeometryPrimitiveIntersectors
{
    public class ContourIntersector : IModelsIntersector
    {
        private bool _result;
        private readonly Contour _contour;

        public ContourIntersector(Contour contour) =>
            _contour = contour;

        internal static bool Intersects(Contour contour, Point point)
        {
            foreach (Line line in contour.GetLines())
                if (LineIntersector.Intersects(line, point))
                    return true;
            return false;
        }
        internal static bool Intersects(Contour contour, Line line)
        {
            foreach (Line contourLine in contour.GetLines())
                if (LineIntersector.Intersects(line, contourLine))
                    return true;
            return false;
        }
        internal static bool Intersects(Contour contour1, Contour contour2)
        {
            foreach (Line line in contour1.GetLines())
                if (Intersects(contour2, line))
                    return true;
            return false;
        }

        public bool GetResult() =>
            _result;

        public void Visit(Point point) =>
            _result = Intersects(_contour, point);

        public void Visit(Line line) =>
            _result = Intersects(_contour, line);

        public void Visit(Polygon polygon) =>
            _result = PolygonIntersector.Intersects(polygon, _contour);

        public void Visit(MultiPoint multiPoint) =>
            _result = MultiPointIntersector.Intersects(multiPoint, _contour);

        public void Visit(MultiLine multiLine) =>
            _result = MultiLineIntersector.Intersects(multiLine, _contour);

        public void Visit(MultiPolygon multiPolygon) =>
            _result = MultiPolygonIntersector.Intersects(multiPolygon, _contour);

        public void Visit(Contour contour) =>
            _result = Intersects(_contour, contour);
    }
}
