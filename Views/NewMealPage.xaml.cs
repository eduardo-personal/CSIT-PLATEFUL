using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Plateful.Models;
using Plateful.ViewModels;

namespace Plateful.Views;

public sealed partial class NewMealPage : Page
{
    private HomeViewModel _hmw;
    public NewMealPage()
    {
        _hmw = App.GetService<HomeViewModel>();
        InitializeComponent();
    }

    private async void SaveMeal_Click(object sender, RoutedEventArgs e)
    {
        // Retrieve the input values from the TextBox elements
        string mealName = MealNameTextBox.Text;
        string mealDescription = MealDescriptionTextBox.Text;
        double estimatedCost;

        // Try to parse the cost input
        if (!double.TryParse(MealCostTextBox.Text, out estimatedCost))
        {
            // Handle invalid cost input
            ContentDialog errorDialog = new ContentDialog
            {
                Title = "Error",
                Content = "Please enter a valid estimated cost.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };
            await errorDialog.ShowAsync();
            return;
        }

        // Create a new MealModel instance
        MealModel newMeal = new MealModel
        {
            Name = mealName,
            Description = mealDescription,
            EstimatedCost = (int)estimatedCost
        };

        // Example: Save meal logic (add to database or list)
        if (!string.IsNullOrWhiteSpace(newMeal.Name) && newMeal.EstimatedCost > 0)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Meal Saved",
                Content = $"{newMeal.Name} has been added successfully!",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };
            await dialog.ShowAsync();

            _hmw.AddMeal(newMeal);
        }
        else
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Error",
                Content = "Please fill in all required fields.",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };
            await dialog.ShowAsync();
        }
    }
}
