namespace LunchScheduler.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }
    }
}