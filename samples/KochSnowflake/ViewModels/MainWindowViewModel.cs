namespace KochSnowflake.ViewModels
{
    using Avalonia;
    using Avalonia.Media;
    using Avalonia.Controls;
    
    using Prism.Mvvm;
    using Prism.Commands;

    using KochSnowflake.Extensions;
    using SkiaSharp;

    public class MainWindowViewModel : BindableBase
    {
        private static readonly IPen s_penGreen;

        private static readonly IPen s_penBlue;

        private static Canvas s_canvas;

        private string _title = "Koch snowflake";

        private ContentControl _contentControl = null!;

        public string Title
        {
            get => _title;

            set => SetProperty(ref _title, value);
        }

        public ContentControl ContentControl
        {
            get => _contentControl;

            set => SetProperty(ref _contentControl, value);
        }

        public DelegateCommand DrawKochSnowflakeCommand { get; set; } = null!;

        static MainWindowViewModel()
        {
            s_canvas = new Canvas();
            s_penGreen = new Pen(Colors.Green.ToUint32(), 2);
            s_penBlue = new Pen(Colors.Blue.ToUint32(), 2);
        }

        public MainWindowViewModel()
        {
            ContentControl = new ContentControl();
            DrawKochSnowflakeCommand = new DelegateCommand(DrawKochSnowflake);
        }

        private void DrawKochSnowflake()
        {
            var point1 = new Point(ContentControl.Width / 3, ContentControl.Height / 3);
            var point2 = new Point(2 * ContentControl.Width / 3, ContentControl.Height / 3);
            var point3 = new Point(ContentControl.Width / 2, 2 * ContentControl.Height / 3);

            s_canvas.DrawLine(point1, point2, s_penGreen);
            s_canvas.DrawLine(point2, point3, s_penGreen);
            s_canvas.DrawLine(point3, point1, s_penGreen);

            FractalKoch(point1, point2, point3, 5);
            FractalKoch(point2, point3, point1, 5);
            FractalKoch(point3, point1, point2, 5);

            ContentControl = new ContentControl()
            {
                Content = s_canvas
            };
        }

        int FractalKoch(Point p1, Point p2, Point p3, int iter)
        {
            if (iter > 0)
            {
                //средняя треть отрезка
                var p4 = new Point((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new Point((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);

                //координаты вершины угла
                var ps = new Point((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new Point((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                //рисование
                s_canvas.DrawLine(p4, pn, s_penGreen);
                s_canvas.DrawLine(p5, pn, s_penGreen);
                s_canvas.DrawLine(p4, p5, s_penBlue);

                //рекурсивный вывод функции
                FractalKoch(p4, pn, p5, iter - 1);
                FractalKoch(pn, p5, p4, iter - 1);
                FractalKoch(p1, p4, new Point((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                FractalKoch(p5, p2, new Point((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);
            }
            return iter;
        }
    }
}
