﻿
/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiLine : IGeometryPrimitive
{
    List<Line> lines;

    public MultiLine(List<Line> lines)
    {
        this.lines = new List<Line>(lines);
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }

    internal List<Line> GetLines()
    {
        return lines;
    }
}