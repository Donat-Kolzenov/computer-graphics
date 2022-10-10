namespace DesktopSamples.Services.Interfaces
{
    using DesktopSamples.Models.Point;

    public interface IPointService
    {
        PointModel GeneratePoint(double x, double y);
    }
}
