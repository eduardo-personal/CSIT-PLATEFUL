using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Plateful.ViewModels;

namespace Plateful.Views.ContentDialogs;

public sealed partial class SignUpDialog : Page
{
    public string Username => UsernameTextBox.Text;
    public string Password => PasswordTextBox.Password;

    public string Email => EmailTextBox.Text;
    public string ConfirmPassword => ConfirmPasswordTextBox.Password;

    public SignUpDialog()
    {
        InitializeComponent();
    }

    public string ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            return "Username and password cannot be empty.";
        }

        if (Password != ConfirmPassword)
        {
            return "Passwords do not match.";
        }

        return null;
    }
}
