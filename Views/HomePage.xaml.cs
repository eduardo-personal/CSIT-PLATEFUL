using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Plateful.ViewModels;
using Plateful.Views.ContentDialogs;

namespace Plateful.Views;

public sealed partial class HomePage : Page
{
    public HomeViewModel ViewModel
    {
        get;
    }

    private ShellViewModel _svm;
    public HomePage()
    {
        InitializeComponent();
        ViewModel = App.GetService<HomeViewModel>();
        _svm = App.GetService<ShellViewModel>();
        DataContext = ViewModel;


    }

    private void OnMealPage_Click(object sender, RoutedEventArgs e)
    {
        _svm.NavigationService.NavigateTo(typeof(NewMealViewModel).FullName);
    }

    private void OnDigestPage_Click(object sender, RoutedEventArgs e)
    {
        _svm.NavigationService.NavigateTo(typeof(DigestOptionsViewModel).FullName);
    }



    private void LoginIn_Click(object sender, RoutedEventArgs e)
    {
        string username = UsernameTextBox.Text;
        string password = PasswordTextBox.Password;

        if (ViewModel.ValidateLogin(username, password))
        {
            LoginGrid.Visibility = Visibility.Collapsed;
            MainPage.Visibility = Visibility.Visible;

            LoginStatusTextBlock.Text = $"Welcome, {username}!";
            LoginStatusTextBlock.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Green);
        }
        else
        {
            LoginStatusTextBlock.Text = "Invalid username or password.";
            LoginStatusTextBlock.Foreground = new Microsoft.UI.Xaml.Media.SolidColorBrush(Microsoft.UI.Colors.Red);
        }
    }

    private async void CreateAccount_Click(object sender, RoutedEventArgs e)
    {
        var signUpDialog = new SignUpDialog();

        ContentDialog dialog = new ContentDialog
        {
            XamlRoot = this.XamlRoot,
            Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
            Title = "Sign Up",
            PrimaryButtonText = "Create",
            CloseButtonText = "Cancel",
            DefaultButton = ContentDialogButton.Primary,
            Content = signUpDialog
        };

        var result = await dialog.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            string validationMessage = signUpDialog.ValidateInputs();
            if (validationMessage != null)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Error",
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    Content = validationMessage,
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await errorDialog.ShowAsync();
                return;
            }

            if (ViewModel.AddAccount(signUpDialog.Username, signUpDialog.Password, signUpDialog.Email) == false)
            {
                ContentDialog errorDialog = new ContentDialog
                {
                    Title = "Error",
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,

                    Content = "Username already exists.",
                    CloseButtonText = "OK",
                    XamlRoot = this.XamlRoot
                };
                await errorDialog.ShowAsync();
                return;
            }

            ContentDialog successDialog = new ContentDialog
            {
                Title = "Success",
                Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,

                Content = "Account created successfully!",
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };
            await successDialog.ShowAsync();
        }
    }

}
