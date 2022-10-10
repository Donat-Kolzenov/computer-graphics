namespace DesktopSamples.Services.Point
{
    using DesktopSamples.Services.Interfaces;
    using DesktopSamples.Models.Point;

    public class PointService : IPointService
    {
        public PointModel GeneratePoint(double x, double y)
        {
            return new PointModel()
            {
                X = x,
                Y = y
            };
        }
    }
}
