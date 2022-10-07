namespace GeometryModels.Interfaces.IVisitors
{
    internal interface IModelsIntersector : IGeometryPrimitiveVisitor
    {
        public bool GetResult();
    }
}
