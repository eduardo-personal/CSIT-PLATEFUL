using CommunityToolkit.Mvvm.ComponentModel;
using Plateful.Models;

namespace Plateful.ViewModels;

public partial class NewMealViewModel : ObservableRecipient
{
    [ObservableProperty]
    private MealModel _newMeal = new MealModel();  // Automatically handles property change notifications
}
