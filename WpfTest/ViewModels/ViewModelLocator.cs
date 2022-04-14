using Microsoft.Extensions.DependencyInjection;

namespace WpfTest.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
