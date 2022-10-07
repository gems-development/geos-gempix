namespace GeometryModels.Interfaces.IModels
{
    internal interface IModelDistanceCalculator: IGeometryPrimitiveVisitor
    {
        public double GetResult();
    }
}
