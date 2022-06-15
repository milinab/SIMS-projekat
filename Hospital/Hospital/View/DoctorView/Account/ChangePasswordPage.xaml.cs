using System.Windows;
using ServiceStack;

namespace Hospital.View.DoctorView.Account
{
    public partial class ChangePasswordPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void Change_OnClick(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = "";
            if (Current.Password.IsEmpty() || New.Password.IsEmpty() || ConfirmNew.Password.IsEmpty())
            {
                ErrorTextBlock.Text = "Please enter all fields";
                return;
            } 
            if (!LogIn.LoggedUser.Password.Equals(Current.Password))
            {
                ErrorTextBlock.Text = "Invalid password";
                return;
            }
            if (!New.Password.Equals(ConfirmNew.Password))
            {
                ErrorTextBlock.Text = "Passwords do not match";
                return;
            }
            LogIn.LoggedUser.Password = New.Password;
            var app = Application.Current as App;
            app?._userController.Edit(LogIn.LoggedUser);
            MainWindow.MainFrame.GoBack();
        }
        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}