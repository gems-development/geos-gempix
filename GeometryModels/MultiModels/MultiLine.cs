
using GeometryModels.Models;
using System.Diagnostics.CodeAnalysis;
/// <summary>
/// Summary description for Class1
/// </summary>
public class MultiLine : IGeometryPrimitive
{
    List<Line> lines;

    public MultiLine([NotNull] List<Line> lines)
    {
        if (lines.Capacity == 0)
            throw new ArgumentException("Длина списка lines = 0");
        this.lines = new List<Line>(lines);
    }

    public List<Line> GetLines()
    {
        return lines;
    }

    public void Accept([NotNull] IGeometryPrimitiveVisitor v)
    {
        v.Visit(this);
    }
}
