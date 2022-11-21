
using GeometryModels.Models;
using System.Diagnostics.CodeAnalysis;
/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiLine : IGeometryPrimitive
{
    private List<Line> _lines;

    public MultiLine(List<Line> lines)
    {
        if (lines == null)
            throw new ArgumentNullException("lines");
        if (lines.Capacity == 0)
            throw new ArgumentException("Длина списка lines = 0");
        foreach (Line line in lines)
            if (line == null)
                throw new ArgumentNullException("lines", "Один из элементов списка lines равен null");
        _lines = new List<Line>(lines);
    }

    public List<Line> GetLines()
    {
        return _lines;
    }

    public void Accept(IGeometryPrimitiveVisitor v)
    {
        if (v == null)
            throw new ArgumentNullException("v");
        v.Visit(this);
    }
}
