namespace KochSnowflake
{
    using System.Collections.Generic;

    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Controls.Shapes;
    using Avalonia.Markup.Xaml;
    using Avalonia.Media;

    using KochSnowflake.Extensions;

    public partial class MainWindow : Window
    {
        private static readonly Canvas _canvas;

        private static readonly IPen _penGreen;

        static MainWindow()
        {
            _canvas = new Canvas();
            _penGreen = new Pen(Colors.Green.ToUint32(), 2);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.DrawKochSnowflakeButton = this.Find<Button>("DrawKochSnowflakeButton");
            this.DrawKochSnowflakeButton.Click += DrawKochSnowflakeButton_Click!;
            this.CustomContentControl = this.Find<ContentControl>("CustomContentControl");
        }

        static int FractalKoch(Point p1, Point p2, Point p3, int iter)
        {
            if (iter > 0)
            {
                var p4 = new Point((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new Point((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                var ps = new Point((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new Point((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                _canvas.DrawLine(p4, pn, _penGreen);
                _canvas.DrawLine(p5, pn, _penGreen);
                _canvas.DrawLine(p4, p5, _penGreen);

                FractalKoch(p4, pn, p5, iter - 1);
                FractalKoch(pn, p5, p4, iter - 1);
                FractalKoch(p1, p4, new Point((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                FractalKoch(p5, p2, new Point((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);
            }
            return iter;
        }

        private void DrawKochSnowflakeButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            _canvas.Children.Clear();

            double width = ClientSize.Width;
            double height = ClientSize.Height;

            var point1 = new Point(width / 3, height / 3);
            var point2 = new Point(2 * width / 3, height / 3);
            var point3 = new Point(width / 2, 2 * height / 3);

            _canvas.DrawLine(point1, point2, _penGreen);
            _canvas.DrawLine(point2, point3, _penGreen);
            _canvas.DrawLine(point3, point1, _penGreen);

            FractalKoch(point1, point2, point3, 5);
            FractalKoch(point2, point3, point1, 5);
            FractalKoch(point3, point1, point2, 5);

            this.CustomContentControl.Content = _canvas;
        }
    }
}
