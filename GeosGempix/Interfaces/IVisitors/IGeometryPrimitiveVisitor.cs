﻿using GeosGempix;
using GeosGempix.Models;
using GeosGempix.MultiModels;

public interface IGeometryPrimitiveVisitor
{
    public void Visit(Point point);
    public void Visit(Line line);
    public void Visit(Polygon polygon);
    public void Visit(MultiPoint multiPoint);
    public void Visit(MultiLine multiLine);
    public void Visit(MultiPolygon multiPolygon);
    public void Visit(Contour contour);
}
