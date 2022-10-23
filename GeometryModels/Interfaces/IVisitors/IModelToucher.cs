namespace GeometryModels.Interfaces.IVisitors
{
    public interface IModelToucher : IGeometryPrimitiveVisitor
    {
        public bool GetResult();
    }
}
