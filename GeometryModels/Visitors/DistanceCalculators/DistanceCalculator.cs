﻿using GeometryModels.Interfaces.IModels;
using GeometryModels.Models;
using GeometryModels.Visitors.DistanceCalculators.ModelsDistanceCalculator;

namespace GeometryModels.Visitors.DistanceCalculators
{
    public class DistanceCalculator : IModelDistanceCalculator
    {
        private readonly double _result;

        private IModelDistanceCalculator _calculator;

        public DistanceCalculator(IGeometryPrimitive primitive1, IGeometryPrimitive primitive2)
        {
            primitive1.Accept(this);
            primitive2.Accept(_calculator!);
            _result = _calculator!.GetResult();
        }

        public double GetResult() =>
            _result;

        public void Visit(Point point) =>
            _calculator = new PointDistanceCalculator(point);

        public void Visit(Line line) =>
            _calculator = new LineDistanceCalculator(line);

        public void Visit(Polygon polygon) =>
            _calculator = new PolygonDistanceCalculator(polygon);

        public void Visit(MultiPoint multiPoint) =>
            _calculator = new MultiPointDistanceCalculator(multiPoint);

        public void Visit(MultiLine multiLine) =>
            _calculator = new MultiLineDistanceCalculator(multiLine);

        public void Visit(MultiPolygon multiPolygon) =>
            _calculator = new MultiPolygonDistanceCalculator(multiPolygon);

        public void Visit(Contour contour) =>
            throw new NotImplementedException();
    }
}