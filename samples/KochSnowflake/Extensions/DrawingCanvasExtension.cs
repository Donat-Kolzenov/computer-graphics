namespace KochSnowflake.Extensions
{
    using Avalonia;
    using Avalonia.Media;
    using Avalonia.Controls;
    using Avalonia.Controls.Shapes;

    public static class DrawingCanvasExtension
    {
        public static void DrawLine(
            this Canvas canvas,
            Point startPoint,
            Point endPoint,
            IPen pen)
        {
            var line = new Line()
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Stroke = pen.Brush,
                StrokeThickness = pen.Thickness,
                StrokeLineCap = pen.LineCap,
                StrokeJoin = pen.LineJoin
            };
            canvas.Children.Add(line);
        }
    }
}
