namespace GeosGempix.Interfaces.IModels
{
    public interface IModelDistanceCalculator : IGeometryPrimitiveVisitor
    {
        public double GetResult();
    }
}
