namespace GeometryModels.Interfaces.IModels
{
    public interface IModelDistanceCalculator : IGeometryPrimitiveVisitor
    {
        public double GetResult();
    }
}
