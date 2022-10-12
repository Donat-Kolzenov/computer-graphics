namespace CustomShape
{
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Controls.Shapes;
    using Avalonia.Markup.Xaml;
    using Avalonia.Media;

    using DesktopSamples.Core.Extensions;

    public partial class MainWindow : Window
    {
        private static readonly Canvas s_canvas;

        private static readonly IPen s_penBlack;

        static MainWindow()
        {
            s_canvas = new Canvas();
            s_penBlack = new Pen(Colors.Black.ToUint32(), 2);
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            this.CustomContentControl = this.Find<ContentControl>("CustomContentControl");
        }

        private void DrawCustomShapeButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            s_canvas.Clear();
            DrawCoordinateAxes();
            CustomContentControl.Content = s_canvas;
        }

        private void DrawCustomShape()
        {
            throw new System.NotImplementedException();
        }

        private void DrawCoordinateAxes()
        {
            double width = ClientSize.Width;
            double height = ClientSize.Height;

            // draw X axis
            s_canvas.DrawLine(
                new Point(0, height / 2),
                new Point(width, height / 2),
                s_penBlack);

            // draw Y axis
            s_canvas.DrawLine(
                new Point(width / 2, 0),
                new Point(width / 2, height),
                s_penBlack);
        }
    }
}
