namespace KochSnowflake
{
    using Avalonia;
    using Avalonia.Controls;
    using Avalonia.Controls.Shapes;
    using Avalonia.Markup.Xaml;
    using Avalonia.Media;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var colorBrush = new SolidColorBrush();
            colorBrush.Color = Colors.Red;

            var circle = new Ellipse()
            {
                Fill = colorBrush,
                Width = 400,
                Height = 400,
                Margin = new Thickness(0, 50, 0, 0)
            };

            var container = new StackPanel();
            container.Children.Add(circle);
            this.drawingCanvas.Content = container;
        }
    }
}
