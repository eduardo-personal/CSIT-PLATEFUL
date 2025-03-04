using Microsoft.UI.Xaml.Controls;

using Plateful.ViewModels;

namespace Plateful.Views;

public sealed partial class DigestOptionsPage : Page
{
    public DigestOptionsViewModel ViewModel
    {
        get;
    }

    private ShellViewModel _svm;

    public DigestOptionsPage()
    {
        ViewModel = App.GetService<DigestOptionsViewModel>();
        _svm = App.GetService<ShellViewModel>();
        InitializeComponent();
    }

    private void Save_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {


        _svm.NavigationService.NavigateTo(typeof(HomeViewModel).FullName);

    }
}
