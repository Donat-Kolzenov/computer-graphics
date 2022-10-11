namespace KochSnowflake.ViewModels
{
    using Avalonia.Media;
    using Avalonia.Controls;
    
    using Prism.Mvvm;
    using Prism.Commands;

    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand DrawKochSnowflakeCommand { get; set; } = null!;

        public MainWindowViewModel()
        {
        }
    }
}
