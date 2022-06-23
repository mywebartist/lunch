using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Service;
using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.ObjectModel;

namespace LunchScheduler.ViewModel
{
    public class StaffItemsSelectionViewModel : BaseViewModel
    {
        public StaffItemsSelectionViewModel()
        {
            SelectedDate = DateTime.Now;
            OrderSelectionData = new ObservableCollection<ItemModel>();
            getItems();

        }
        public async void getItems()
        {
            try
            {
                var web = new AccountService();

                var result = await web.getItemsApi(Convert.ToInt16(Settings.ActiveOrganizationId));
                if (result != null)
                {
                    OrderSelectionData = new ObservableCollection<ItemModel>(result.data);
                }
                else
                {
                    // api is down
                    App.Current.MainPage.DisplayAlert("alert", "system not working", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }

        ObservableCollection<ItemModel> _orderData;
        DateTime _selectedDate;
        public ObservableCollection<ItemModel> OrderSelectionData
        {
            get { return _orderData; }
            set
            {
                _orderData = value;
                OnPropertyChanged();
            }
        }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
    }
}