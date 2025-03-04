using Microsoft.UI.Xaml.Controls;

using Plateful.ViewModels;

namespace Plateful.Views;

public sealed partial class MealDetailsPage : Page
{
    public MealDetailsViewModel ViewModel
    {
        get;
    }

    public MealDetailsPage()
    {
        ViewModel = App.GetService<MealDetailsViewModel>();
        InitializeComponent();
    }
}
