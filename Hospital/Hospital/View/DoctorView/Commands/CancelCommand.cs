namespace Hospital.View.DoctorView.Commands
{
    public class CancelCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}