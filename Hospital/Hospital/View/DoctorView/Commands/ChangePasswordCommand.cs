using Hospital.View.DoctorView.Account;

namespace Hospital.View.DoctorView.Commands
{
    public class ChangePasswordCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MainWindow.MainFrame.Navigate(new ChangePasswordPage());
        }
    }
}