using System.Windows.Input;
using Hospital.View.DoctorView.Commands;

namespace Hospital.View.DoctorView.ViewModel
{
    public class AccountPageViewModel : ViewModelBase
    {
        public string Name { get;}
        public string Surname { get;}
        public string Username { get;}
        public string Email { get;}
        public string Phone { get;}
        public string Address { get; }
        
        public ICommand ChangePassword { get; }
        public ICommand Tutorial { get; }
        
        public AccountPageViewModel()
        {
            var user = LogIn.LoggedUser;
            Name = user.Name;
            Surname = user.LastName;
            Username = user.Username;
            Email = user.Email;
            Phone = user.Phone;
            Address = user.Address.Street + " " + user.Address.Number;

            ChangePassword = new ChangePasswordCommand();
            Tutorial = new TutorialCommand();
        }
    }
}