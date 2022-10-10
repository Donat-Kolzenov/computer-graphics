namespace DesktopSamples.Models.ShapeBase
{
    using DesktopSamples.Models.Interfaces;
    using DesktopSamples.Models.Point;

    public abstract class ShapeBaseModel : IShapeModel
    {
        public ShapeBaseModel()
        {
            Points = new List<PointModel>();
        }

        public List<PointModel> Points { get; }
    }
}
