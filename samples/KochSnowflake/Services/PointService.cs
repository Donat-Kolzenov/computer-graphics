namespace KochSnowflake.Services
{
    using System;

    using KochSnowflake.Models;

    public class PointService
    {
        public PointModel GeneratePoint(int x, int y)
        {
            return new PointModel()
            {
                X = x,
                Y = y
            };
        }
    }
}
