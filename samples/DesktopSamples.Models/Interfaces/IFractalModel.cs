namespace DesktopSamples.Models.Fractal
{
    using DesktopSamples.Models.Point;

    public interface IFractal
    {
        List<PointModel> Points { get; }
    }
}
