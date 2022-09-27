using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace KochSnowflake
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public override void Render(DrawingContext context)
        {
            Pen penBlack = new Pen(Colors.Black.ToUint32(), 5);
            
            Point point1 = new Point(100, 100);
            Point point2 = new Point(400, 100);
            Point point3 = new Point(250, 300);

            context.DrawLine(penBlack, point1, point2);
            context.DrawLine(penBlack, point2, point3);
            context.DrawLine(penBlack, point3, point1);
            
            //CustomCanvas.
        }
    }
}