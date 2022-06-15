using Hospital.View.DoctorView.Account;

namespace Hospital.View.DoctorView.Commands
{
    public class TutorialCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MainWindow.MainFrame.Navigate(new TutorialPage());
        }
    }
}