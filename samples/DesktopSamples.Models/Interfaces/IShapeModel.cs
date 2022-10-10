namespace DesktopSamples.Models.Interfaces
{
    using DesktopSamples.Models.Point;

    public interface IShapeModel
    {
        List<PointModel> Points { get; }
    }
}
