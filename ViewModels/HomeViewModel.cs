using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using Plateful.Models;

namespace Plateful.ViewModels;

public partial class HomeViewModel : ObservableRecipient
{
    [ObservableProperty]
    private ObservableCollection<MealModel> defaultPlates = new();

    [ObservableProperty]
    public ObservableCollection<AccountModel> accounts;

    [ObservableProperty]
    public AccountModel? currentUser; // Stores the logged-in user

    public HomeViewModel()
    {
        // Initialize the accounts collection with dummy data on launch
        accounts = new ObservableCollection<AccountModel>
        {
            new AccountModel("admin", "admin123", "edu@gmail.com"),
            new AccountModel("guest", "guest123", "edu@gmail.com"),
            new AccountModel("gto", "gto", "guest@gmail.com")
        };

        currentUser = null; // No user logged in at start

        LoadDefaultPlates();

    }

    public void AddMeal(MealModel meal)
    {
        DefaultPlates.Add(meal);
    }



    // Method to load dummy data into the collection
    private void LoadDefaultPlates()
    {
        var dummyMeals = new List<MealModel>
            {
                new MealModel { Name = "Spaghetti Bolognese", Description = "Classic Italian pasta with rich meat sauce", EstimatedCost = 12 },
                new MealModel { Name = "Caesar Salad", Description = "Crisp romaine lettuce with Caesar dressing", EstimatedCost = 8 },
                new MealModel {  Name = "Chicken Curry", Description = "Spicy chicken curry with rice", EstimatedCost = 15 },
                new MealModel { Name = "Grilled Cheese Sandwich", Description = "Classic grilled cheese sandwich", EstimatedCost = 5 }
            };

        foreach (var meal in dummyMeals)
        {
            DefaultPlates.Add(meal);
        }
    }

    public bool AddAccount(string username, string password, string email)
    {
        if (accounts.Any(a => a.Username == username))
        {
            return false; // Username already exists
        }

        //if email is null or empty, set it to ""
        if (string.IsNullOrEmpty(email))
        {
            email = "none@gmail.com";
        }

        accounts.Add(new AccountModel(username, password, email));
        return true;
    }

    public bool ValidateLogin(string username, string password)
    {
        var user = accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        if (user != null)
        {
            CurrentUser = user; // Set the current user
            return true;
        }

        return false;
    }

    public void Logout()
    {
        CurrentUser = null; // Clears the logged-in user
    }
}
