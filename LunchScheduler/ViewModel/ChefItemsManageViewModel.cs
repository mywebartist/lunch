namespace LunchScheduler.ViewModel
{
    public class ChefItemsManageViewModel : BaseViewModel
    {
        string _itemName;
        public string itemName
        {
            get { return _itemName; }
            set
            {
                _itemName = value;
                OnPropertyChanged();
            }
        }

        string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
    }
}