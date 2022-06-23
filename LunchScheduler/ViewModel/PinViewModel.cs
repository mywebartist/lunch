namespace LunchScheduler.ViewModel
{
    public class PinViewModel : BaseViewModel
    {
        string pin;
        public string Pin
        {
            get { return pin; }
            set
            {
                pin = value;
                OnPropertyChanged();
            }

        }
    }
}
