namespace KochSnowflake.ViewModels
{
    using Avalonia.Media;
    using Avalonia.Controls;
    
    using Prism.Mvvm;
    using Prism.Commands;

    public class MainWindowViewModel : BindableBase
    {
        private ContentControl _drawingCanvas;

        public DelegateCommand DrawTriangleCommand { get; set; } = null!;

        public MainWindowViewModel()
        {
            DrawTriangleCommand = new DelegateCommand(DrawTriangle);
        }

        private void DrawTriangle()
        {
            var triangle = new Models.Triangle(_drawingCanvas, Colors.Blue);
            triangle.Draw();
        }
    }
}
